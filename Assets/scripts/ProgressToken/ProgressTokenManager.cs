using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTokenManager : MonoBehaviour
{
    public List<GameObject> tokens;
    public List<Sprite> tokenFaces;
    private List<Sprite> tmpTokenFaces;

    void Start()
    {
        initializeTokens();
    }

    void shuffleCardFace()
    {
        tmpTokenFaces = new List<Sprite>(tokenFaces);
        for (int i = 0; i < tmpTokenFaces.Count; i++)
        {
            Sprite temp = tmpTokenFaces[i];
            int randomIndex = Random.Range(i, tmpTokenFaces.Count);
            tmpTokenFaces[i] = tmpTokenFaces[randomIndex];
            tmpTokenFaces[randomIndex] = temp;
        }
    }

    void initializeTokens()
    {
        shuffleCardFace();

        for (int i = 0; i < 5; i++)
        {
            Sprite token = getTokenFace(i);


            for (int j = 0; j < 10; j++)
            {
                if (tokenFaces[j] == token)
                {
                    tokens[i].GetComponent<ProgressToken>().TokenValue = j;
                }
            }

            tokens[i].GetComponent<ProgressToken>().TokenFace = token;

            tokens[i].GetComponent<Image>().sprite = tokens[i].GetComponent<ProgressToken>().TokenFace;
        }
    }

    public Sprite getTokenFace(int indexTokenFace)
    {
        return tmpTokenFaces[indexTokenFace];
    }

    public void setAllPlayableToken(bool playable)
    {

        GameObject.FindGameObjectWithTag("hideShowAllCards").GetComponent<HideShowAllCards>()
            .hideShowAllCards(!playable, true);
        for (int i = 0; i < 5; i++)
        {
            if (!tokens[i].GetComponent<ProgressToken>().TokenPlayed)
            {
                tokens[i].GetComponent<ProgressToken>().TokenPlayable = playable;
            }
        }
    }
}