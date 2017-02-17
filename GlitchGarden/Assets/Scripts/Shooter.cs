using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, projectileParent, gun;


	private void Fire ()
	{
		GameObject projectileCreated = Instantiate (projectile) as GameObject;
		projectileCreated.transform.parent = projectileParent.transform;
		projectileCreated.transform.position = gun.transform.position;

	}
}
