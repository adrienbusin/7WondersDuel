using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WonderManager : MonoBehaviour
{
    public List<Sprite> cardFace;
    private List<Sprite> tmpCardFace;
    public List<GameObject> cards;
    public List<GameObject> cardSelected;

    private int playerWhoPlay;
    private int tourDeJeu;

    private int nbMerveilleConstruite;

    public Text textPlayerNames;

    private PlayerNameManager _playerNameManager;

    List<WonderCard> merveillesSelected = new List<WonderCard>();


    void Start()
    {
        shuffleCardFace();
        initializeCards();

        _playerNameManager = GameObject.FindGameObjectWithTag("PlayerNameManager").GetComponent<PlayerNameManager>();
        if (textPlayerNames != null)
            textPlayerNames.text = _playerNameManager.Player1Name + " selectionne une merveille";
    }

    void shuffleCardFace()
    {
        if (cardFace.Count > 0)
        {
            tmpCardFace = new List<Sprite>(cardFace);
            for (int i = 0; i < tmpCardFace.Count; i++)
            {
                Sprite temp = tmpCardFace[i];
                int randomIndex = Random.Range(i, tmpCardFace.Count);
                tmpCardFace[i] = tmpCardFace[randomIndex];
                tmpCardFace[randomIndex] = temp;
            }
        }
    }


    void initializeCards()
    {
        if (cardFace.Count > 0)
        {
            for (int i = 0; i < 8; i++)
            {
                Sprite card = getCardFace(i);


                for (int j = 0; j < 12; j++)
                {
                    if (cardFace[j] == card)
                    {
                        cards[i].GetComponent<WonderCard>().cardValue = j;
                    }
                }

                cards[i].GetComponent<WonderCard>().cardFace = card;

                cards[i].GetComponent<Image>().sprite = cards[i].GetComponent<WonderCard>().cardFace;
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("age1");
    }

    public Sprite getCardFace(int indexCarteFace)
    {
        return tmpCardFace[indexCarteFace];
    }

    public int getTourDeJeu
    {
        get { return tourDeJeu; }
        set { tourDeJeu = value; }
    }

    public List<GameObject> getCardSelected
    {
        get { return cardSelected; }
    }


    public List<WonderCard> MerveillesSelected
    {
        get { return merveillesSelected; }
        set { merveillesSelected = value; }
    }

    public List<GameObject> getWonders
    {
        get { return cards; }
    }

    public int NbMerveilleConstruite
    {
        get { return nbMerveilleConstruite; }
        set { nbMerveilleConstruite = value; }
    }

    public Text TextPlayerNames
    {
        get { return textPlayerNames; }
        set { textPlayerNames = value; }
    }

    public void loadScene()
    {
        StartCoroutine(wait());
    }
}