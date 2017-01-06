using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 2.5f;

	private bool movingRight = true;
	private float xMin;
	private float xMax;

	void Start ()
	{
		foreach (Transform child in transform) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;
		}

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMax = rightmost.x - (width / 2);
		xMin = leftmost.x + (width / 2);
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	void Update ()
	{
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (transform.position.x >= xMax) {
			movingRight = false;
		} else if (transform.position.x <= xMin) {
			movingRight = true;
		}
	}
}
