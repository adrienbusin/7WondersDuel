using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressToken : MonoBehaviour
{
    
    private PlayerManager _playerManager;
    private Player _player;

    private ProgressTokenManager _progressTokenManager;
    private ProgressTokenManagerRestant _progressTokenManagerRestant;

    private void Start()
    {
        _progressTokenManager =
            GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<ProgressTokenManager>();
    }

    public void onClick()
    {
        if (TokenRestant)
        {
            _progressTokenManagerRestant = GameObject.FindGameObjectWithTag("ProgressManagerRestant")
                .GetComponent<ProgressTokenManagerRestant>();

            if (_progressTokenManagerRestant.TokenRestantChoosen.Count == 3 &&
                _progressTokenManagerRestant.TokenRestantChoosen.Contains(gameObject))
            {
                PlayToken();
                _progressTokenManagerRestant.HideAllTokens();
                GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                    .hideShowAllCards(true, true);
                _player.JetonRestant = false;
            }
            else
            {
                if (_progressTokenManagerRestant.TokenRestantChoosen.Count < 3 &&
                    !_progressTokenManagerRestant.TokenRestantChoosen.Contains(gameObject))
                {
                    gameObject.GetComponent<Image>().sprite = TokenFace;
                    _progressTokenManagerRestant.TokenRestantChoosen.Add(gameObject);
                }
            }
        }
        if (TokenPlayable)
        {
            PlayToken();
        }
    }

    private bool CheckIfStartAge()
    {
        switch (GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().AgeEnCours1)
        {
            case 2:
                return  GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().CheckIfStartAge2();
            case 3:
                return GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().CheckIfStartAge3();
        }
        return false;
    }

    private void PlayToken()
    {
        gameObject.SetActive(false);
        TokenPlayed = true;

        if (!TokenRestant)
        {
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(true, true);
            _progressTokenManager.setAllPlayableToken(false);
        }
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        _player = _playerManager.Player;

        switch (TokenValue)
        {
            case 0:
                //6 piece et 4PV
                _player.Argent += 6;
                _player.PointVictoire += 4;
                _player.NbTokenProgress += 1;
                _player.Bonus6Piece4PvToken = true;
                break;
            case 1:
                // ne paye plus les merveilles
                _player.ReductionMerveille = true;
                _player.NbTokenProgress += 1;
                break;
            case 2:
                //Economy
                _player.EconomyToken = true;
                _player.NbTokenProgress += 1;
                break;
            case 3:
                //loi
                _player.NbTokenProgress += 1;
                _player.TokenLoi = true;
                if (_player.NbScienceSymbole == 5)
                {
                    GameObject.FindGameObjectWithTag("ScienceManager").GetComponent<ScienceManager>()
                        .victoireScientifique(_player);
                }
                break;
            case 4:
                //Ne paye plus les bleu
                _player.ReductionCarteBleu = true;
                _player.NbTokenProgress += 1;
                break;
            case 5:
                //3PV par jeton progres
                _player.NbTokenProgress += 1;
                _player.Bonus3PVperToken = true;
                break;
            case 6:
                //7pV
                _player.NbTokenProgress += 1;
                _player.PointVictoire += 7;
                _player.Token7Pv = true;
                break;
            case 7:
                //Strategie militaire
                _player.NbTokenProgress += 1;
                _player.BonusMilitaireToken = true;
                break;
            case 8:
                //rejouer après chaque merveille
                _player.NbTokenProgress += 1;
                _player.BonusMerveilleReplayToken = true;
                break;
            case 9:
                // 6 piece, puis 4 piece par chainage
                _player.NbTokenProgress += 1;
                _player.BonusChainageToken = true;
                _player.Argent += 6;
                break;
        }
        _player.NewToken = gameObject;
        _player.SetText();
        _player.HasDoubleSymboleSciences = false;

        if (CheckIfStartAge())
        {
            SceneManager.LoadScene("SelectionAvatar");
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().NextPlayerEndAge();
        }else
        {
            _playerManager.nextPlayer(_player.PlayerNumber);
        }
    }


    public Sprite TokenFace { get; set; }

    public int TokenValue { private get; set; }

    public bool TokenPlayable { private get; set; }

    public bool TokenPlayed { get; private set; }

    public bool TokenRestant { private get; set; }
}