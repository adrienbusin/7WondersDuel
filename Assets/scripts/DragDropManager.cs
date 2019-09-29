using UnityEngine;

public class DragDropManager : MonoBehaviour
{
    private AudioSource _audioSourceDown;
    private AudioSource _audioSourceUp;

    public void onDragCardAudio()
    {
        _audioSourceDown = GameObject.FindGameObjectWithTag("DragCardAudio").GetComponent<AudioSource>();
        _audioSourceDown.Play();
    }

    public void onDropCardAudio()
    {
        _audioSourceUp = GameObject.FindGameObjectWithTag("DropCardAudio").GetComponent<AudioSource>();
        _audioSourceUp.Play();
    }
}