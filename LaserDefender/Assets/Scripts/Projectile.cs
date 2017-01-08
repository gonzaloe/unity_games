using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int damage;

	public int getDamage ()
	{
		return damage;
	}

	public void Hit ()
	{
		Destroy (gameObject);
	}
}
