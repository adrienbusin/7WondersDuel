using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardEffectAge3 : MonoBehaviour
{
   
    public static void CheckCardPlayable(List<GameObject> cards)
    {
        if (cards[19].GetComponent<CardGame>().CardPlayed)
        {
            cards[17].GetComponent<CardGame>().CardPlayable = true;
            cards[17].GetComponent<Image>().sprite = cards[17].GetComponent<CardGame>().CardFace;
        }

        if (cards[19].GetComponent<CardGame>().CardPlayed && cards[18].GetComponent<CardGame>().CardPlayed)
        {
            cards[16].GetComponent<CardGame>().CardPlayable = true;
            cards[16].GetComponent<Image>().sprite = cards[16].GetComponent<CardGame>().CardFace;
        }

        if (cards[18].GetComponent<CardGame>().CardPlayed)
        {
            cards[15].GetComponent<CardGame>().CardPlayable = true;
            cards[15].GetComponent<Image>().sprite = cards[15].GetComponent<CardGame>().CardFace;
        }

        if (cards[17].GetComponent<CardGame>().CardPlayed)
        {
            cards[14].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[16].GetComponent<CardGame>().CardPlayed && cards[17].GetComponent<CardGame>().CardPlayed)
        {
            cards[13].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[15].GetComponent<CardGame>().CardPlayed && cards[16].GetComponent<CardGame>().CardPlayed)
        {
            cards[12].GetComponent<CardGame>().CardPlayable = true;
        }


        if (cards[15].GetComponent<CardGame>().CardPlayed)
        {
            cards[11].GetComponent<CardGame>().CardPlayable = true;
        }


        if (cards[13].GetComponent<CardGame>().CardPlayed && cards[14].GetComponent<CardGame>().CardPlayed)
        {
            cards[10].GetComponent<CardGame>().CardPlayable = true;
            cards[10].GetComponent<Image>().sprite = cards[10].GetComponent<CardGame>().CardFace;
        }

        if (cards[11].GetComponent<CardGame>().CardPlayed && cards[12].GetComponent<CardGame>().CardPlayed)
        {
            cards[9].GetComponent<CardGame>().CardPlayable = true;
            cards[9].GetComponent<Image>().sprite = cards[9].GetComponent<CardGame>().CardFace;
        }

        if (cards[10].GetComponent<CardGame>().CardPlayed)
        {
            cards[7].GetComponent<CardGame>().CardPlayable = true;
            cards[8].GetComponent<CardGame>().CardPlayable = true;
        }

        if (cards[9].GetComponent<CardGame>().CardPlayed)
        {
            cards[6].GetComponent<CardGame>().CardPlayable = true;
            cards[5].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[7].GetComponent<CardGame>().CardPlayed && cards[8].GetComponent<CardGame>().CardPlayed)
        {
            cards[4].GetComponent<CardGame>().CardPlayable = true;
            cards[4].GetComponent<Image>().sprite = cards[4].GetComponent<CardGame>().CardFace;
        }
        if (cards[6].GetComponent<CardGame>().CardPlayed && cards[7].GetComponent<CardGame>().CardPlayed)
        {
            cards[3].GetComponent<CardGame>().CardPlayable = true;
            cards[3].GetComponent<Image>().sprite = cards[3].GetComponent<CardGame>().CardFace;
        }
        if (cards[5].GetComponent<CardGame>().CardPlayed && cards[6].GetComponent<CardGame>().CardPlayed)
        {
            cards[2].GetComponent<CardGame>().CardPlayable = true;
            cards[2].GetComponent<Image>().sprite = cards[2].GetComponent<CardGame>().CardFace;
        }
        if (cards[3].GetComponent<CardGame>().CardPlayed && cards[4].GetComponent<CardGame>().CardPlayed)
        {
            cards[1].GetComponent<CardGame>().CardPlayable = true;
        }
        if (cards[2].GetComponent<CardGame>().CardPlayed && cards[3].GetComponent<CardGame>().CardPlayed)
        {
            cards[0].GetComponent<CardGame>().CardPlayable = true;
        }
    }

    public static Card getCardEffectAge(int cardValue)
    {
        Card card = new Card();
        switch (cardValue)
        {
            case 0:
                card.CoutPierre = 1;
                card.CoutBois = 1;
                card.CoutVerre = 2;
                card.SymboleScientifique = "cadran";
                card.BonusVictoire = 3;
                card.Color = "vert";
                break;
            case 1:
                card.CoutArgile = 1;
                card.CoutBois = 1;
                card.CoutPierre = 1;
                card.CoutChainage = "baril";
                card.BonusVictoire = 3;
                card.BonusSpecial = "2argent/merveille";
                card.Color = "jaune";
                break;
            case 2:
                card.CoutPierre = 2;
                card.CoutVerre = 1;
                card.BonusVictoire = 3;
                card.BonusSpecial = "1argent/carteRouge";
                card.Color = "jaune";
                break;
            case 3:
                card.CoutArgile = 3;
                card.CoutBois = 2;
                card.BonusMilitaire = 3;
                card.Color = "rouge";
                break;
            case 4:
                card.CoutPapyrus = 2;
                card.BonusVictoire = 3;
                card.BonusSpecial = "3argent/carteGrise";
                card.Color = "jaune";
                break;
            case 5:
                card.CoutArgile = 2;
                card.CoutPierre = 2;
                card.CoutChainage = "casque";
                card.BonusMilitaire = 2;
                card.Color = "rouge";
                break;
            case 6:
                card.CoutArgent = 8;
                card.BonusMilitaire = 3;
                card.Color = "rouge";
                break;
            case 7:
                card.CoutPierre = 2;
                card.CoutArgile = 1;
                card.CoutPapyrus = 1;
                card.CoutChainage = "tour";
                card.BonusMilitaire = 2;
                card.Color = "rouge";
                break;
            case 8:
                card.CoutArgile = 2;
                card.CoutBois = 2;
                card.CoutChainage = "colonne";
                card.BonusVictoire = 6;
                card.Color = "bleu";
                break;
            case 9:
                card.CoutArgile = 2;
                card.CoutVerre = 1;
                card.CoutChainage = "jare";
                card.BonusVictoire = 3;
                card.BonusSpecial = "1argent/carteJaune";
                card.Color = "jaune";
                break;
            case 10:
                card.CoutPierre = 2;
                card.CoutVerre = 1;
                card.BonusVictoire = 5;
                card.Color = "bleu";
                break;
            case 11:
                card.CoutPierre = 1;
                card.CoutPapyrus = 2;
                card.CoutChainage = "lampe";
                card.BonusVictoire = 2;
                card.SymboleScientifique = "globe";
                card.Color = "vert";
                break;
            case 12:
                card.CoutArgile = 1;
                card.CoutPierre = 1;
                card.CoutBois = 1;
                card.CoutVerre = 2;
                card.BonusVictoire = 7;
                card.Color = "bleu";
                break;
            case 13:
                card.CoutArgile = 1;
                card.CoutBois = 1;
                card.CoutPapyrus = 2;
                card.CoutChainage = "soleil";
                card.BonusVictoire = 6;
                card.Color = "bleu";
                break;
            case 14:
                card.CoutBois = 1;
                card.CoutPapyrus = 1;
                card.CoutVerre = 1;
                card.BonusVictoire = 3;
                card.BonusSpecial = "2argent/carteMarron";
                card.Color = "jaune";
                break;
            case 15:
                card.CoutArgile = 2;
                card.CoutPierre = 1;
                card.CoutPapyrus = 1;
                card.CoutChainage = "temple";
                card.BonusVictoire = 5;
                card.Color = "bleu";
                break;
            case 16:
                card.CoutBois = 3;
                card.CoutVerre = 1;
                card.CoutChainage = "cible";
                card.BonusMilitaire = 2;
                card.Color = "rouge";
                break;
            case 17:
                card.CoutBois = 2;
                card.CoutVerre = 1;
                card.CoutPapyrus = 1;
                card.BonusVictoire = 3;
                card.SymboleScientifique = "cadran";
                card.Color = "vert";
                break;
            case 18:
                card.CoutPierre = 3;
                card.CoutBois = 2;
                card.BonusVictoire = 7;
                card.Color = "bleu";
                break;
            case 19:
                card.CoutArgile = 1;
                card.CoutVerre = 1;
                card.CoutPapyrus = 1;
                card.CoutChainage = "harpe";
                card.BonusVictoire = 2;
                card.SymboleScientifique = "globe";
                card.Color = "vert";
                break;
        }
        return card;
    }

    public static Card GetCardEffectAgeGuilde(int cardValue)
    {
        Card card = new Card();
        switch (cardValue)
        {
            case 0:
                card.CoutPierre = 2;
                card.CoutArgile = 1;
                card.CoutBois = 1;
                card.CoutVerre = 1;
                card.Guilde = true;
                card.BonusSpecial = "2pv/merveille";
                card.Color = "violet";
                break;
            case 1:
                card.CoutPapyrus = 1;
                card.CoutArgile = 1;
                card.CoutBois = 2;
                card.Guilde = true;
                card.BonusSpecial = "1argent+1pv/carteBleu";
                card.Color = "violet";
                break;
            case 2:
                card.CoutPapyrus = 1;
                card.CoutArgile = 1;
                card.CoutBois = 1;
                card.CoutVerre = 1;
                card.Guilde = true;
                card.BonusSpecial = "1argent+1pv/carteJaune";
                card.Color = "violet";
                break;
            case 3:
                card.CoutPierre = 2;
                card.CoutBois = 2;
                card.Guilde = true;
                card.BonusSpecial = "1pv/3Argent";
                card.Color = "violet";
                break;
            case 4:
                card.CoutArgile = 2;
                card.CoutBois = 2;
                card.BonusSpecial = "1argent+1pv/carteVerte";
                card.Color = "violet";
                card.Guilde = true;
                break;
            case 5:
                card.CoutPierre = 1;
                card.CoutArgile = 1;
                card.CoutPapyrus = 1;
                card.CoutVerre = 1;
                card.Guilde = true;
                card.BonusSpecial = "1argent+1pv/carteGrise+carteMarron";
                card.Color = "violet";
                break;
            case 6:
                card.CoutPierre = 2;
                card.CoutArgile = 1;
                card.CoutPapyrus = 1;
                card.Guilde = true;
                card.BonusSpecial = "1argent+1pv/carteRouge";
                card.Color = "violet";
                break;
        }

        return card;
    }
}