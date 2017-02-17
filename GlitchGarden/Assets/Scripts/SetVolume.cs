using UnityEngine;
using System.Collections;

public class SetVolume : MonoBehaviour
{

	private MusicManager musicManager;

	// Use this for initialization
	void Start ()
	{
		musicManager = FindObjectOfType<MusicManager> ();
		if (musicManager) {
			musicManager.ChangeVolume (PlayerPrefsManager.GetMasterVolume ());
		}
	}
}
