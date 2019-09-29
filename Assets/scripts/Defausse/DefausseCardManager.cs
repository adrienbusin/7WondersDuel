using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefausseCardManager : MonoBehaviour
{
    List<GameObject> defausseCards = new List<GameObject>();
    public Text nbCarteDefausse;

    private void Start()
    {
        nbCarteDefausse.text = "0";
    }

    public List<GameObject> DefausseCards
    {
        get { return defausseCards; }
        set { defausseCards = value; }
    }

    public bool ShowDefausseOnly { get; set; }

    public void NbCarteDefausseText()
    {
        nbCarteDefausse.text = defausseCards.Count.ToString();
    }
}