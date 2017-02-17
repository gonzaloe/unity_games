using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0 && volume <= 1) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Could not set the master volume to given value: " + volume);
		}
	}

	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty >= 0 && difficulty <= 1) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Could not set the difficulty to given value: " + difficulty);
		}
	}

	public static float GetDifficulty ()
	{
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level, 1);
		} else {
			Debug.LogError ("Tried to unlock a level that's not on the build order");
		}
	}

	public static bool IsLevelUnlocked (int level)
	{
		return (PlayerPrefs.GetInt (LEVEL_KEY + level) == 1);
	}
}
