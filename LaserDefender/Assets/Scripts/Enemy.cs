using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public int enemyLife;
	public GameObject shoot;
	public float fireShootSpeed;
	public float shotsFrecuency = 0.5f;
	public int scoreValue = 130;
	public AudioClip fireSound;
	public AudioClip explosionSound;

	private ScoreKeeper scoreKeeper;

	void Start ()
	{
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		var projectile = col.gameObject.GetComponent<Projectile> () as Projectile;
		if (projectile != null) {
			projectile.Hit ();
			enemyLife -= projectile.getDamage ();
			if (enemyLife <= 0) {
				scoreKeeper.Score (scoreValue);
				AudioSource.PlayClipAtPoint (explosionSound, transform.position);
				Destroy (gameObject);
			}
		}
	}

	void Update ()
	{
		var probability = Time.deltaTime * shotsFrecuency;
		if (Random.value < probability) {
			Fire ();
		}
	}

	void Fire ()
	{
		var fireShoot = (GameObject)Instantiate (shoot, new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
		fireShoot.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, -fireShootSpeed, 0);
	}
}
