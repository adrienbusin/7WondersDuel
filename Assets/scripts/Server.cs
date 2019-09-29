using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Server : MonoBehaviour
{
    public int port = 6563;

    List<ServerClient> clients;
    List<ServerClient> disconnectLists;

    TcpListener server;
    bool serverStarted;

    public void Update()
    {
        if (serverStarted)
        {
            return;
        }

        foreach (ServerClient c in clients)
        {
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                disconnectLists.Add(c);
                continue;
            }
            NetworkStream s = c.tcp.GetStream();
            if (s.DataAvailable)
            {
                StreamReader reader = new StreamReader(s, true);
                string data = reader.ReadLine();
                if (data != null)
                {
                    OnInComingData(c, data);
                }
            }
        }

        for (int i = 0; i < disconnectLists.Count - 1; i++)
        {
            //TELL YOUT PLAYER HAS DISCONNECTED
            clients.Remove(disconnectLists[i]);
            disconnectLists.RemoveAt(i);
        }
    }

    public void Init()
    {
        DontDestroyOnLoad(gameObject);

        clients = new List<ServerClient>();
        disconnectLists = new List<ServerClient>();

        try
        {
            server = new TcpListener(IPAddress.Any, port);

            server.Start();
            serverStarted = true;
            StartListening();
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e.Message);
        }
    }

    void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }

    //Server Send
    void BroadCast(string data, List<ServerClient> cl)
    {
        foreach (ServerClient sc in cl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();
            }
            catch (Exception e)
            {
                Debug.Log("Write error :" + e.Message);
            }
        }
    }

    //Server Read
    void OnInComingData(ServerClient c, string data)
    {
        Debug.Log(c.clientName + " : " + data);
    }


    bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);

                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }


    void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener) ar.AsyncState;
        ServerClient sc = new ServerClient(listener.EndAcceptTcpClient(ar));
        clients.Add(sc);

        StartListening();

        Debug.Log("Somebody has connected!");
    }
}


public class ServerClient
{
    public string clientName;
    public TcpClient tcp;

    public ServerClient(TcpClient tcp)
    {
        this.tcp = tcp;
    }
}