using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    private Player _player1;
    private Player _player2;
    private int _playerWhoPlay;
    private GameObject _tourJoueurText;
    private bool _hasSelectPlayerStartAge;

    private PlayerNameManager _playerNameManager;

    private String player1Name;
    private String player2Name;

    private void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>();
        _player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>();
        _playerNameManager = GameObject.FindGameObjectWithTag("PlayerNameManager").GetComponent<PlayerNameManager>();

        player1Name = _playerNameManager.Player1Name;
        player2Name = _playerNameManager.Player2Name;

        _player1.PlayerName = player1Name;
        _player2.PlayerName = player2Name;

        whoStartPlaying();
    }

    void whoStartPlaying()
    {
        _tourJoueurText = GameObject.Find("TourJoueurText");
        float player = Random.Range(0.0f, 1.0f);
        if (player < 0.5f)
        {
            _player1.GetComponent<Player>().IsPlaying = true;
            _player2.GetComponent<Player>().IsPlaying = false;
            _playerWhoPlay = 0;
            setTextPlayer(player1Name);
        }
        else
        {
            _player1.GetComponent<Player>().IsPlaying = false;
            _player2.GetComponent<Player>().IsPlaying = true;
            _playerWhoPlay = 1;
            setTextPlayer(player2Name);
        }
        HasSelectPlayerStartAge = true;
    }

    void setTextPlayer(String playerName)
    {
        _tourJoueurText.GetComponent<Text>().text = "Au tour de " + playerName;
    }

    public void nextPlayer(int playerWhoPlay)
    {
        if (playerWhoPlay == 0)
        {
            PlayerWhoPlay = 1;
            setTextPlayer(player2Name);
        }
        else
        {
            PlayerWhoPlay = 0;
            _tourJoueurText.GetComponent<Text>().text = "Au tour de " + player1Name;
        }
    }

    public int PlayerWhoPlay
    {
        get { return _playerWhoPlay; }
        set { _playerWhoPlay = value; }
    }

    public Player Player
    {
        get { return _playerWhoPlay == 0 ? _player1 : _player2; }
    }

    public Player Player1
    {
        get { return _player1; }
    }

    public Player Player2
    {
        get { return _player2; }
    }

    public void TourJoueurText(String text)
    {
        _tourJoueurText.GetComponent<Text>().text = text;
    }

    public bool HasSelectPlayerStartAge
    {
        get { return _hasSelectPlayerStartAge; }
        set { _hasSelectPlayerStartAge = value; }
    }
}