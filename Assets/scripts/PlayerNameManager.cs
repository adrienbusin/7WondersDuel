using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public Text _player1Name;
    public Text _player2Name;
    public GameObject sound;
    public List<Sprite> soundOnOff;
    public AudioSource musique;

    private String player1Name;
    private String player2Name;
    private bool _soundOff;
    


    public void onPlay()
    {
        if (_player1Name != null)
        {
            player1Name = _player1Name.text;
        }
        if (_player2Name != null)
        {
            player2Name = _player2Name.text;
        }
        SceneManager.LoadScene("Selection Merveille");
    }

    public void OnClickSound()
    {
        if (_soundOff)
        {
            sound.GetComponent<Image>().sprite = soundOnOff[1];
            musique.mute = false;
            _soundOff = false;
        }
        else
        {
            sound.GetComponent<Image>().sprite = soundOnOff[0];
            musique.mute = true;
            _soundOff = true;
        }
        
    }

    public string Player1Name
    {
        get
        {
            if (player1Name != "")
            {
                return player1Name;
            }
            return "Player1";
        }
        set { player1Name = value; }
    }

    public string Player2Name
    {
        get
        {
            if (player2Name != "")
            {
                return player2Name;
            }
            return "Player2";
        }
        set { player2Name = value; }
    }
}