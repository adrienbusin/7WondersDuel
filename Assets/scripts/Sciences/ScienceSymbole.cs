using UnityEngine;
using UnityEngine.UI;

public class ScienceSymbole : MonoBehaviour
{
    private int _symboleValue;

    public bool _symboleVisible;

    private Sprite _symboleFace;


    private void Start()
    {
        if (_symboleVisible)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    public Sprite SymboleFace
    {
        get { return _symboleFace; }
        set
        {
            _symboleFace = value;
            gameObject.GetComponent<Image>().sprite = value;
            gameObject.SetActive(true);
        }
    }
}