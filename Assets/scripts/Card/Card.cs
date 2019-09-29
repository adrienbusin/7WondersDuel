using UnityEngine;

public class Card : MonoBehaviour
{
    public Card()
    {
        BonusSpecial = "NONE";
        Reduction = "NONE";
        CoutChainage = "NONE";
        SymboleChainage = "NONE";
        SymboleScientifique = "NONE";
    }

    public int Number { get; set; }

    public int CoutPierre { get; set; }

    public int CoutBois { get; set; }

    public int CoutArgile { get; set; }

    public int CoutPapyrus { get; set; }

    public int CoutVerre { get; set; }

    public int CoutArgent { get; set; }

    public int BonusMilitaire { get; set; }

    public int BonusVictoire { get; set; }

    public int BonusArgile { get; set; }

    public int BonusBois { get; set; }

    public int BonusPierre { get; set; }

    public int BonusVerre { get; set; }

    public int BonusPapyrus { get; set; }

    public string SymboleScientifique { get; set; }

    public string SymboleChainage { get; set; }

    public string CoutChainage { get; set; }

    public int BonusArgent { get; set; }

    public string Color { get; set; }

    public string Reduction { get; set; }
    
    public string BonusSpecial { get; set; }

    public bool Guilde { get; set; }

    public bool Replay { get; set; }

    public bool Merveille { get; set; }

    public bool Defausse { get; set; }
    
    public bool ToDestroy { get; set; }
    
    public int CardDropNumber { get; set; }
    
    public GameObject CardGame { get; set; }
}