using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;
	public Canvas canvasParent;

	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			Fade ();
		} else {
			gameObject.SetActive (false);
		}
	}

	void Fade ()
	{
		float alphaChange = Time.deltaTime / fadeInTime;
		currentColor.a -= alphaChange;
		fadePanel.color = currentColor;
	}
}
