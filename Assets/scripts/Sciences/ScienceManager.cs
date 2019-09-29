using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScienceManager : MonoBehaviour
{
    public List<Sprite> scienceFace;
    public List<GameObject> symbolesJoueur1;
    public List<GameObject> symbolesJoueur2;

    public List<GameObject> scienceTextPlayer1;
    public List<GameObject> scienceTextPlayer2;

    List<GameObject> symbolesJoueur;
    List<GameObject> scienceTextPlayer;

    void checkSymbole(Player player,
        String symbole,
        List<GameObject> scienceTextPlayer,
        List<GameObject> symbolesJoueur,
        int indexSymboleJoueur,
        int indexScienceFace)
    {
        if (player.HasAlreadySymboleScience(symbole))
        {
            int indexSymbole = player.IndexSymboleScience(symbole);
            scienceTextPlayer[indexSymbole].GetComponent<ScienceText>().setActive(true);
            player.HasDoubleSymboleSciences = true;
        }
        else
        {
            symbolesJoueur[indexSymboleJoueur].GetComponent<ScienceSymbole>().SymboleFace =
                scienceFace[indexScienceFace];
        }
    }

    void addSymboleToPlayer(String symbole, Player player, int indexScienceFace)
    {
        if (player.PlayerNumber == 0)
        {
            symbolesJoueur = symbolesJoueur1;
            scienceTextPlayer = scienceTextPlayer1;
        }
        else
        {
            symbolesJoueur = symbolesJoueur2;
            scienceTextPlayer = scienceTextPlayer2;
        }
        switch (player.NbScienceSymbole)
        {
            case 0:
                symbolesJoueur[0].GetComponent<ScienceSymbole>().SymboleFace = scienceFace[indexScienceFace];
                break;
            case 1:
                checkSymbole(player, symbole, scienceTextPlayer, symbolesJoueur, 1, indexScienceFace);
                break;
            case 2:
                checkSymbole(player, symbole, scienceTextPlayer, symbolesJoueur, 2, indexScienceFace);
                break;
            case 3:
                checkSymbole(player, symbole, scienceTextPlayer, symbolesJoueur, 3, indexScienceFace);
                break;
            case 4:
                checkSymbole(player, symbole, scienceTextPlayer, symbolesJoueur, 4, indexScienceFace);
                if (player.TokenLoi && !player.HasAlreadySymboleScience(symbole))
                {
                    victoireScientifique(player);
                }
                break;
            case 5:
                checkSymbole(player, symbole, scienceTextPlayer, symbolesJoueur, 5, indexScienceFace);
                if (!player.HasAlreadySymboleScience(symbole))
                {
                    victoireScientifique(player);
                }
                break;
        }
        player.GetComponent<Player>().AddSymboleScience(symbole);
    }

    public void victoireScientifique(Player player)
    {
        player.VictoireScientifique = true;
        player.CountLastPoint();
        player.PlayerAdverse.CountLastPoint();
        GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
            .hideShowAllCards(false, false);
        SceneManager.LoadScene("Score");
    }

    public void setSymbole(String symbole, Player player)
    {
        switch (symbole)
        {
            case "globe":
                addSymboleToPlayer(symbole, player, 4);
                break;
            case "balance":
                addSymboleToPlayer(symbole, player, 6);
                break;
            case "cadran":
                addSymboleToPlayer(symbole, player, 5);
                break;
            case "pot":
                addSymboleToPlayer(symbole, player, 2);
                break;
            case "a":
                addSymboleToPlayer(symbole, player, 3);
                break;
            case "plume":
                addSymboleToPlayer(symbole, player, 0);
                break;
            case "roue":
                addSymboleToPlayer(symbole, player, 1);
                break;
        }
    }
}