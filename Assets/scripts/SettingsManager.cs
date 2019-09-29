using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

	public GameObject Sound;
	private GameObject _quitButton;
	public List<Sprite> SoundOnOff;
	private AudioSource _musique;
	private bool _soundOff;
	private bool _quit;


	private void Start()
	{
		_musique = GameObject.FindGameObjectWithTag("musique_jeu").GetComponent<AudioSource>();
		_quitButton = GameObject.FindGameObjectWithTag("Quit");
	}

	public void OnClickSound()
	{
		if (_soundOff)
		{
			Sound.GetComponent<Image>().sprite = SoundOnOff[1];
			_musique.mute = false;
			_soundOff = false;
		}
		else
		{
			Sound.GetComponent<Image>().sprite = SoundOnOff[0];
			_musique.mute = true;
			_soundOff = true;
		}
	}

	public void OnClickQuit()
	{
		if (!_quit)
		{
			ColorBlock cb = _quitButton.GetComponent<Button>().colors;
			cb.normalColor = Color.red;
			_quitButton.GetComponent<Button>().colors = cb;
			_quit = true;
		}
		else
		{
			SceneManager.LoadScene("Menu");
		}
	}
	public void OpenHelp(){
		SceneManager.LoadScene("Help");
	}

	public bool Quit
	{
		get { return _quit; }
		set
		{
			if (!value)
			{
				_quit = value;
				_quitButton = GameObject.FindGameObjectWithTag("Quit");

					ColorBlock cb = _quitButton.GetComponent<Button>().colors;
					cb.normalColor = Color.white;
					_quitButton.GetComponent<Button>().colors = cb;
				
			}
		}
	}
}
