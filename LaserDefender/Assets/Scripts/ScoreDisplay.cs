using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
		Text myScore = GetComponent<Text> ();
		myScore.text = ScoreKeeper.score.ToString();
	}

}
