using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 10f;
	public float padding = 0.8f;
	public float fireShootSpeed = 2f;
	public float firingRate = 0.1f;
	public GameObject shoot;
	public int playerLife = 3;
	public AudioClip shootSound;

	private float xMin;
	private float xMax;

	void Start ()
	{
		ScoreKeeper.Reset ();
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
		var fireShoot = (GameObject)Instantiate (shoot, new Vector3(transform.position.x, transform.position.y + .44f, transform.position.z), Quaternion.identity);
		AudioSource.PlayClipAtPoint (shootSound, transform.position);
		fireShoot.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, fireShootSpeed, 0);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		var projectile = col.gameObject.GetComponent<Projectile> () as Projectile;
		if (projectile != null) {
			projectile.Hit ();
			playerLife -= projectile.getDamage ();
			if (playerLife <= 0) {
				Die ();
			}
		}
	}

	void Die ()
	{
		var levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		levelManager.LoadLevel ("Lose");
		Destroy (gameObject);
	}
}
