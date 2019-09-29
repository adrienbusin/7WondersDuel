using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        List<GameObject> objectToNotDestroy = new List<GameObject>();
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("MenuManager"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("MenuAudio"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("ClickOutAudio"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("ClickInAudio"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("CanvasMenu"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("EventSytem"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("MainCamera"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("Logo"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("rules"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("play_txt"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("playButton"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("background"));
        objectToNotDestroy.Add(GameObject.FindGameObjectWithTag("Settings"));

        foreach (GameObject o in FindObjectsOfType<GameObject>())
        {
            var findGameObjectWithTag = o;
            if (findGameObjectWithTag == GameObject.FindGameObjectWithTag("play_txt"))
            {
                o.SetActive(true);
            }
            if (!objectToNotDestroy.Contains(o))
            {
                Destroy(o);
            }
        }
    }
}