using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceen : MonoBehaviour
{
    [SerializeField] private String sceneName;

    // Use this for initialization
    public void openSceen()
    {
        SceneManager.LoadScene(sceneName);
    }
}