using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int min;
	int max;
	int guess;
	string successLevel = "Win";
	string loseLevel = "Lose";
	int maxGuessesAllowed = 11;

	public Text guessText;

	// Use this for initialization
	void Start () {
		max = 1001;
		min = 1;
		NextGuess();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SuccessGuess() {
		Application.LoadLevel(loseLevel);
	}

	public void GuessLower() {
		max = guess;
		NextGuess();
	}

	public void GuessHigher() {
		min = guess;
		NextGuess();
	}

	void NextGuess() {
		guess = Random.Range(min, max);
		guessText.text = guess.ToString();
		maxGuessesAllowed--;
		if(maxGuessesAllowed <= 0) {
			Application.LoadLevel(successLevel);
		}
	}
}
