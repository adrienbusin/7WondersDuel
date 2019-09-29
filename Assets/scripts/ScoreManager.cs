using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private PlayerManager _playerManager;

    public GameObject PlayerName1;
    public GameObject PlayerName2;

    public GameObject ScoreCarteBleu1;
    public GameObject ScoreCarteBleu2;

    public GameObject ScoreCarteVert1;
    public GameObject ScoreCarteVert2;

    public GameObject ScoreCarteJaune1;
    public GameObject ScoreCarteJaune2;

    public GameObject ScoreCarteViolet1;
    public GameObject ScoreCarteViolet2;

    public GameObject ScoreCarteMerveille1;
    public GameObject ScoreCarteMerveille2;

    public GameObject ScoreCarteJeton1;
    public GameObject ScoreCarteJeton2;

    public GameObject ScoreCartePiece1;
    public GameObject ScoreCartePiece2;

    public GameObject ScoreCarteMilitaire1;
    public GameObject ScoreCarteMilitaire2;

    public GameObject ScoreJoueur1;
    public GameObject ScoreJoueur2;
    
    public GameObject ScoreBoard2;
    public Sprite ImageBoard;

    private Player _player1;
    private Player _player2;
    private Player _winner;
    private Player _looser;
    
    private void Start()
    {
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        _player1 = _playerManager.Player1.GetComponent<Player>();
        _player2 = _playerManager.Player2.GetComponent<Player>();
        
        Winner();

        PlayerName1.GetComponent<Text>().text = _winner.PlayerName;
        ScoreCarteBleu1.GetComponent<Text>().text = _winner.PointVictoireCarteBleu.ToString();
        ScoreCarteVert1.GetComponent<Text>().text = _winner.PointVictoireCarteVert.ToString();
        ScoreCarteJaune1.GetComponent<Text>().text = _winner.PointVictoireCarteJaune.ToString();
        ScoreCarteViolet1.GetComponent<Text>().text = _winner.PointVictoireGuilde.ToString();
        ScoreCarteMerveille1.GetComponent<Text>().text = _winner.PointVictoireMerveille.ToString();
        ScoreCarteJeton1.GetComponent<Text>().text = _winner.PointVictoireToken.ToString();
        ScoreCartePiece1.GetComponent<Text>().text = _winner.PointVictoirePiece.ToString();
        ScoreCarteMilitaire1.GetComponent<Text>().text = _winner.PointVictoireMilitaire.ToString();
        ScoreJoueur1.GetComponent<Text>().text = _winner.PointVictoire.ToString();


        PlayerName2.GetComponent<Text>().text = _looser.PlayerName;
        ScoreCarteBleu2.GetComponent<Text>().text = _looser.PointVictoireCarteBleu.ToString();
        ScoreCarteVert2.GetComponent<Text>().text = _looser.PointVictoireCarteVert.ToString();
        ScoreCarteJaune2.GetComponent<Text>().text = _looser.PointVictoireCarteJaune.ToString();
        ScoreCarteViolet2.GetComponent<Text>().text = _looser.PointVictoireGuilde.ToString();
        ScoreCarteMerveille2.GetComponent<Text>().text = _looser.PointVictoireMerveille.ToString();
        ScoreCarteJeton2.GetComponent<Text>().text = _looser.PointVictoireToken.ToString();
        ScoreCartePiece2.GetComponent<Text>().text = _looser.PointVictoirePiece.ToString();
        ScoreCarteMilitaire2.GetComponent<Text>().text = _looser.PointVictoireMilitaire.ToString();
        ScoreJoueur2.GetComponent<Text>().text = _looser.PointVictoire.ToString();
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Winner()
    {
        if (_player1.VictoireMilitaire || _player1.VictoireScientifique)
        {
            // PLAYER 1 WIN 
            _winner = _player1;
            _looser = _player2;
            return;
        }
        
        if (_player2.VictoireMilitaire || _player2.VictoireScientifique)
        {
            _winner = _player2;
            _looser = _player1;
            return;
        }

        if (_player1.PointVictoire > _player2.PointVictoire)
        {
            // PLAYER 1 WIN 
            _winner = _player1;
            _looser = _player2;
            return;
        }

        if (_player1.PointVictoire < _player2.PointVictoire)
        {
            // PLAYER 2 WIN 
            _winner = _player2;
            _looser = _player1;
            return;
        }
        
        if (_player1.PointVictoireCarteBleu > _player2.PointVictoireCarteBleu)
        {
            // PLAYER 1 WIN 
            _winner = _player1;
            _looser = _player2;
            return;
        }
        
        if (_player1.PointVictoireCarteBleu < _player2.PointVictoireCarteBleu)
        {
            // PLAYER 2 WIN 
            _winner = _player2;
            _looser = _player1;
        }

        _winner = _player1;
        _looser = _player2;
        ScoreBoard2.GetComponent<Image>().sprite = ImageBoard;

    }
}