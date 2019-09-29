using UnityEngine;
using UnityEngine.EventSystems;

public class clickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AudioSource _audioSourceDown;
    private AudioSource _audioSourceUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSourceDown = GameObject.FindGameObjectWithTag("ClickInAudio").GetComponent<AudioSource>();
        _audioSourceDown.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _audioSourceUp = GameObject.FindGameObjectWithTag("ClickOutAudio").GetComponent<AudioSource>();
        _audioSourceUp.Play();
    }
}