using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 10f;
	public float padding = 0.8f;
	public float fireShootSpeed = 2f;
	public float firingRate = 0.1f;
	public GameObject shoot;

	private float xMin;
	private float xMax;

	void Start ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.01e-23f, firingRate);
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}

	void Fire ()
	{
		var fireShoot = (GameObject)Instantiate (shoot, transform.position, Quaternion.identity);
		fireShoot.rigidbody2D.velocity = new Vector3 (0, fireShootSpeed, 0);
	}
}
