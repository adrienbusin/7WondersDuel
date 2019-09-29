using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MilitaryManager : MonoBehaviour
{
    private GameObject _pawnMilitary;
    private GameObject _plateau;
    public GameObject jetonPerte2Joueur1;
    public GameObject jetonPerte5Joueur1;
    public GameObject jetonPerte2Joueur2;
    public GameObject jetonPerte5Joueur2;
    private int _piont;
    private int _piontJoueur;
    private AudioSource _militaryVictory;


    public void AddMilitaryPoint(Player player, int nbPoints)
    {
        _piont += player.PlayerNumber == 0 ? nbPoints : -nbPoints;
        _pawnMilitary = GameObject.Find("conflictPawn");
        _plateau = GameObject.Find("GameboardDroit");
        
        _piontJoueur = player.PlayerNumber == 0 ? _piont : -_piont;
        PerteArgent(player);
        GagnePoint(player);
        PertePoint(player);

        player.SetText();

        var boundsSize = _plateau.GetComponent<SpriteRenderer>().bounds.size.x * 3.13f;

        if (_piont > 8 || _piont < -8)
        {
            int nbPointManquant;
            if (player.PlayerNumber == 0)
            {
                nbPointManquant = -9 + player.Militaire;
            }
            else
            {
                nbPointManquant = 9 - player.Militaire;
            }

            nbPointManquant = nbPointManquant < 0 ? -nbPointManquant : nbPointManquant;
            if (nbPointManquant == 0)
            {
                nbPointManquant = nbPoints;
            }
            
            StartCoroutine(player.PlayerNumber == 0
                ? StartAnimate(nbPointManquant * boundsSize, player)
                : StartAnimate(nbPointManquant * -boundsSize, player));
            
            player.VictoireMilitaire = true;
            player.CountLastPoint();
            player.PlayerAdverse.CountLastPoint();
            player.Have10VictoryPointMilitary = true;
            GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
                .hideShowAllCards(false, false);
            SceneManager.LoadScene("Score");
        }
        else
        {
            if (_pawnMilitary != null)
            {
                StartCoroutine(player.PlayerNumber == 0
                    ? StartAnimate(nbPoints * boundsSize, player)
                    : StartAnimate(nbPoints * -boundsSize, player));
            }
        }
    }

    private static IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }

    private IEnumerator StartAnimate(float deplacement, Player player)
    {
        var pointA = _pawnMilitary.transform.position;
        var pointB = _pawnMilitary.transform.position;

        pointB.x += deplacement;
        yield return StartCoroutine(MoveObject(_pawnMilitary.transform, pointA, pointB, 1f, player));
    }

    private IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time, Player player)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            GameObject.FindGameObjectWithTag("MilitaryAudioMove").GetComponent<AudioSource>().Play();

            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
            if (player.VictoireMilitaire)
            {
                GameObject.FindGameObjectWithTag("MilitaryAudio").GetComponent<AudioSource>().Play();
                StartCoroutine(Wait());
            }
        }
    }

    private void PerteArgent(Player player)
    {
        if (_piontJoueur == 3 || _piontJoueur == 4 || _piontJoueur == 5)
        {
            //REMOVE 2 PIECE 1 FOIS
            if (!player.PlayerAdverse.AlreadyLoose2ArgentMilitary)
            {
                GameObject.FindGameObjectWithTag("PieceOutAudio").GetComponent<AudioSource>().Play();
                player.PlayerAdverse.Argent += -2;
                player.PlayerAdverse.AlreadyLoose2ArgentMilitary = true;
                player.PlayerAdverse.SetText();
                if (player.PlayerAdverse.PlayerNumber == 0)
                {
                    jetonPerte2Joueur1.SetActive(false);
                }
                else
                {
                    jetonPerte2Joueur2.SetActive(false);
                }
            }
        }

        if (_piontJoueur <= 5) return;
        //REMOVE 5 PIECE 1 FOIS
        if (player.PlayerAdverse.AlreadyLoose5ArgentMilitary) return;
        GameObject.FindGameObjectWithTag("PieceOutAudio").GetComponent<AudioSource>().Play();
        player.PlayerAdverse.Argent += -5;
        player.PlayerAdverse.AlreadyLoose5ArgentMilitary = true;
        if (player.PlayerAdverse.PlayerNumber == 0)
        {
            jetonPerte5Joueur1.SetActive(false);
        }
        else
        {
            jetonPerte5Joueur2.SetActive(false);
        }
    }

    private void PertePointAdvrese(Player player)
    {
        player.Have2VictoryPointMilitary = false;
        player.Have5VictoryPointMilitary = false;
        player.Have10VictoryPointMilitary = false;
    }

    private void GagnePoint(Player player)
    {
        if (_piontJoueur == 1 || _piontJoueur == 2)
        {
            if (!player.Have2VictoryPointMilitary)
            {
                player.PointVictoire += 2;
                player.Have2VictoryPointMilitary = true;
            }
        }

        if (_piontJoueur == 3 || _piontJoueur == 4 || _piontJoueur == 5)
        {
            if (!player.Have5VictoryPointMilitary && !player.Have2VictoryPointMilitary)
            {
                player.PointVictoire += 5;
                player.Have5VictoryPointMilitary = true;
            }
            else if (!player.Have5VictoryPointMilitary && player.Have2VictoryPointMilitary)
            {
                player.PointVictoire += 3;
                player.Have5VictoryPointMilitary = true;
            }
        }

        if (_piontJoueur == 6 || _piontJoueur == 7 || _piontJoueur >= 8)
        {
            if (!player.Have10VictoryPointMilitary && !player.Have5VictoryPointMilitary)
            {
                player.PointVictoire += 8;
                player.Have10VictoryPointMilitary = true;
            }
            else if (!player.Have10VictoryPointMilitary && player.Have5VictoryPointMilitary)
            {
                player.PointVictoire += 5;
                player.Have10VictoryPointMilitary = true;
            }
        }
        if (_piontJoueur > -1)
        {
            if (player.PlayerAdverse.Have2VictoryPointMilitary)
            {
                player.PlayerAdverse.PointVictoire += -2;
                player.PlayerAdverse.Have2VictoryPointMilitary = false;
            }
        }

        if (_piontJoueur == -1 || _piontJoueur == -2)
        {
            if (player.PlayerAdverse.Have5VictoryPointMilitary)
            {
                player.PlayerAdverse.PointVictoire += -3;
                player.PlayerAdverse.Have5VictoryPointMilitary = false;
            }
        }

        if (_piontJoueur == -3 || _piontJoueur == -4 || _piontJoueur == -5)
        {
            if (player.PlayerAdverse.Have10VictoryPointMilitary)
            {
                player.PlayerAdverse.PointVictoire += -5;
                player.PlayerAdverse.Have5VictoryPointMilitary = false;
            }
        }
    }


    private void PertePoint(Player player)
    {
        if (_piontJoueur == 0)
        {
            if (player.Have2VictoryPointMilitary)
            {
                player.PointVictoire += -2;
                player.Have2VictoryPointMilitary = false;
            }
            if (player.PlayerAdverse.Have2VictoryPointMilitary)
            {
                player.PlayerAdverse.PointVictoire += -2;
                player.PlayerAdverse.Have2VictoryPointMilitary = false;
            }

            if (player.Have5VictoryPointMilitary)
            {
                player.PointVictoire += -3;
                player.Have5VictoryPointMilitary = false;
            }
            if (player.PlayerAdverse.Have5VictoryPointMilitary)
            {
                player.PlayerAdverse.PointVictoire += -3;
                player.PlayerAdverse.Have5VictoryPointMilitary = false;
            }
        }

        if (_piontJoueur == 1 || _piontJoueur == 2)
        {
            if (player.Have5VictoryPointMilitary)
            {
                player.PointVictoire += -3;
                player.Have5VictoryPointMilitary = false;
            }
            if (player.Have10VictoryPointMilitary)
            {
                player.PointVictoire += -5;
                player.Have10VictoryPointMilitary = false;
            }
        }

        if (_piontJoueur == 3 || _piontJoueur == 4 || _piontJoueur == 5)
        {
            if (player.Have10VictoryPointMilitary)
            {
                player.PointVictoire += -5;
                player.Have10VictoryPointMilitary = false;
            }
        }
    }
}