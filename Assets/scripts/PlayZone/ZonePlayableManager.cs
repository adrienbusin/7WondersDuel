using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonePlayableManager : MonoBehaviour
{
    private GameObject[] _defausseZone;
    private GameObject _playZoneJoueur1;
    private GameObject _playZoneJoueur2;
    public GameObject _coutCardJoueur1;
    public GameObject _coutCardJoueur2;
    private PlayerManager _playerManager;

    public GameObject NbCarteJaune;
    public GameObject NbCarteRouge;
    public GameObject NbCarteVert;
    public GameObject NbCarteBleu;
    public GameObject NbCarteGuilde;
    public GameObject NbCarteMarron;
    public GameObject NbCarteGris;

    public GameObject NbCarteJaune1;
    public GameObject NbCarteRouge1;
    public GameObject NbCarteVert1;
    public GameObject NbCarteBleu1;
    public GameObject NbCarteGuilde1;
    public GameObject NbCarteMarron1;
    public GameObject NbCarteGris1;

    public GameObject NbDefausseArgent;

    public List<GameObject> wondersPlayer1;
    public List<GameObject> wondersPlayer2;

    private Player player1;
    private Player player2;

    private void Start()
    {
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        _defausseZone = GameObject.FindGameObjectsWithTag("DefausseArgent");
        _playZoneJoueur1 = GameObject.FindGameObjectWithTag("PlayZone1");
        _playZoneJoueur2 = GameObject.FindGameObjectWithTag("PlayZone2");
        player1 = _playerManager.Player1;
        player2 = _playerManager.Player2;

        HideShowZonePlayable(false);
    }

    public void HideShowZonePlayable(bool show)
    {
        _playZoneJoueur1.SetActive(show);
        _playZoneJoueur2.SetActive(show);
        _defausseZone[0].SetActive(show);
        _defausseZone[1].SetActive(show);


        foreach (GameObject wonder in wondersPlayer1)
        {
            wonder.GetComponent<WonderCard>().getWonderEffect(false);
        }
        foreach (GameObject wonder in wondersPlayer2)
        {
            wonder.GetComponent<WonderCard>().getWonderEffect(false);
        }

        NbCarteJaune.GetComponent<Text>().text = player1.NbCarteJaune.ToString();
        NbCarteRouge.GetComponent<Text>().text = player1.NbCarteRouge.ToString();
        NbCarteVert.GetComponent<Text>().text = player1.NbCarteVerte.ToString();
        NbCarteBleu.GetComponent<Text>().text = player1.NbCarteBleu.ToString();
        NbCarteGuilde.GetComponent<Text>().text = player1.NbCarteGuilde.ToString();
        NbCarteMarron.GetComponent<Text>().text = player1.NbCarteMarron.ToString();
        NbCarteGris.GetComponent<Text>().text = player1.NbCarteGrise.ToString();

        NbCarteJaune1.GetComponent<Text>().text = player2.NbCarteJaune.ToString();
        NbCarteRouge1.GetComponent<Text>().text = player2.NbCarteRouge.ToString();
        NbCarteVert1.GetComponent<Text>().text = player2.NbCarteVerte.ToString();
        NbCarteBleu1.GetComponent<Text>().text = player2.NbCarteBleu.ToString();
        NbCarteGuilde1.GetComponent<Text>().text = player2.NbCarteGuilde.ToString();
        NbCarteMarron1.GetComponent<Text>().text = player2.NbCarteMarron.ToString();
        NbCarteGris1.GetComponent<Text>().text = player2.NbCarteGrise.ToString();
    }

    public void ShowZonePlayable(int coutCard, Player player)
    {
        _defausseZone[0].SetActive(true);
        _defausseZone[1].SetActive(true);
        NbDefausseArgent.GetComponent<Text>().text = (player.NbCarteJaune + 2).ToString();


        if (_playerManager.PlayerWhoPlay == 0)
        {
            foreach (GameObject wonder in wondersPlayer1)
            {
                wonder.GetComponent<WonderCard>().getWonderEffect(true);
            }
            _playZoneJoueur1.SetActive(true);
            _coutCardJoueur1.GetComponent<Text>().text = coutCard.ToString();
        }
        else
        {
            foreach (GameObject wonder in wondersPlayer2)
            {
                wonder.GetComponent<WonderCard>().getWonderEffect(true);
            }
            _playZoneJoueur2.SetActive(true);
            _coutCardJoueur2.GetComponent<Text>().text = coutCard.ToString();
        }
    }
}