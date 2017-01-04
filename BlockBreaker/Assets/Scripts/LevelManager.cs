using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel (string levelName)
	{
		Debug.Log ("Level load requested for: " + levelName);
		Brick.bricksBreakablesCount = 0;
		Application.LoadLevel (levelName);
	}

	public void QuitLevel ()
	{
		Debug.Log ("Quit Game requested");
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		Brick.bricksBreakablesCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed ()
	{
		if (Brick.bricksBreakablesCount <= 0) {
			LoadNextLevel ();
		}
	}
}
