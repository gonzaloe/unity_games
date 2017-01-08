using UnityEngine;
using System.Collections;

public class SplashMusic : MonoBehaviour {

	public AudioClip audioClip;

	void Start () {
		AudioSource.PlayClipAtPoint (audioClip, transform.position);
	}
}
