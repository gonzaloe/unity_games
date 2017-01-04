using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	static BackgroundMusic instance = null;

	void Awake () {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		} else {
			Destroy (gameObject);
			Debug.Log("destroying gameObject");
		}
	}
}
