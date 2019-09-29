using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyRessourceManager : MonoBehaviour
{
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private List<GameObject> cards;

    private PlayerManager _playerManager;
    private int page;
    private float nbPages;
    private List<GameObject> cardsToDestroy = new List<GameObject>();

    private void Start()
    {
        _playerManager =
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        leftButton.SetActive(false);
        
        cardsToDestroy = _playerManager.Player.DestroyRessourcePrimaire ? _playerManager.Player.PlayerAdverse.RessourcesPrimairesCard : _playerManager.Player.PlayerAdverse.RessourcesSecondaireCard;
        afficherCartesPage();
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
        nbPages = (int) Math.Ceiling((float) cardsToDestroy.Count / 4);

        if (nbPages == 1)
        {
            rightButton.SetActive(false);
        }
        
        int j = 0;
        for (int i = page * 4; i < page * 4 + 4; i++)
        {
            if (cardsToDestroy.Count > i)
            {
                cards[j].GetComponent<Image>().sprite =
                    cardsToDestroy[i].GetComponent<Image>().sprite;
                cards[j].GetComponent<CardGame>().CardPlayable = true;
                cards[j].GetComponent<CardGame>().CardValue =
                    cardsToDestroy[i].GetComponent<CardGame>().CardValue;
                cards[j].GetComponent<CardGame>().CardState =
                    cardsToDestroy[i].GetComponent<CardGame>().CardState;
                cards[j].GetComponent<CardGame>().Guilde =
                    cardsToDestroy[i].GetComponent<CardGame>().Guilde;
                cards[j].GetComponent<CardGame>().AgeEnCours1 =
                    cardsToDestroy[i].GetComponent<CardGame>().AgeEnCours1;
                cards[j].GetComponent<CardGame>().CardEffectAge4 =
                    cardsToDestroy[i].GetComponent<CardGame>().CardEffectAge4;
                cards[j].GetComponent<CardGame>().CardEffectAge5 =
                    cardsToDestroy[i].GetComponent<CardGame>().CardEffectAge5;
                cards[j].GetComponent<CardGame>().CardEffectAge6 =
                    cardsToDestroy[i].GetComponent<CardGame>().CardEffectAge6;
                    cards[j].GetComponent<CardGame>().ToDestroy = true;
               
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