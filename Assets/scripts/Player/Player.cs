using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _playerNumber;
    public GameObject _playerNameTxt;

    private List<string> _symbolesScience = new List<string>();
    private List<string> _symbolesChainage = new List<string>();

    public bool hasDoubleSymboleSciences;

    public ProgressTokenManager ProgressTokenManager;

    private PlayerManager PlayerManager;
    public ScienceManager _scienceManager;

    private MilitaryManager pieceMilitaire;

    public Text argentText;
    public Text argileText;
    public Text pierreText;
    public Text boisText;
    public Text verreText;
    public Text papyrusText;
    public Text PointVictoireText;

    private int argent = 7;

    public List<GameObject> CarteViolet;
    public List<Sprite> CarteVioletImage;
    public List<GameObject> CarteJaune;
    public List<Sprite> CarteJauneImage;
    public List<GameObject> SymboleChainage;
    public List<Sprite> SymboleChainageImage;
    private int _nbJauneAffiche;
    private int _nbVioletAffiche;
    private int _nbSymboleChainage;


    private bool reductionBoisPierreArgileMerveille;
    private bool reductionVerrePapyrus;
    private bool reductionPapyrusVerreMerveille;
    private bool reductionPapyrusVerreCout1;

    //TOKEN
    public GameObject PT1;

    public GameObject PT2;
    public GameObject PT3;
    public GameObject PT4;
    public GameObject PT5;
    public GameObject PT6;


    private bool _chainageBaril;
    private bool _chainageCasque;
    private bool _chainageCible;
    private bool _chainageColonne;
    private bool _chainageHarpe;
    private bool _chainageLampe;
    private bool _chainageSoleil;
    private bool _chainageTemple;

    private bool _bonusMerveille2Pv;
    private bool _bonusCarteBleu1Pv;
    private bool _bonusCarteJaune1Pv;
    private bool _bonusCarteVerte1Pv;
    private bool _bonusArgent1Pv;
    private bool _bonusCarteGrisMarron1Pv;
    private bool _bonusCarteRouge1Pv;
    


    private void Start()
    {
        RessourcesSecondaireCard = new List<GameObject>();
        RessourcesPrimairesCard = new List<GameObject>();
        
        InitializeArgent();
        InitializeImage();

        PlayerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

        PlayerAdverse = PlayerNumber == 0
            ? PlayerManager.GetComponent<PlayerManager>().Player2.GetComponent<Player>()
            : PlayerManager.GetComponent<PlayerManager>().Player1.GetComponent<Player>();

        _scienceManager = GameObject.Find("ScienceManager").GetComponent<ScienceManager>();
        pieceMilitaire = GameObject.Find("MilitaryManager").GetComponent<MilitaryManager>();

        _playerNameTxt.GetComponent<Text>().text = PlayerName;
    }

    private void InitializeArgent()
    {
        argentText.text = Argent.ToString();
    }

    private void InitializeImage()
    {
        foreach (var c in CarteJaune)
        {
            c.SetActive(false);
        }
        foreach (var c in CarteViolet)
        {
            c.SetActive(false);
        }
        foreach (var c in SymboleChainage)
        {
            c.SetActive(false);
        }
    }


    //CARTE JAUNE
    private void AddCarteJaune(string reduction)
    {
        switch (reduction)
        {
            case "papyrus-verre-cout-1":
                reductionPapyrusVerreCout1 = true;
                CarteJaune[_nbJauneAffiche].SetActive(true);
                CarteJaune[_nbJauneAffiche].GetComponent<Image>().sprite = CarteJauneImage[0];
                _nbJauneAffiche++;
                break;
            case "argile":
                ReductionArgile = true;
                CarteJaune[_nbJauneAffiche].SetActive(true);
                CarteJaune[_nbJauneAffiche].GetComponent<Image>().sprite = CarteJauneImage[2];
                _nbJauneAffiche++;                
                break;
            case "bois":
                ReductionBois = true;
                CarteJaune[_nbJauneAffiche].SetActive(true);
                CarteJaune[_nbJauneAffiche].GetComponent<Image>().sprite = CarteJauneImage[3];
                _nbJauneAffiche++;
                break;
            case "pierre":
                ReductionPierre = true;
                CarteJaune[_nbJauneAffiche].SetActive(true);
                CarteJaune[_nbJauneAffiche].GetComponent<Image>().sprite = CarteJauneImage[4];
                _nbJauneAffiche++;
                break;
            case "bois-argile-pierre":
                ReductionBoisArgilePierre = true;
                CarteJaune[_nbJauneAffiche].SetActive(true);
                CarteJaune[_nbJauneAffiche].GetComponent<Image>().sprite = CarteJauneImage[1];
                _nbJauneAffiche++;
                break;
            case "verre-papyrus":
                reductionVerrePapyrus = true;
                CarteJaune[_nbJauneAffiche].SetActive(true);
                CarteJaune[_nbJauneAffiche].GetComponent<Image>().sprite = CarteJauneImage[5];
                _nbJauneAffiche++;
                break;
            case "papyrus-verre-merveille":
                reductionPapyrusVerreMerveille = true;
                break;
            case "bois-pierre-argile-merveille":
                reductionBoisPierreArgileMerveille = true;
                break;
        }
       
    }

    private void AddCarteViolet(string card)
    {
        CarteViolet[_nbVioletAffiche].SetActive(true);
        switch (card)
        {
            case "2pv/merveille":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[0];
                break;
            case "1argent+1pv/carteBleu":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[1];
                break;
            case "1argent+1pv/carteJaune":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[2];
                break;
            case "1pv/3Argent":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[3];
                break;
            case "1argent+1pv/carteVerte":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[4];
                break;
            case "1argent+1pv/carteGrise+carteMarron":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[5];
                break;
            case "1argent+1pv/carteRouge":
                CarteViolet[_nbVioletAffiche].GetComponent<Image>().sprite = CarteVioletImage[6];
                break;
        }
        _nbVioletAffiche++;
    }


    private void AddMerveille(string bonus, Card card)
    {
        NbMerveilles += 1;
        switch (bonus)
        {
            case "papyrus-verre-merveille":
                reductionPapyrusVerreMerveille = true;
                break;
            case "bois-pierre-argile-merveille":
                reductionBoisPierreArgileMerveille = true;
                break;
            case "delete1CarteGriseAdverse":
                if (PlayerAdverse.Papyrus != 0 || PlayerAdverse.Verre != 0)
                {
                    DestroyRessourceSecondaire = true;
                    GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                        .hideShowAllCards(false, true);
                    SceneManager.LoadScene("DestroyCard");
                }
                break;
            case "enlever3ArgentAdverse":
                PlayerAdverse.Argent += -3;
                break;
            case "choose1TokenProgressLet":
                if (!CheckIfEndAge(card))
                {
                    SceneManager.LoadScene("SelectionToken");
                    GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                        .hideShowAllCards(false, true);
                    HasDoubleSymboleSciences = true;
                }
                else
                {
                    JetonRestant = true;
                }
                break;
            case "choose1CardDefausse":
                if (!CheckIfEndAge(card))
                {
                    SceneManager.LoadScene("Defausse");
                    GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                        .hideShowAllCards(false, true);
                }
                Defausse = true;
                break;
            case "delete1CarteMarronAdverse":
                if (PlayerAdverse.Pierre != 0 || PlayerAdverse.Bois != 0 || PlayerAdverse.Argile != 0)
                {
                    DestroyRessourcePrimaire = true;
                    GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                        .hideShowAllCards(false, true);
                    SceneManager.LoadScene("DestroyCard");
                }
                break;
        }
    }

    private static bool CheckIfEndAge(Card card)
    {
        var cards = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().Cards;

        var card0 = cards[0].GetComponent<CardGame>();
        var card1 = cards[1].GetComponent<CardGame>();
        var card2 = cards[2].GetComponent<CardGame>();
        var card3 = cards[3].GetComponent<CardGame>();
        var card4 = cards[4].GetComponent<CardGame>();
        var card5 = cards[5].GetComponent<CardGame>();

        var ageEncCours = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().AgeEnCours1;
        switch (ageEncCours)
        {
            case 1:
                if (card.CardDropNumber == 0 && card1.CardPlayed || card.CardDropNumber == 1 && card0.CardPlayed)
                {
                    return true;
                }
                break;
            case 2:
                if (card.CardDropNumber == 0
                    && card1.CardPlayed
                    && card2.CardPlayed
                    && card3.CardPlayed
                    && card4.CardPlayed
                    && card5.CardPlayed
                    || card.CardDropNumber == 1
                    && card0.CardPlayed
                    && card2.CardPlayed
                    && card3.CardPlayed
                    && card4.CardPlayed
                    && card5.CardPlayed
                    || card.CardDropNumber == 2
                    && card0.CardPlayed
                    && card1.CardPlayed
                    && card3.CardPlayed
                    && card4.CardPlayed
                    && card5.CardPlayed
                    || card.CardDropNumber == 3
                    && card1.CardPlayed
                    && card2.CardPlayed
                    && card4.CardPlayed
                    && card5.CardPlayed
                    && card0.CardPlayed
                    || card.CardDropNumber == 4
                    && card0.CardPlayed
                    && card1.CardPlayed
                    && card2.CardPlayed
                    && card3.CardPlayed
                    && card5.CardPlayed
                    || card.CardDropNumber == 5
                    && card0.CardPlayed
                    && card1.CardPlayed
                    && card2.CardPlayed
                    && card3.CardPlayed
                    && card4.CardPlayed)
                {
                    return true;
                }
                break;
        }
        return false;
    }

    public int CoutTotalCarteDrop(Card card)
    {
        if (card.CoutChainage != null && _symbolesChainage.Contains(card.CoutChainage) ||
            Argile >= card.CoutArgile
            && Pierre >= card.CoutPierre
            && Bois >= card.CoutBois
            && Verre >= card.CoutVerre
            && Papyrus >= card.CoutPapyrus && card.CoutArgent == 0 || card.Defausse)
        {
            return 0;
        }
        return -CoutCarte(card);
    }

    public bool AddCarte(Card card)
    {
        //AS TOUS LES RESSOURCES
        if (!IsGratuitCard(card))
        {
            int coutTotal = CoutCarte(card);
            if (Argent >= coutTotal)
            {
                if (coutTotal > 0)
                {
                    GameObject.FindGameObjectWithTag("PieceOutAudio").GetComponent<AudioSource>().Play();
                }
                Argent = Argent - coutTotal;
                if (PlayerAdverse.EconomyToken)
                {
                    PlayerAdverse.Argent += coutTotal - card.CoutArgent;
                }
                GetBonusCard(card);
                return true;
            }
            // NE PEUX PAS PRENDRE LA CARTE
            return false;
        }
        return true;
    }

    private int CoutCarte(Card card)
    {
        float coutArgile = 0;
        float coutPierre = 0;
        float coutBois = 0;
        float coutVerre = 0;
        float coutPapyrus = 0;

        float coutArgileIntermediaire;
        float coutPierreIntermediaire;
        float coutBoisIntermediaire;
        float coutVerreIntermediaire;
        float coutPapyrusIntermediaire;

        float nbRessourcesManquanttes;

        // MANQUE ARGILE
        if (Argile < card.CoutArgile)
        {
            nbRessourcesManquanttes = card.CoutArgile - Argile;
            coutArgile = ReductionArgile
                ? nbRessourcesManquanttes
                : 2 * nbRessourcesManquanttes + PlayerAdverse.Argile * nbRessourcesManquanttes;
        }

        // MANQUE PIERRE 
        if (Pierre < card.CoutPierre)
        {
            nbRessourcesManquanttes = card.CoutPierre - Pierre;
            coutPierre = ReductionPierre
                ? nbRessourcesManquanttes
                : 2 * nbRessourcesManquanttes + PlayerAdverse.Pierre * nbRessourcesManquanttes;
        }

        // MANQUE BOIS
        if (Bois < card.CoutBois)
        {
            nbRessourcesManquanttes = card.CoutBois - Bois;
            coutBois = ReductionBois
                ? nbRessourcesManquanttes
                : 2 * nbRessourcesManquanttes + PlayerAdverse.Bois * nbRessourcesManquanttes;
        }

        // MANQUE VERRE
        if (Verre < card.CoutVerre)
        {
            nbRessourcesManquanttes = card.CoutVerre - Verre;
            coutVerre = reductionPapyrusVerreCout1
                ? nbRessourcesManquanttes
                : 2 * nbRessourcesManquanttes + PlayerAdverse.Verre * nbRessourcesManquanttes;
        }
        // MANQUE PAPYRUS
        if (Papyrus < card.CoutPapyrus)
        {
            nbRessourcesManquanttes = card.CoutPapyrus - Papyrus;
            coutPapyrus = reductionPapyrusVerreCout1
                ? nbRessourcesManquanttes
                : 2 * nbRessourcesManquanttes + PlayerAdverse.Papyrus * nbRessourcesManquanttes;
        }


        if (ReductionBoisArgilePierre)
        {
            float max;

            var coutBoitFlt = coutBois > 0 ? coutBois / card.CoutBois : coutBois;
            var coutArgileFlt = coutArgile > 0 ? coutArgile / card.CoutArgile : coutArgile;
            var coutPierreFlt = coutPierre > 0 ? coutPierre / card.CoutPierre : coutPierre;

            max = GetMaxCout3(coutBoitFlt, coutArgileFlt, coutPierreFlt);

            if (max == coutBoitFlt)
            {
                nbRessourcesManquanttes = card.CoutBois - Bois - 1;
                coutBoisIntermediaire = ReductionBois
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Bois * nbRessourcesManquanttes;
                coutBois = coutBoisIntermediaire < 0 ? 0 : coutBoisIntermediaire;
                card.CoutBois += -1;
            }
            else if (max == coutArgileFlt)
            {
                nbRessourcesManquanttes = card.CoutArgile - Argile - 1;
                coutArgileIntermediaire = ReductionArgile
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Argile * nbRessourcesManquanttes;
                coutArgile = coutArgileIntermediaire < 0 ? 0 : coutArgileIntermediaire;
                card.CoutArgile += -1;
            }
            else
            {
                nbRessourcesManquanttes = card.CoutPierre - Pierre - 1;
                coutPierreIntermediaire = ReductionPierre
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Pierre * nbRessourcesManquanttes;
                coutPierre = coutPierreIntermediaire < 0 ? 0 : coutPierreIntermediaire;
                card.CoutPierre += -1;
            }
        }

        if (reductionBoisPierreArgileMerveille)
        {
            float max;

            var coutBoitFlt = coutBois > 0 ? coutBois / card.CoutBois : coutBois;
            var coutArgileFlt = coutArgile > 0 ? coutArgile / card.CoutArgile : coutArgile;
            var coutPierreFlt = coutPierre > 0 ? coutPierre / card.CoutPierre : coutPierre;

            max = GetMaxCout3(coutBoitFlt, coutArgileFlt, coutPierreFlt);

            if (max == coutBoitFlt)
            {
                nbRessourcesManquanttes = card.CoutBois - Bois - 1;
                coutBoisIntermediaire = ReductionBois
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Bois * nbRessourcesManquanttes;
                coutBois = coutBoisIntermediaire < 0 ? 0 : coutBoisIntermediaire;
                card.CoutBois += -1;
            }
            else if (max == coutArgileFlt)
            {
                nbRessourcesManquanttes = card.CoutArgile - Argile - 1;
                coutArgileIntermediaire = ReductionArgile
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Argile * nbRessourcesManquanttes;
                coutArgile = coutArgileIntermediaire < 0 ? 0 : coutArgileIntermediaire;
                card.CoutArgile += -1;
            }
            else
            {
                nbRessourcesManquanttes = card.CoutPierre - Pierre - 1;
                coutPierreIntermediaire = ReductionPierre
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Pierre * nbRessourcesManquanttes;
                coutPierre = coutPierreIntermediaire < 0 ? 0 : coutPierreIntermediaire;
                card.CoutPierre += -1;
            }
        }

        if (reductionVerrePapyrus)
        {
            var coutVerreFlt = coutVerre > 0 ? coutVerre / card.CoutVerre : coutVerre;
            var coutpapyrusFlt = coutPapyrus > 0 ? coutPapyrus / card.CoutPapyrus : coutPapyrus;

            if (coutVerreFlt > coutpapyrusFlt)
            {
                nbRessourcesManquanttes = card.CoutVerre - Verre - 1;
                coutVerreIntermediaire = reductionPapyrusVerreCout1
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Verre * nbRessourcesManquanttes;
                coutVerre = coutVerreIntermediaire < 0 ? 0 : coutVerreIntermediaire;
                card.CoutVerre += -1;
            }
            else
            {
                nbRessourcesManquanttes = card.CoutPapyrus - Papyrus - 1;
                coutPapyrusIntermediaire = reductionPapyrusVerreCout1
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Papyrus * nbRessourcesManquanttes;
                coutPapyrus = coutPapyrusIntermediaire < 0 ? 0 : coutPapyrusIntermediaire;
                card.CoutPapyrus += -1;
            }
        }

        if (reductionPapyrusVerreMerveille)
        {
            var coutVerreFlt = coutVerre > 0 ? coutVerre / card.CoutVerre : coutVerre;
            var coutpapyrusFlt = coutPapyrus > 0 ? coutPapyrus / card.CoutPapyrus : coutPapyrus;

            if (coutVerreFlt > coutpapyrusFlt)
            {
                nbRessourcesManquanttes = card.CoutVerre - Verre - 1;
                coutVerreIntermediaire = reductionPapyrusVerreCout1
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Verre * nbRessourcesManquanttes;
                coutVerre = coutVerreIntermediaire < 0 ? 0 : coutVerreIntermediaire;
                card.CoutVerre += -1;
            }
            else
            {
                nbRessourcesManquanttes = card.CoutPapyrus - Papyrus - 1;
                coutPapyrusIntermediaire = reductionPapyrusVerreCout1
                    ? nbRessourcesManquanttes
                    : 2 * nbRessourcesManquanttes + PlayerAdverse.Papyrus * nbRessourcesManquanttes;
                coutPapyrus = coutPapyrusIntermediaire < 0 ? 0 : coutPapyrusIntermediaire;
                card.CoutPapyrus += -1;
            }
        }

        if (card.Color == "bleu" && ReductionCarteBleu || card.Merveille && ReductionMerveille)
        {
            for (var i = 0; i < 2; i++)
            {
                var coutBoitFlt = coutBois > 0 ? coutBois / card.CoutBois : coutBois;
                var coutArgileFlt = coutArgile > 0 ? coutArgile / card.CoutArgile : coutArgile;
                var coutPierreFlt = coutPierre > 0 ? coutPierre / card.CoutPierre : coutPierre;
                var coutVerreFlt = coutVerre > 0 ? coutVerre / card.CoutVerre : coutVerre;
                var coutpapyrusFlt = coutPapyrus > 0 ? coutPapyrus / card.CoutPapyrus : coutPapyrus;
                
                var max = GetMaxCout(coutBoitFlt, coutArgileFlt, coutPierreFlt, coutVerreFlt, coutpapyrusFlt);

                if (max == coutBoitFlt)
                {
                    nbRessourcesManquanttes = card.CoutBois - Bois - 1;
                    coutBoisIntermediaire = ReductionBois
                        ? nbRessourcesManquanttes
                        : 2 * nbRessourcesManquanttes + PlayerAdverse.Bois * nbRessourcesManquanttes;
                    coutBois = coutBoisIntermediaire < 0 ? 0 : coutBoisIntermediaire;
                    card.CoutBois += -1;
                }
                else if (max == coutArgileFlt)
                {
                    nbRessourcesManquanttes = card.CoutArgile - Argile - 1;
                    coutArgileIntermediaire = ReductionArgile
                        ? nbRessourcesManquanttes
                        : 2 * nbRessourcesManquanttes + PlayerAdverse.Argile * nbRessourcesManquanttes;
                    coutArgile = coutArgileIntermediaire < 0 ? 0 : coutArgileIntermediaire;
                    card.CoutArgile += -1;
                }
                else if (max == coutPierreFlt)
                {
                    nbRessourcesManquanttes = card.CoutPierre - Pierre - 1;
                    coutPierreIntermediaire = ReductionPierre
                        ? nbRessourcesManquanttes
                        : 2 * nbRessourcesManquanttes + PlayerAdverse.Pierre * nbRessourcesManquanttes;
                    coutPierre = coutPierreIntermediaire < 0 ? 0 : coutPierreIntermediaire;
                    card.CoutPierre += -1;
                }
                else if (max == coutVerreFlt)
                {
                    nbRessourcesManquanttes = card.CoutVerre - Verre - 1;
                    coutVerreIntermediaire = reductionPapyrusVerreCout1
                        ? nbRessourcesManquanttes
                        : 2 * nbRessourcesManquanttes + PlayerAdverse.Verre * nbRessourcesManquanttes;
                    coutVerre = coutVerreIntermediaire < 0 ? 0 : coutVerreIntermediaire;
                    card.CoutVerre += -1;
                }
                else
                {
                    nbRessourcesManquanttes = card.CoutPapyrus - Papyrus - 1;
                    coutPapyrusIntermediaire = reductionPapyrusVerreCout1
                        ? nbRessourcesManquanttes
                        : 2 * nbRessourcesManquanttes + PlayerAdverse.Papyrus * nbRessourcesManquanttes;
                    coutPapyrus = coutPapyrusIntermediaire < 0 ? 0 : coutPapyrusIntermediaire;
                    card.CoutPapyrus += -1;
                }
            }
        }


        return (int) (coutArgile + coutPierre + coutBois + coutVerre + coutPapyrus + card.CoutArgent);
    }

    private static float GetMaxCout(float coutPierre, float coutBois, float coutArgile, float coutVerre,
        float coutPapyrus)
    {
        return Math.Max(coutPapyrus, Math.Max(coutVerre, Math.Max(coutArgile, Math.Max(coutBois, coutPierre))));
    }

    private static float GetMaxCout3(float coutPierre, float coutBois, float coutArgile)
    {
        return Math.Max(coutArgile, Math.Max(coutBois, coutPierre));
    }


    private bool IsGratuitCard(Card card)
    {
        if (card.Defausse)
        {
            GetBonusCard(card);
            return true;
        }
        if (card.CoutChainage != null && _symbolesChainage.Contains(card.CoutChainage))
        {
            if (BonusChainageToken)
            {
                Argent += 4;
            }
            GetBonusCard(card);
            return true;
        }
        if (Argile >= card.CoutArgile
            && Pierre >= card.CoutPierre
            && Bois >= card.CoutBois
            && Verre >= card.CoutVerre
            && Papyrus >= card.CoutPapyrus)
        {
            if (card.CoutArgent == 0)
            {
                GetBonusCard(card);
                return true;
            }
            return false;
        }
        return false;
    }

    private void GetBonusCard(Card card)
    {
        if (BonusMilitaireToken && card.BonusMilitaire > 0 && !card.Merveille)
        {
            Militaire += card.BonusMilitaire + 1;
            pieceMilitaire.AddMilitaryPoint(this, card.BonusMilitaire + 1);
        }
        else
        {
            Militaire += card.BonusMilitaire;
            pieceMilitaire.AddMilitaryPoint(this, card.BonusMilitaire);
        }

        PointVictoire = PointVictoire + card.BonusVictoire;
        Argent = Argent + card.BonusArgent;
        if (card.BonusArgent > 0)
        {
            GameObject.FindGameObjectWithTag("PieceInAudio").GetComponent<AudioSource>().Play();
        }
        Argile = Argile + card.BonusArgile;
        Pierre = Pierre + card.BonusPierre;
        Bois = Bois + card.BonusBois;
        Verre = Verre + card.BonusVerre;
        Papyrus = Papyrus + card.BonusPapyrus;

        if (card.Merveille)
        {
            PointVictoireMerveille += card.BonusVictoire;
        }
        if (card.Guilde)
        {
            PointVictoireGuilde += card.BonusVictoire;
            NbCarteGuilde++;
        }

        switch (card.Color)
        {
            case "marron":
                NbCarteMarron++;
                RessourcesPrimairesCard.Add(card.CardGame);
                break;
            case "gris":
                NbCarteGrise++;
                RessourcesSecondaireCard.Add(card.CardGame);
                break;
            case "rouge":
                NbCarteRouge++;
                break;
            case "jaune":
                PointVictoireCarteJaune += card.BonusVictoire;
                NbCarteJaune++;
                AddCarteJaune(card.Reduction);
                break;
            case "vert":
                PointVictoireCarteVert += card.BonusVictoire;
                NbCarteVerte++;
                _scienceManager.GetComponent<ScienceManager>().setSymbole(card.SymboleScientifique, this);
                break;
            case "bleu":
                PointVictoireCarteBleu += card.BonusVictoire;
                NbCarteBleu++;
                break;
            case "violet":
                AddCarteViolet(card.BonusSpecial);
                break;
        }

        switch (card.BonusSpecial)
        {
            //CARTE AGE 3
            case "2argent/merveille":
                Argent += 2 * NbMerveilles;
                break;
            case "1argent/carteRouge":
                Argent += 1 * NbCarteRouge;
                break;
            case "3argent/carteGrise":
                Argent += 3 * NbCarteGrise;
                break;
            case "1argent/carteJaune":
                Argent += 1 * NbCarteJaune;
                break;
            case "2argent/carteMarron":
                Argent += 2 * NbCarteMarron;
                break;

            //FIN DU JEU
            case "2pv/merveille":
                _bonusMerveille2Pv = true;
                break;
            case "1argent+1pv/carteBleu":
                Argent += Math.Max(NbCarteBleu, PlayerAdverse.NbCarteBleu);
                _bonusCarteBleu1Pv = true;
                break;
            case "1argent+1pv/carteJaune":
                Argent += Math.Max(NbCarteJaune, PlayerAdverse.NbCarteJaune);
                _bonusCarteJaune1Pv = true;
                break;
            case "1pv/3Argent":
                _bonusArgent1Pv = true;
                break;
            case "1argent+1pv/carteVerte":
                _bonusCarteVerte1Pv = true;
                Argent += Math.Max(NbCarteVerte, PlayerAdverse.NbCarteVerte);
                break;
            case "1argent+1pv/carteGrise+carteMarron":
                _bonusCarteGrisMarron1Pv = true;
                Argent += Math.Max(NbCarteMarron + NbCarteGrise,
                    PlayerAdverse.NbCarteMarron + PlayerAdverse.NbCarteGrise);
                break;
            case "1argent+1pv/carteRouge":
                _bonusCarteRouge1Pv = true;
                Argent += Math.Max(NbCarteRouge, PlayerAdverse.NbCarteRouge);
                break;
        }


        if (card.SymboleChainage != "NONE")
        {
            AddSymboleChainage(card.SymboleChainage);
        }
        if (card.Merveille)
        {
            AddMerveille(card.BonusSpecial, card);
            if (BonusMerveilleReplayToken)
            {
                card.Replay = true;
            }
        }

        if (!card.Replay && !HasDoubleSymboleSciences && !DestroyRessourcePrimaire && !DestroyRessourceSecondaire)
        {
            IsPlaying = false;
            PlayerAdverse.IsPlaying = true;
        }
        else
        {
            IsPlaying = true;
            PlayerAdverse.IsPlaying = false;
        }
    }


    public void CountLastPoint()
    {
        if (_bonusMerveille2Pv)
        {
            PointVictoire += 2 * Math.Max(NbMerveilles, PlayerAdverse.NbMerveilles);
            PointVictoireGuilde += 2 * Math.Max(NbMerveilles, PlayerAdverse.NbMerveilles);
        }
        if (_bonusCarteBleu1Pv)
        {
            PointVictoire += Math.Max(NbCarteBleu, PlayerAdverse.NbCarteBleu);
            PointVictoireGuilde += Math.Max(NbCarteBleu, PlayerAdverse.NbCarteBleu);
        }
        if (_bonusCarteJaune1Pv)
        {
            PointVictoire += Math.Max(NbCarteJaune, PlayerAdverse.NbCarteJaune);
            PointVictoireGuilde += Math.Max(NbCarteJaune, PlayerAdverse.NbCarteJaune);
        }
        if (_bonusArgent1Pv)
        {
            PointVictoire += Math.Max((int) Math.Floor((float) Argent / 3),
                (int) Math.Floor((float) PlayerAdverse.Argent / 3));
            PointVictoireGuilde += Math.Max((int) Math.Floor((float) Argent / 3),
                (int) Math.Floor((float) PlayerAdverse.Argent / 3));
        }
        if (_bonusCarteVerte1Pv)
        {
            PointVictoire += Math.Max(NbCarteVerte, PlayerAdverse.NbCarteVerte);
            PointVictoireGuilde += Math.Max(NbCarteVerte, PlayerAdverse.NbCarteVerte);
        }
        if (_bonusCarteGrisMarron1Pv)
        {
            PointVictoire += Math.Max(NbCarteMarron + NbCarteGrise,
                PlayerAdverse.NbCarteMarron + PlayerAdverse.NbCarteGrise);
            PointVictoireGuilde += Math.Max(NbCarteMarron + NbCarteGrise,
                PlayerAdverse.NbCarteMarron + PlayerAdverse.NbCarteGrise);
        }
        if (_bonusCarteRouge1Pv)
        {
            PointVictoire += Math.Max(NbCarteRouge, PlayerAdverse.NbCarteRouge);
            PointVictoireGuilde += Math.Max(NbCarteRouge, PlayerAdverse.NbCarteRouge);
        }

        if (Bonus3PVperToken)
        {
            PointVictoire += NbTokenProgress * 3;
            PointVictoireToken += NbTokenProgress * 3;
        }
        if (Token7Pv)
        {
            PointVictoireToken += 7;
        }
        if (Bonus6Piece4PvToken)
        {
            PointVictoireToken += 4;
        }

        PointVictoire += (int) Math.Floor((float) Argent / 3);
        PointVictoirePiece += (int) Math.Floor((float) Argent / 3);

        PointVictoireMilitaire = PointMilitaire();

        SetText();
    }

    private int PointMilitaire()
    {
        if (Have10VictoryPointMilitary)
        {
            return 10;
        }
        if (Have5VictoryPointMilitary)
        {
            return 5;
        }
        if (Have2VictoryPointMilitary)
        {
            return 2;
        }
        return 0;
    }

    //CHAINAGE
    private void AddChainageImage(string chainage)
    {
 
        switch (chainage)
        {
            case "engrenage":
                ChainageEngrenage = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);

                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[4];   
                _nbSymboleChainage++;

                break;
            case "epee":
                ChainageEpee = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[5];   
                _nbSymboleChainage++;

                break;
            case "ferACheval":
                ChainageFerACheval = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[6];   
                _nbSymboleChainage++;

                break;
            case "goutte":
                ChainageGoutte = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[7];  
                _nbSymboleChainage++;

                break;
            case "jare":
                ChainageJare = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[9];  
                _nbSymboleChainage++;

                break;
            case "livre":
                ChainageLivre = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[11];  
                _nbSymboleChainage++;

                break;
            case "lune":
                ChainageLune = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[12]; 
                _nbSymboleChainage++;

                break;
            case "masque":
                ChainageMasque = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[13];   
                _nbSymboleChainage++;

                break;
            case "tour":
                ChainageTour = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[16];    
                _nbSymboleChainage++;

                break;
            case "baril":
                _chainageBaril = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[0];  
                _nbSymboleChainage++;

                break;
            case "casque":
                _chainageCasque = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[1];  
                _nbSymboleChainage++;

                break;
            case "cible":
                _chainageCible = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[2];  
                _nbSymboleChainage++;

                break;
            case "colonne":
                _chainageColonne = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[3];  
                _nbSymboleChainage++;

                break;
            case "harpe":
                _chainageHarpe = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[8];  
                _nbSymboleChainage++;

                break;
            case "lampe":
                _chainageLampe = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[10]; 
                _nbSymboleChainage++;

                break;
            case "soleil":
                _chainageSoleil = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[14]; 
                _nbSymboleChainage++;

                break;
            case "temple":
                _chainageTemple = true;
                SymboleChainage[_nbSymboleChainage].SetActive(true);
                SymboleChainage[_nbSymboleChainage].GetComponent<Image>().sprite = SymboleChainageImage[15];    
                _nbSymboleChainage++;

                break;
        }
    }

    //SCIENCE
    public void AddSymboleScience(string symbole)
    {
        if (!HasAlreadySymboleScience(symbole))
        {
            _symbolesScience.Add(symbole);
            NbScienceSymbole = NbScienceSymbole + 1;
        }
        else
        {
            ProgressTokenManager.setAllPlayableToken(true);
        }
    }

    public bool HasAlreadySymboleScience(string symbole)
    {
        return _symbolesScience.Count > 0 && _symbolesScience.Any(t => t.Equals(symbole));
    }

    public int IndexSymboleScience(string symbole)
    {
        for (var i = 0; i < _symbolesScience.Count; i++)
        {
            if (_symbolesScience[i].Equals(symbole))
            {
                return i;
            }
        }
        return 0;
    }

    //CHAINAGE
    private void AddSymboleChainage(string symbole)
    {
        _symbolesChainage.Add(symbole);
        NbChainageSymbole = NbChainageSymbole + 1;
        AddChainageImage(symbole);
    }

    public void SetText()
    {
        argentText.text = Argent.ToString();
        argileText.text = Argile.ToString();
        pierreText.text = Pierre.ToString();
        boisText.text = Bois.ToString();
        verreText.text = Verre.ToString();
        papyrusText.text = Papyrus.ToString();
        PointVictoireText.text = PointVictoire.ToString();

        PlayerAdverse.argentText.text = PlayerAdverse.Argent.ToString();
        PlayerAdverse.argileText.text = PlayerAdverse.Argile.ToString();
        PlayerAdverse.pierreText.text = PlayerAdverse.Pierre.ToString();
        PlayerAdverse.boisText.text = PlayerAdverse.Bois.ToString();
        PlayerAdverse.verreText.text = PlayerAdverse.Verre.ToString();
        PlayerAdverse.papyrusText.text = PlayerAdverse.Papyrus.ToString();
        PlayerAdverse.PointVictoireText.text = PlayerAdverse.PointVictoire.ToString();
    }

    //GETTER AND SETTER

    public bool HasDoubleSymboleSciences
    {
        get { return hasDoubleSymboleSciences; }
        set { hasDoubleSymboleSciences = value; }
    }

    public int Argent
    {
        get { return argent; }
        set
        {
            argent = value;
            argent = argent < 0 ? 0 : argent;
        }
    }

    public int Bois { get; set; }


    public int Argile { get; set; }


    public int Pierre { get; set; }


    public int Papyrus { get; set; }

    public int Verre { get; set; }

    public int Militaire { get; set; }

    public GameObject NewToken
    {
        set
        {
            switch (NbTokenProgress)
            {
                case 1:
                    PT1.GetComponent<Image>().sprite = value.GetComponent<Image>().sprite;
                    PT1.SetActive(true);
                    break;
                case 2:
                    PT2.GetComponent<Image>().sprite = value.GetComponent<Image>().sprite;
                    PT2.SetActive(true);
                    break;
                case 3:
                    PT3.GetComponent<Image>().sprite = value.GetComponent<Image>().sprite;
                    PT3.SetActive(true);
                    break;
                case 4:
                    PT4.GetComponent<Image>().sprite = value.GetComponent<Image>().sprite;
                    PT4.SetActive(true);
                    break;
                case 5:
                    PT5.GetComponent<Image>().sprite = value.GetComponent<Image>().sprite;
                    PT5.SetActive(true);
                    break;
                case 6:
                    PT6.GetComponent<Image>().sprite = value.GetComponent<Image>().sprite;
                    PT6.SetActive(true);
                    break;
            }
        }
    }

    public Player PlayerAdverse { get; set; }

    public bool AlreadyLoose2ArgentMilitary { get; set; }

    public bool AlreadyLoose5ArgentMilitary { get; set; }

    public bool Have2VictoryPointMilitary { get; set; }

    public bool Have5VictoryPointMilitary { get; set; }

    public bool Have10VictoryPointMilitary { get; set; }

    public int PointVictoire { get; set; }

    public int PlayerNumber
    {
        get { return _playerNumber; }
    }

    private bool ReductionArgile { get; set; }

    private bool ReductionBois { get; set; }

    private bool ReductionPierre { get; set; }

    public bool ReductionMerveille { get; set; }

    public bool EconomyToken { get; set; }

    public bool ReductionCarteBleu { get; set; }

    public bool Bonus3PVperToken { get; set; }

    public bool BonusMilitaireToken { get; set; }

    public bool BonusMerveilleReplayToken { get; set; }

    public bool BonusChainageToken { get; set; }

    public bool Bonus6Piece4PvToken { get; set; }

    public bool TokenLoi { get; set; }

    public bool Token7Pv { get; set; }

    public bool IsPlaying { get; set; }

    private bool ChainageEngrenage { get; set; }

    private bool ChainageEpee { get; set; }

    private bool ChainageFerACheval { get; set; }

    private bool ChainageGoutte { get; set; }

    private bool ChainageJare { get; set; }

    private bool ChainageLivre { get; set; }

    private bool ChainageLune { get; set; }

    private bool ChainageMasque { get; set; }

    private bool ChainageTour { get; set; }

    private bool ReductionBoisArgilePierre { get; set; }

    public int NbScienceSymbole { get; set; }

    public int NbCarteJaune { get; set; }

    public int NbTokenProgress { get; set; }

    private int NbChainageSymbole { get; set; }

    private int NbMerveilles { get; set; }

    public int NbCarteMarron { get; set; }

    public int NbCarteRouge { get; set; }

    public int NbCarteGrise { get; set; }

    public int NbCarteVerte { get; set; }

    public int NbCarteBleu { get; set; }

    public int NbCarteGuilde { get; set; }

    public int PointVictoireCarteBleu { get; set; }

    public int PointVictoireCarteVert { get; set; }

    public int PointVictoireCarteJaune { get; set; }

    public int PointVictoireMerveille { get; set; }

    public int PointVictoirePiece { get; set; }

    public int PointVictoireMilitaire { get; set; }

    public bool VictoireScientifique { get; set; }

    public bool VictoireMilitaire { get; set; }

    public int PointVictoireGuilde { get; set; }

    public string PlayerName { get; set; }

    public int PointVictoireToken { get; set; }

    public bool DestroyRessourcePrimaire { get; set; }

    public bool DestroyRessourceSecondaire { get; set; }

    public bool IsSelectedToPlayFirst { get; set; }

    public bool Defausse { get; set; }

    public bool JetonRestant { get; set; }

    public List<GameObject> RessourcesPrimairesCard { get; set; }

    public List<GameObject> RessourcesSecondaireCard { get; set; }
}