using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffectAge1 : MonoBehaviour
{
 
    private WonderManager _wonderManager;
    public List<GameObject> Wonders;

    private void Start()
    {
        _wonderManager = GameObject.FindGameObjectWithTag("WonderManager").GetComponent<WonderManager>();
        initializeMerveilles();
    }

    void initializeMerveilles()
    {
        setWonder();
    }

    void setWonder()
    {
        for (int i = 0; i < 8; i++)
        {
            WonderCard ob = _wonderManager.MerveillesSelected[i];
            Wonders[i].GetComponent<WonderCard>().cardValue = ob.cardValue;
            Wonders[i].GetComponent<Image>().sprite = ob.cardFace;
            Wonders[i].SetActive(true);
        }
    }


    public void checkCardPlayable(List<GameObject> cards)
    {
        //LIGNE 5

        if (cards[2].GetComponent<CardGame>().CardPlayed && cards[3].GetComponent<CardGame>().CardPlayed)
        {
            cards[0].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[3].GetComponent<CardGame>().CardPlayed && cards[4].GetComponent<CardGame>().CardPlayed)
        {
            cards[1].GetComponent<CardGame>().CardPlayable = true;
        }

        //LIGNE 4

        if (cards[5].GetComponent<CardGame>().CardPlayed && cards[6].GetComponent<CardGame>().CardPlayed)
        {
            cards[2].GetComponent<CardGame>().CardPlayable = true;
            cards[2].GetComponent<Image>().sprite = cards[2].GetComponent<CardGame>().CardFace;
        }

        if (cards[6].GetComponent<CardGame>().CardPlayed && cards[7].GetComponent<CardGame>().CardPlayed)
        {
            cards[3].GetComponent<CardGame>().CardPlayable = true;
            cards[3].GetComponent<Image>().sprite = cards[3].GetComponent<CardGame>().CardFace;
        }

        if (cards[7].GetComponent<CardGame>().CardPlayed && cards[8].GetComponent<CardGame>().CardPlayed)
        {
            cards[4].GetComponent<CardGame>().CardPlayable = true;
            cards[4].GetComponent<Image>().sprite = cards[4].GetComponent<CardGame>().CardFace;
        }

        //LIGNE 3

        if (cards[9].GetComponent<CardGame>().CardPlayed && cards[10].GetComponent<CardGame>().CardPlayed)
        {
            cards[5].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[10].GetComponent<CardGame>().CardPlayed && cards[11].GetComponent<CardGame>().CardPlayed)
        {
            cards[6].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[11].GetComponent<CardGame>().CardPlayed && cards[12].GetComponent<CardGame>().CardPlayed)
        {
            cards[7].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[12].GetComponent<CardGame>().CardPlayed && cards[13].GetComponent<CardGame>().CardPlayed)
        {
            cards[8].GetComponent<CardGame>().CardPlayable = true;
        }


        //LIGNE 2
        if (cards[14].GetComponent<CardGame>().CardPlayed && cards[15].GetComponent<CardGame>().CardPlayed)
        {
            cards[9].GetComponent<CardGame>().CardPlayable = true;
            cards[9].GetComponent<Image>().sprite = cards[9].GetComponent<CardGame>().CardFace;
        }

        if (cards[15].GetComponent<CardGame>().CardPlayed && cards[16].GetComponent<CardGame>().CardPlayed)
        {
            cards[10].GetComponent<CardGame>().CardPlayable = true;
            cards[10].GetComponent<Image>().sprite = cards[10].GetComponent<CardGame>().CardFace;
        }

        if (cards[16].GetComponent<CardGame>().CardPlayed && cards[17].GetComponent<CardGame>().CardPlayed)
        {
            cards[11].GetComponent<CardGame>().CardPlayable = true;
            cards[11].GetComponent<Image>().sprite = cards[11].GetComponent<CardGame>().CardFace;
        }

        if (cards[17].GetComponent<CardGame>().CardPlayed && cards[18].GetComponent<CardGame>().CardPlayed)
        {
            cards[12].GetComponent<CardGame>().CardPlayable = true;
            cards[12].GetComponent<Image>().sprite = cards[12].GetComponent<CardGame>().CardFace;
        }

        if (cards[18].GetComponent<CardGame>().CardPlayed && cards[19].GetComponent<CardGame>().CardPlayed)
        {
            cards[13].GetComponent<CardGame>().CardPlayable = true;
            cards[13].GetComponent<Image>().sprite = cards[13].GetComponent<CardGame>().CardFace;
        }
    }


    public Card getCardEffectAge(int cardValue)
    {
      
        Card card = new Card();
        switch (cardValue)
        {
            case 0:
                //couleur :bleue ;bonus: 3PV ; chainage :lune ; cout :gratuis
                card.SymboleChainage = "lune";
                card.BonusVictoire = 3;

                card.Color = "bleu";
                break;
            case 1:
                card.CoutVerre = 1;
                card.SymboleScientifique = "roue";
                card.BonusVictoire = 1;
                card.Color = "vert";
                break;
            case 2:
                card.CoutPierre = 1;
                card.SymboleChainage = "goutte";
                card.BonusVictoire = 3;
                card.Color = "bleu";
                break;
            case 3:
                card.CoutArgent = 1;
                card.BonusArgile = 1;
                card.Color = "marron";
                break;
            case 4:
                card.BonusArgile = 1;
                card.Color = "marron";
                break;
            case 5:
                card.CoutArgent = 3;
                card.Reduction = "argile";
                card.Color = "jaune";
                break;
            case 6:
                card.CoutArgile = 1;
                card.BonusMilitaire = 1;
                card.SymboleChainage = "epee";
                card.Color = "rouge";
                break;
            case 7:
                card.CoutArgent = 1;
                card.BonusVerre = 1;
                card.Color = "gris";
                break;
            case 8:
                card.BonusMilitaire = 1;
                card.Color = "rouge";
                break;
            case 9:
                card.CoutArgent = 1;
                card.BonusBois = 1;
                card.Color = "marron";
                break;
            case 10:
                card.BonusBois = 1;
                card.Color = "marron";
                break;
            case 11:
                card.CoutArgent = 2;
                card.BonusMilitaire = 1;
                card.SymboleChainage = "tour";
                card.Color = "rouge";
                break;
            case 12:
                card.CoutArgent = 2;
                card.SymboleScientifique = "pot";
                card.SymboleChainage = "engrenage";
                card.Color = "vert";
                break;
            case 13:
                card.CoutArgent = 1;
                card.BonusPapyrus = 1;
                card.Color = "gris";
                break;
            case 14:
                card.BonusPierre = 1;
                card.Color = "marron";
                break;
            case 15:
                card.CoutArgent = 2;
                card.SymboleScientifique = "plume";
                card.SymboleChainage = "livre";
                card.Color = "vert";
                break;
            case 16:
                card.CoutBois = 1;
                card.BonusMilitaire = 1;
                card.SymboleChainage = "ferACheval";
                card.Color = "rouge";
                break;
            case 17:
                card.CoutArgent = 1;
                card.BonusPierre = 1;
                card.Color = "marron";
                break;
            case 18:
                card.CoutArgent = 3;
                card.Reduction = "pierre";
                card.Color = "jaune";
                break;
            case 19:
                card.BonusArgent = 4;
                card.SymboleChainage = "jare";
                card.Color = "jaune";
                break;
            case 20:
                card.BonusVictoire = 3;
                card.SymboleChainage = "masque";
                card.Color = "bleu";
                break;
            case 21:
                card.CoutArgent = 3;
                card.Reduction = "bois";
                card.Color = "jaune";
                break;
            case 22:
                card.CoutPapyrus = 1;
                card.SymboleScientifique = "a";
                card.BonusVictoire = 1;
                card.Color = "vert";
                break;
        }
        return card;
    }

    public List<GameObject> Wonders1
    {
        get { return Wonders; }
        set { Wonders = value; }
    }
}