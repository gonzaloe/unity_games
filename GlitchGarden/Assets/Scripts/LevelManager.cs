using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public float autoLoadTime;

	void Start ()
	{
		if (!(autoLoadTime <= 0)) {
			Invoke ("LoadNextLevel", autoLoadTime);
		}
	}

	public void LoadLevel (string levelName)
	{
		Debug.Log ("Level load requested for: " + levelName);
		Application.LoadLevel (levelName);
	}

	public void QuitLevel ()
	{
		Debug.Log ("Quit Game requested");
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
