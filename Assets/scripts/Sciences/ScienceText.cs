using UnityEngine;

public class ScienceText : MonoBehaviour
{
    [SerializeField] private bool _textVisible;

    private void Start()
    {
        if (_textVisible)
        {
            setActive(true);
        }
        else
        {
            setActive(false);
        }
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }
}