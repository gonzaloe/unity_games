using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 2.5f;
	public LevelManager levelManager;
	public float spawnDelay = 0.5f;

	private bool movingRight = true;
	private float xMin;
	private float xMax;

	void Start ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMax = rightmost.x - (width / 2);
		xMin = leftmost.x + (width / 2);

		SpawnUntilFull ();
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	void Update ()
	{
		if (AllMembersDead ()) {
			SpawnUntilFull ();
		}

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

	void SpawnUntilFull ()
	{
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	void SpawnEnemies ()
	{
		foreach (Transform child in transform) {
			GameObject enemy = (GameObject)Instantiate (enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}

	Transform NextFreePosition ()
	{
		foreach (Transform child in transform) {
			if (child.childCount <= 0) {
				return child;
			}
		}
		return null;
	}

	bool AllMembersDead ()
	{
		foreach (Transform child in transform) {
			if (child.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
