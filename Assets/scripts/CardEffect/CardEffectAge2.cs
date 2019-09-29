using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffectAge2 : MonoBehaviour
{
    public void checkCardPlayable(List<GameObject> cards)
    {
        //LIGNE 2

        if (cards[19].GetComponent<CardGame>().CardPlayed)
        {
            cards[17].GetComponent<CardGame>().CardPlayable = true;
            cards[17].GetComponent<Image>().sprite = cards[17].GetComponent<CardGame>().CardFace;
        }

        if (cards[18].GetComponent<CardGame>().CardPlayed)
        {
            cards[15].GetComponent<CardGame>().CardPlayable = true;
            cards[15].GetComponent<Image>().sprite = cards[15].GetComponent<CardGame>().CardFace;
        }

        if (cards[19].GetComponent<CardGame>().CardPlayed && cards[18].GetComponent<CardGame>().CardPlayed)
        {
            cards[16].GetComponent<CardGame>().CardPlayable = true;
            cards[16].GetComponent<Image>().sprite = cards[16].GetComponent<CardGame>().CardFace;
        }

        //LIGNE 3

        if (cards[17].GetComponent<CardGame>().CardPlayed)
        {
            cards[14].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[17].GetComponent<CardGame>().CardPlayed && cards[16].GetComponent<CardGame>().CardPlayed)
        {
            cards[13].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[16].GetComponent<CardGame>().CardPlayed && cards[15].GetComponent<CardGame>().CardPlayed)
        {
            cards[12].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[15].GetComponent<CardGame>().CardPlayed)
        {
            cards[11].GetComponent<CardGame>().CardPlayable = true;
        }

        //LIGNE 4

        if (cards[14].GetComponent<CardGame>().CardPlayed)
        {
            cards[10].GetComponent<CardGame>().CardPlayable = true;
            cards[10].GetComponent<Image>().sprite = cards[10].GetComponent<CardGame>().CardFace;
        }

        if (cards[14].GetComponent<CardGame>().CardPlayed && cards[13].GetComponent<CardGame>().CardPlayed)
        {
            cards[9].GetComponent<CardGame>().CardPlayable = true;
            cards[9].GetComponent<Image>().sprite = cards[9].GetComponent<CardGame>().CardFace;
        }

        if (cards[13].GetComponent<CardGame>().CardPlayed && cards[12].GetComponent<CardGame>().CardPlayed)
        {
            cards[8].GetComponent<CardGame>().CardPlayable = true;
            cards[8].GetComponent<Image>().sprite = cards[8].GetComponent<CardGame>().CardFace;
        }

        if (cards[11].GetComponent<CardGame>().CardPlayed && cards[12].GetComponent<CardGame>().CardPlayed)
        {
            cards[7].GetComponent<CardGame>().CardPlayable = true;
            cards[7].GetComponent<Image>().sprite = cards[7].GetComponent<CardGame>().CardFace;
        }

        if (cards[11].GetComponent<CardGame>().CardPlayed)
        {
            cards[6].GetComponent<CardGame>().CardPlayable = true;
            cards[6].GetComponent<Image>().sprite = cards[6].GetComponent<CardGame>().CardFace;
        }


        //LIGNE 5
        if (cards[10].GetComponent<CardGame>().CardPlayed)
        {
            cards[5].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[9].GetComponent<CardGame>().CardPlayed && cards[10].GetComponent<CardGame>().CardPlayed)
        {
            cards[4].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[8].GetComponent<CardGame>().CardPlayed && cards[9].GetComponent<CardGame>().CardPlayed)
        {
            cards[3].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[7].GetComponent<CardGame>().CardPlayed && cards[8].GetComponent<CardGame>().CardPlayed)
        {
            cards[2].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[6].GetComponent<CardGame>().CardPlayed && cards[7].GetComponent<CardGame>().CardPlayed)
        {
            cards[1].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[6].GetComponent<CardGame>().CardPlayed)
        {
            cards[0].GetComponent<CardGame>().CardPlayable = true;
        }
    }

    public Card getCardEffectAge(int cardValue)
    {
        
        Card card = new Card();
        switch (cardValue)
        {
            case 0:
                card.CoutPierre = 3;
                card.CoutChainage = "goutte";
                card.BonusVictoire = 5;
                card.Color = "bleu";
                break;
            case 1:
                card.CoutPierre = 1;
                card.CoutBois = 1;
                card.CoutPapyrus = 1;
                card.SymboleChainage = "cible";
                card.BonusMilitaire = 2;
                card.Color = "rouge";
                break;
            case 2:
                card.CoutArgent = 3;
                card.CoutChainage = "epee";
                card.BonusMilitaire = 1;
                card.Color = "rouge";
                break;
            case 3:
                card.BonusArgent = 6;
                card.SymboleChainage = "baril";
                card.Color = "jaune";
                break;
            case 4:
                card.CoutArgent = 2;
                card.BonusArgile = 2;
                card.Color = "marron";
                break;
            case 5:
                card.CoutArgent = 2;
                card.CoutPapyrus = 1;
                card.CoutVerre = 1;
                card.Reduction = "bois-argile-pierre";
                card.Color = "jaune";
                break;
            case 6:
                card.CoutArgent = 4;
                card.Reduction = "papyrus-verre-cout-1";
                card.Color = "jaune";
                break;
            case 7:
                card.CoutArgile = 2;
                card.CoutPierre = 1;
                card.SymboleScientifique = "pot";
                card.BonusVictoire = 2;
                card.CoutChainage = "engrenage";
                card.Color = "vert";
                break;
            case 8:
                card.BonusPapyrus = 1;
                card.Color = "gris";
                break;
            case 9:
                card.CoutArgile = 1;
                card.CoutArgent = 3;
                card.Reduction = "verre-papyrus";
                card.Color = "jaune";
                break;
            case 10:
                card.BonusVerre = 1;
                card.Color = "gris";
                break;
            case 11:
                card.BonusMilitaire = 1;
                card.CoutBois = 1;
                card.CoutArgile = 1;
                card.CoutChainage = "ferACheval";
                card.Color = "rouge";
                break;
            case 12:
                card.BonusVictoire = 1;
                card.CoutBois = 1;
                card.CoutVerre = 2;
                card.SymboleChainage = "lampe";
                card.SymboleScientifique = "a";
                card.Color = "vert";
                break;
            case 13:
                card.BonusVictoire = 2;
                card.CoutBois = 1;
                card.CoutVerre = 1;
                card.CoutPierre = 1;
                card.CoutChainage = "livre";
                card.SymboleScientifique = "plume";
                card.Color = "vert";
                break;
            case 14:
                card.BonusMilitaire = 2;
                card.CoutArgile = 2;
                card.CoutVerre = 1;
                card.SymboleChainage = "casque";
                card.Color = "rouge";
                break;
            case 15:
                card.BonusVictoire = 4;
                card.CoutPierre = 1;
                card.CoutBois = 1;
                card.SymboleChainage = "temple";
                card.Color = "bleu";
                break;
            case 16:
                card.CoutArgent = 2;
                card.BonusBois = 2;
                card.Color = "marron";
                break;
            case 17:
                card.BonusVictoire = 1;
                card.CoutBois = 1;
                card.CoutPapyrus = 2;
                card.SymboleChainage = "harpe";
                card.SymboleScientifique = "roue";
                card.Color = "vert";
                break;
            case 18:
                card.CoutArgent = 2;
                card.BonusPierre = 2;
                card.Color = "marron";
                break;
            case 19:
                card.CoutArgile = 2;
                card.CoutChainage = "masque";
                card.BonusVictoire = 4;
                card.SymboleChainage = "colonne";
                card.Color = "bleu";
                break;
            case 20:
                card.CoutBois = 1;
                card.CoutChainage = "lune";
                card.BonusVictoire = 4;
                card.CoutPapyrus = 1;
                card.SymboleChainage = "soleil";
                card.Color = "bleu";
                break;
            case 21:
                card.CoutBois = 2;
                card.BonusVictoire = 5;
                card.CoutVerre = 1;
                card.Color = "bleu";
                break;
            case 22:
                card.CoutPierre = 2;
                card.BonusMilitaire = 2;
                card.Color = "rouge";
                break;
        }
        return card;
    }
}