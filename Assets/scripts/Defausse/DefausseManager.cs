using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefausseManager : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private List<GameObject> cards;

    private DefausseCardManager _defausseCardManager;
    private int page;
    private float nbPages;

    private void Start()
    {
        _defausseCardManager =
            GameObject.FindGameObjectWithTag("DefausseCardManager").GetComponent<DefausseCardManager>();
        leftButton.SetActive(false);
        if (_defausseCardManager.ShowDefausseOnly)
        {
            _gameScreen.SetActive(true);
        }
        else
        {
            _gameScreen.SetActive(false);
        }
        afficherCartesPage();
    }

    public void onClickGameScreen()
    {
        if (_defausseCardManager.ShowDefausseOnly)
        {
            GameObject.FindGameObjectWithTag("DefausseScreen").SetActive(false);
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(true, true);
            _defausseCardManager.ShowDefausseOnly = false;
            HideAllGameObject();
        }
    }

    public void right()
    {
        leftButton.SetActive(true);
        page += 1;
        if (page + 1 == nbPages || nbPages == 1)
        {
            rightButton.SetActive(false);
        }
        afficherCartesPage();
    }

    public void left()
    {
        page += -1;
        rightButton.SetActive(true);
        if (page == 0)
        {
            leftButton.SetActive(false);
        }
        afficherCartesPage();
    }

    private void afficherCartesPage()
    {
        nbPages = (int) Math.Ceiling((float) _defausseCardManager.DefausseCards.Count / 4);

        if (nbPages == 1)
        {
            rightButton.SetActive(false);
        }
        
        int j = 0;
        for (int i = page * 4; i < page * 4 + 4; i++)
        {
            if (_defausseCardManager.DefausseCards.Count > i)
            {
                cards[j].GetComponent<Image>().sprite =
                    _defausseCardManager.DefausseCards[i].GetComponent<Image>().sprite;
                cards[j].GetComponent<CardGame>().CardPlayable = true;
                cards[j].GetComponent<CardGame>().CardValue =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().CardValue;
                cards[j].GetComponent<CardGame>().CardState =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().CardState;
                cards[j].GetComponent<CardGame>().Guilde =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().Guilde;
                cards[j].GetComponent<CardGame>().AgeEnCours1 =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().AgeEnCours1;
                cards[j].GetComponent<CardGame>().CardEffectAge4 =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().CardEffectAge4;
                cards[j].GetComponent<CardGame>().CardEffectAge5 =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().CardEffectAge5;
                cards[j].GetComponent<CardGame>().CardEffectAge6 =
                    _defausseCardManager.DefausseCards[i].GetComponent<CardGame>().CardEffectAge6;
                if (!_defausseCardManager.ShowDefausseOnly)
                {
                    cards[j].GetComponent<CardGame>().Defausse = true;
                }

                cards[j].SetActive(true);
            }
            else
            {
                cards[j].SetActive(false);
            }
            j++;
        }
    }


    public void HideAllGameObject()
    {
        foreach (GameObject gameObject in cards)
        {
            Destroy(gameObject);
        }
        Destroy(leftButton);
        Destroy(rightButton);
    }
}