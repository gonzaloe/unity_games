using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public Sprite [] sprites;
	public AudioClip crack;
	public AudioClip boing;
	private int timesHit;
	private LevelManager levelManager;
	public static int bricksBreakablesCount = 0;
	private bool isBreakable;
	public GameObject smoke;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			bricksBreakablesCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits ()
	{
		timesHit++;
		if (timesHit >= (sprites.Length + 1)) {
			AudioSource.PlayClipAtPoint (crack, transform.position);
			bricksBreakablesCount--;
			GameObject puff = (GameObject) Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
			puff.GetComponent<ParticleSystem> ().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
			Destroy (gameObject);
			levelManager.BrickDestroyed ();
		} else {
			AudioSource.PlayClipAtPoint (boing, transform.position, 2f);
			LoadSprites ();
		}
	}

	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (sprites [spriteIndex] != null) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [spriteIndex];
		} else {
			Debug.LogError ("Sprite could not be renderer");
		}
	}
}
