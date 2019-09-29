using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public List<Sprite> Backgrounds;

    public void changeBackground(int age)
    {
        switch (age)
        {
            case 2:
                gameObject.GetComponent<Image>().sprite = Backgrounds[0];
                break;
            case 3:
                gameObject.GetComponent<Image>().sprite = Backgrounds[1];
                break;
        }
    }
}