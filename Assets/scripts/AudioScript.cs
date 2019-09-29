using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}