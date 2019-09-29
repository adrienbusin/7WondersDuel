using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private List<Sprite> _cardFace;
    private List<Sprite> _cardFaceGuilde;
    private List<Sprite> _tmpCardFace;
    private List<Sprite> _tmpCardFaceGuilde;
    private Sprite _cardBack;
    private Sprite _cardBackGuilde;
    public int AgeEnCours;

    public CarteFaceManager CarteFaceManager;
    private PlayerManager PlayerManager;
    private ZonePlayableManager _zonePlayableManager;
    private GameObject _defausseZone;
    private GameObject _playZoneJoueur1;
    private GameObject _playZoneJoueur2;

    void Start()
    {
        _cardFace = CarteFaceManager.GetComponent<CarteFaceManager>().CardFace;
        _cardBack = CarteFaceManager.GetComponent<CarteFaceManager>().CardBack;
        Cards = CarteFaceManager.GetComponent<CarteFaceManager>().Cards;
        PlayerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
//        instructionText = GameObject.FindGameObjectWithTag("InstructionText");
        
        _zonePlayableManager =
            GameObject.FindGameObjectWithTag("ZonePlayableManager").GetComponent<ZonePlayableManager>();

        if (AgeEnCours == 3)
        {
            _cardBackGuilde = CarteFaceManager.GetComponent<CarteFaceManager>().CardBackGuildes;
            _cardFaceGuilde = CarteFaceManager.GetComponent<CarteFaceManager>().CardFaceGuildes;
            ShuffleCardFace();
            InitializeCardsAge3();
        }
        else
        {
            ShuffleCardFace();
            InitializeCards();
        }

        if (AgeEnCours != 2 && AgeEnCours != 3) return;
        if (PlayerManager.Player.DestroyRessourcePrimaire ||
            PlayerManager.Player.DestroyRessourceSecondaire || PlayerManager.Player.Defausse|| PlayerManager.Player.JetonRestant)
        {
            if (PlayerManager.Player.Defausse)
            {
                SceneManager.LoadScene("Defausse");
            }
            if (PlayerManager.Player.JetonRestant)
            {
                SceneManager.LoadScene("SelectionToken");
            }
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(false, true);
        }
        else
        {
            NextPlayerEndAge();
            SceneManager.LoadScene("SelectionAvatar"); 
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(false, true);
        }
    }


    public void CheckIsPlayable(int ageEnCours, GameObject cardEffectAge)
    {
        if (ageEnCours == 1)
        {
            cardEffectAge.GetComponent<CardEffectAge1>().checkCardPlayable(Cards);
        }
        else if (ageEnCours == 2)
        {
            cardEffectAge.GetComponent<CardEffectAge2>().checkCardPlayable(Cards);
        }
        else
        {
            CardEffectAge3.CheckCardPlayable(Cards);
        }
    }

    private void ShuffleCardFace()
    {
        _tmpCardFace = new List<Sprite>(_cardFace);
        for (int i = 0; i < _tmpCardFace.Count; i++)
        {
            Sprite temp = _tmpCardFace[i];
            int randomIndex = Random.Range(i, _tmpCardFace.Count);
            _tmpCardFace[i] = _tmpCardFace[randomIndex];
            _tmpCardFace[randomIndex] = temp;
        }

        //SHUFFLE GUILDE CARD
        if (AgeEnCours == 3)
        {
            _tmpCardFaceGuilde = new List<Sprite>(_cardFaceGuilde);
            for (int i = 0; i < _tmpCardFaceGuilde.Count; i++)
            {
                Sprite temp = _tmpCardFaceGuilde[i];
                int randomIndex = Random.Range(i, _tmpCardFaceGuilde.Count);
                _tmpCardFaceGuilde[i] = _tmpCardFaceGuilde[randomIndex];
                _tmpCardFaceGuilde[randomIndex] = temp;
            }
        }
    }

    private void InitializeCards()
    {
        for (var i = 0; i < 20; i++)
        {
            Sprite card = GetCardFace(i);
            for (var j = 0; j < 23; j++)
            {
                if (_cardFace[j] == card)
                {
                    Cards[i].GetComponent<CardGame>().CardValue = j;
                }
            }

            Cards[i].GetComponent<CardGame>().CardFace = card;
            Cards[i].GetComponent<CardGame>().CardDropNumber = i;
            Cards[i].GetComponent<CardGame>().CardBack = GetCardBack();
            Cards[i].GetComponent<Image>().sprite = Cards[i].GetComponent<CardGame>().CardState == 1 ? Cards[i].GetComponent<CardGame>().CardFace : Cards[i].GetComponent<CardGame>().CardBack;
        }
    }

    void InitializeCardsAge3()
    {
        var indexFirstGuilde = 0;
        var indexSecondGuilde = 0;
        var indexThirdGuilde = 0;
        while (indexFirstGuilde == indexSecondGuilde && indexFirstGuilde == indexThirdGuilde &&
               indexSecondGuilde == indexThirdGuilde)
        {
            indexFirstGuilde = Random.Range(0, Cards.Count);
            indexSecondGuilde = Random.Range(0, Cards.Count);
            indexThirdGuilde = Random.Range(0, Cards.Count);
        }

        for (var i = 0; i < 20; i++)
        {
            Sprite card;
            if (i == indexFirstGuilde)
            {
                card = GetCardFaceGuilde(0);
                GetCardGuildFace(i, card);
            }
            else if (i == indexSecondGuilde)
            {
                card = GetCardFaceGuilde(1);
                GetCardGuildFace(i, card);
            }
            else if (i == indexThirdGuilde)
            {
                card = GetCardFaceGuilde(2);
                GetCardGuildFace(i, card);
            }
            else
            {
                card = GetCardFace(i);
                for (var j = 0; j < 20; j++)
                {
                    if (_cardFace[j] == card)
                    {
                        Cards[i].GetComponent<CardGame>().CardValue = j;
                    }
                }
                Cards[i].GetComponent<CardGame>().CardBack = GetCardBack();
            }
            Cards[i].GetComponent<CardGame>().CardFace = card;


            Cards[i].GetComponent<Image>().sprite = Cards[i].GetComponent<CardGame>().CardState == 1 ? Cards[i].GetComponent<CardGame>().CardFace : Cards[i].GetComponent<CardGame>().CardBack;
        }
    }

    private void GetCardGuildFace(int i, Sprite card)
    {
        Cards[i].GetComponent<CardGame>().Guilde = true;
        Cards[i].GetComponent<CardGame>().CardBack = GetCardBackGuilde();
        for (var j = 0; j < 7; j++)
        {
            if (_cardFaceGuilde[j] == card)
            {
                Cards[i].GetComponent<CardGame>().CardValue = j;
            }
        }
    }

    private Sprite GetCardBack()
    {
        return _cardBack;
    }

    private Sprite GetCardBackGuilde()
    {
        return _cardBackGuilde;
    }

    private Sprite GetCardFace(int indexCarteFace)
    {
        return _tmpCardFace[indexCarteFace];
    }

    private Sprite GetCardFaceGuilde(int indexCarteFaceGuilde)
    {
        return _tmpCardFaceGuilde[indexCarteFaceGuilde];
    }


    public void NextPlayerEndAge()
    {
        _zonePlayableManager.HideShowZonePlayable(false);
        if (!PlayerManager.Player.DestroyRessourcePrimaire && !PlayerManager.Player.DestroyRessourceSecondaire)
        {
            var militairePlayer1 = PlayerManager.Player1.Militaire;
            var militairePlayer2 = PlayerManager.Player2.Militaire;

            if (militairePlayer1 > militairePlayer2)
            {
                PlayerManager.Player1.IsPlaying = false;
                PlayerManager.Player2.IsPlaying = true;
                PlayerManager.nextPlayer(0);
            }
            if (militairePlayer2 > militairePlayer1)
            {
                PlayerManager.Player1.IsPlaying = true;
                PlayerManager.Player2.IsPlaying = false;
                PlayerManager.nextPlayer(1);
            }

            if (militairePlayer1 != militairePlayer2) return;
            PlayerManager.GetComponent<PlayerManager>().Player.IsPlaying = true;
            PlayerManager.GetComponent<PlayerManager>().Player.PlayerAdverse.IsPlaying = false;
            PlayerManager.nextPlayer(PlayerManager.Player.PlayerAdverse.PlayerNumber);
            PlayerManager.Player.IsSelectedToPlayFirst = true;
            PlayerManager.Player.PlayerAdverse.IsSelectedToPlayFirst = true;
        }
        else
        {
            PlayerManager.Player.IsPlaying = true;
            PlayerManager.Player.PlayerAdverse.IsPlaying = false;
            PlayerManager.nextPlayer(PlayerManager.Player.PlayerAdverse.PlayerNumber);
        }
    }

    public bool CheckIfEndAge1()
    {
        if (!Cards[0].GetComponent<CardGame>().CardPlayed || !Cards[1].GetComponent<CardGame>().CardPlayed
        ) return false;
        Destroy(GameObject.FindGameObjectWithTag("Manager"));
        Destroy(GameObject.FindGameObjectWithTag("DestroyEndAge"));
        Destroy(GameObject.FindGameObjectWithTag("hideShowAllCards"));
        GameObject.FindGameObjectWithTag("BackgroundManager").GetComponent<BackgroundManager>().changeBackground(2);
        PlayerManager.HasSelectPlayerStartAge = false;
        SceneManager.LoadScene("age2");
        return true;
    }

    public bool CheckIfEndAge2()
    {
        if (!Cards[0].GetComponent<CardGame>().CardPlayed || !Cards[1].GetComponent<CardGame>().CardPlayed ||
            !Cards[2].GetComponent<CardGame>().CardPlayed || !Cards[3].GetComponent<CardGame>().CardPlayed ||
            !Cards[4].GetComponent<CardGame>().CardPlayed ||
            !Cards[5].GetComponent<CardGame>().CardPlayed) return false;
        Destroy(GameObject.FindGameObjectWithTag("Manager"));
        Destroy(GameObject.FindGameObjectWithTag("DestroyEndAge"));
        Destroy(GameObject.FindGameObjectWithTag("hideShowAllCards"));
        GameObject.FindGameObjectWithTag("BackgroundManager").GetComponent<BackgroundManager>().changeBackground(3);
        PlayerManager.HasSelectPlayerStartAge = false;
        SceneManager.LoadScene("age3");
        return true;
    }

    public bool CheckIfStartAge2()
    {
        return !Cards[19].GetComponent<CardGame>().CardPlayed && !Cards[18].GetComponent<CardGame>().CardPlayed;
    }
    public bool CheckIfStartAge3()
    {
        return !Cards[19].GetComponent<CardGame>().CardPlayed && !Cards[18].GetComponent<CardGame>().CardPlayed;
    } 

    public bool CheckIfEndAge3()
    {
        if (!Cards[0].GetComponent<CardGame>().CardPlayed || !Cards[1].GetComponent<CardGame>().CardPlayed
        ) return false;
        GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
            .hideShowAllCards(false, false);

        /*Dans le cas où les deux joueurs sont à égalité, le joueur qui totalise le plus de
            points de victoire sur ses Bâtiments civils (cartes bleues) remporte la partie.
                Une nouvelle égalité n’est pas départagée et lesjoueurs se partagent la victoire.
                */

        PlayerManager.Player1.CountLastPoint();
        PlayerManager.Player2.CountLastPoint();
        PlayerManager.HasSelectPlayerStartAge = false;
        SceneManager.LoadScene("Score");
        return true;
    }

//    public String InstructionText
//    {
//        get { return instructionText.GetComponent<Text>().text; }
//        set { instructionText.GetComponent<Text>().text = value; }
//    }
//
//    public bool InstructionTextShow
//    {
//        set { instructionText.SetActive(value); }
//    }

    public int AgeEnCours1
    {
        get { return AgeEnCours; }
    }

    public List<GameObject> Cards { get; set; }
}