using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteFaceManager : MonoBehaviour
{
    public List<Sprite> cardFace;
    public Sprite cardBack;
    public List<GameObject> cards;
    public List<Sprite> cardFaceGuildes;
    public Sprite cardBackGuildes;

    public Sprite CardBack
    {
        get { return cardBack; }
        set { cardBack = value; }
    }

    public List<Sprite> CardFace
    {
        get { return cardFace; }
        set { cardFace = value; }
    }

    public List<GameObject> Cards
    {
        get { return cards; }
        set { cards = value; }
    }

    public List<Sprite> CardFaceGuildes
    {
        get { return cardFaceGuildes; }
        set { cardFaceGuildes = value; }
    }

    public Sprite CardBackGuildes
    {
        get { return cardBackGuildes; }
        set { cardBackGuildes = value; }
    }
}