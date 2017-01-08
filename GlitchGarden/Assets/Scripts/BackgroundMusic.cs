using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{

	static BackgroundMusic instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;

	void Start ()
	{
		music = GetComponent<AudioSource> ();
		if (instance != null && instance != this) {
			Destroy (gameObject);

		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
			music.clip = startClip;
			music.loop = true;
			music.volume = 0.5f;
			music.Play ();
		}
	}

	void OnLevelWasLoaded (int level)
	{
		music.Stop ();
		if (level == 0) {
			music.clip = startClip;
		} else if (level == 1) {
			music.clip = gameClip;
		} else if (level == 2) {
			music.clip = endClip;
		}

		music.Play ();
	}
}
