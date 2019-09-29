using UnityEngine;

public class WonderEffect : MonoBehaviour
{

    public Card getWonderEffect(int cardValue)
    {
        Card wonder = new Card();
        switch (cardValue)
        {
            case 0:
                wonder.BonusMilitaire = 1;
                wonder.BonusVictoire = 3;
                wonder.BonusSpecial = "delete1CarteGriseAdverse";

                wonder.CoutVerre = 1;
                wonder.CoutBois = 1;
                wonder.CoutPierre = 2;
                wonder.Merveille = true;
                break;
            case 1:
                wonder.BonusSpecial = "papyrus-verre-merveille";
                wonder.BonusVictoire = 2;
                wonder.Replay = true;

                wonder.CoutArgile = 1;
                wonder.CoutBois = 2;
                wonder.CoutPierre = 1;
                wonder.Merveille = true;
                break;
            case 2:

                wonder.BonusArgent = 3;
                wonder.BonusSpecial = "enlever3ArgentAdverse";
                wonder.Replay = true;
                wonder.BonusVictoire = 3;

                wonder.CoutPapyrus = 1;
                wonder.CoutArgile = 2;
                wonder.CoutPierre = 2;
                wonder.Merveille = true;
                break;
            case 3:
                wonder.BonusMilitaire = 2;
                wonder.BonusVictoire = 3;

                wonder.CoutVerre = 1;
                wonder.CoutArgile = 3;
                wonder.Merveille = true;
                break;
            case 4:
                wonder.BonusVictoire = 4;
                wonder.BonusSpecial = "choose1TokenProgressLet";

                wonder.CoutPapyrus = 1;
                wonder.CoutVerre = 1;
                wonder.CoutBois = 3;
                wonder.Merveille = true;
                break;
            case 5:
                wonder.BonusVictoire = 4;
                wonder.BonusSpecial = "bois-pierre-argile-merveille";

                wonder.CoutPapyrus = 2;
                wonder.CoutBois = 1;
                wonder.CoutPierre = 1;
                wonder.Merveille = true;
                break;
            case 6:
                wonder.BonusArgent = 6;
                wonder.BonusVictoire = 3;
                wonder.Replay = true;
                wonder.CoutVerre = 1;
                wonder.CoutPapyrus = 1;
                wonder.CoutBois = 2;
                wonder.Merveille = true;
                break;
            case 7:
                wonder.BonusVictoire = 2;
                wonder.BonusSpecial = "choose1CardDefausse";
                wonder.Replay = true;
                wonder.CoutVerre = 2;
                wonder.CoutArgile = 2;
                wonder.CoutPapyrus = 1;
                wonder.Merveille = true;
                break;
            case 8:
                wonder.BonusVictoire = 9;

                wonder.CoutPapyrus = 1;
                wonder.CoutPierre = 3;
                wonder.Merveille = true;
                break;
            case 9:
                wonder.BonusVictoire = 6;
                wonder.Replay = true;
                wonder.CoutVerre = 2;
                wonder.CoutArgile = 1;
                wonder.CoutPierre = 1;
                wonder.Merveille = true;
                break;
            case 10:

                wonder.BonusArgent = 12;
                wonder.Replay = true;

                wonder.CoutVerre = 1;
                wonder.CoutBois = 1;
                wonder.CoutPierre = 1;
                wonder.CoutPapyrus = 1;
                wonder.Merveille = true;
                break;
            case 11:
                wonder.BonusMilitaire = 1;
                wonder.BonusVictoire = 3;
                wonder.BonusSpecial = "delete1CarteMarronAdverse";

                wonder.CoutPapyrus = 2;
                wonder.CoutArgile = 1;
                wonder.CoutPierre = 1;
                wonder.CoutBois = 1;
                wonder.Merveille = true;
                break;
        }

        return wonder;
    }
}