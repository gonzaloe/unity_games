using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {

	private Animator animator;
	private Attacker attackerScript;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		attackerScript = GetComponent<Attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject colliderObject = collider.gameObject;
		if(colliderObject.GetComponent<Defender> () != null) {
			animator.SetBool ("isAttacking", true);
			attackerScript.Attack (colliderObject);
		}
		Debug.Log ("Collision on fox");
	}
}
