using UnityEngine;
using System.Collections;

public class MenuOptions : MonoBehaviour {

	public AudioClip click;

	AudioSource audio;

	private void Awake() {
		audio = GetComponent<AudioSource>();
	}

	public void StartGame () {
		audio.PlayOneShot(click);
		Application.LoadLevel("Level01");
	}

	public void QuitGame () {
		audio.PlayOneShot(click);
		Application.Quit();
	}

}
