using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip [] levelMusicArray;
	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded (int lvl)
	{
		int level = lvl - 1;
		AudioClip levelMusic = levelMusicArray [level];
		if (levelMusic) {
			audioSource.clip = levelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
