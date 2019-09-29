using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTokenManagerRestant : MonoBehaviour
{
    public List<GameObject> tokens;
    private ProgressTokenManager _progressTokenManager;

    private int TokenRestantToChoose;
    private List<GameObject> tokenRestantChoosen = new List<GameObject>();

    public List<GameObject> TokenRestantChoosen
    {
        get { return tokenRestantChoosen; }
        set { tokenRestantChoosen = value; }
    }

    private void Start()
    {
        _progressTokenManager =
            GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<ProgressTokenManager>();
        initializeTokens();
    }

    void initializeTokens()
    {
        for (int i = 0; i < 5; i++)
        {
            Sprite token = _progressTokenManager.getTokenFace(i + 5);

            for (int j = 5; j < 10; j++)
            {
                if (_progressTokenManager.tokenFaces[j] == token)
                {
                    tokens[i].GetComponent<ProgressToken>().TokenValue = j;
                    break;
                }
            }

            tokens[i].GetComponent<ProgressToken>().TokenFace = token;
            tokens[i].SetActive(false);
            tokens[i].GetComponent<ProgressToken>().TokenRestant = true;
            tokens[i].SetActive(true);
        }
    }

    public void HideAllTokens()
    {
        foreach (GameObject gameObject in tokens)
        {
            gameObject.SetActive(false);
        }
    }
}