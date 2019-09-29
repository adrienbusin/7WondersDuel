using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PDFManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> rulesPages;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private Image pageToLoad;


    private int page;

    private void Start()
    {
        previousButton.SetActive(false);
    }

    public void next()
    {
        previousButton.SetActive(true);
        page += 1;
        if (page == 19)
        {
            nextButton.SetActive(false);
        }
        afficherPage();
    }

    public void previous()
    {
        page += -1;
        nextButton.SetActive(true);
        if (page == 0)
        {
            previousButton.SetActive(false);
        }
        afficherPage();
    }

    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    private void afficherPage()
    {
        pageToLoad.sprite = rulesPages[page];
    }
}