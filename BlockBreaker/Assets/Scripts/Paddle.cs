using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

	float mousePosInBlocks = 0;
	public bool autoPlay = false;
	private Ball ball;

	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void MoveWithMouse ()
	{
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		this.transform.position = new Vector3 (Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
	}

	void AutoPlay ()
	{
		Vector3 ballPos = ball.transform.position;
		this.transform.position = new Vector3 (Mathf.Clamp (ballPos.x, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
	}
}
