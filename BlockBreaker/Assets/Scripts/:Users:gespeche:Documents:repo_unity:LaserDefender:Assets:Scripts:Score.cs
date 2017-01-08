using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	private const string preScore = "Score: ";
	public int score = 0;
	public Text myText;

	void Start ()
	{
		myText = GetComponent<Text> ();
	}

	public void Score (int points)
	{
		score += points;
		myText = score.ToString ();
	}

	public void Reset ()
	{
		score = 0;
	}
}
