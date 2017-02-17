using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{

	[Range (-1f, 1.5f)]
	public float defaultWalkSpeed;
	private float walkSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();	
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
	}

	public void OnSetWalking (float speed)
	{
		if (speed >= 10) {
			walkSpeed = defaultWalkSpeed;
		} else {
			walkSpeed = speed;
		}
	}

	public void OnSetAttackBehaviour (float damage)
	{
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			health.DamageTaken (damage);
		} else {
			animator.SetBool ("isAttacking", false);
		}
		Debug.Log ("Damage dealt: " + damage);
	}

	public void Attack (GameObject obj)
	{
		walkSpeed = 0;
		currentTarget = obj;
	}
}
