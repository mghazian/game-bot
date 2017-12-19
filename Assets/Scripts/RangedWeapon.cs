using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
	private string resourcePath = "Projectile";
	private float firingOffsetRadii = 2f; // TODO: Adjust accordingly
	private GameObject projectilePrefab;
	public float angle { get; set; }
	public float power { get; set; }
	private int damage;

	void Start ()
	{
		damage = 100;
		if (resourcePath != null)
		{
			projectilePrefab = Resources.Load (resourcePath) as GameObject;
		}
	}

	public override void Fire ()
	{
		var projectile = Instantiate (projectilePrefab);
		projectile.GetComponent <Projectile>().damage = damage;

		Vector3 v3 = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y);
		Vector3 offset = new Vector3 ( XDistance (angle, firingOffsetRadii), YDistance (angle, firingOffsetRadii));
		projectile.transform.position = v3 + offset;

		projectile.GetComponent<Rigidbody2D>().AddForce (new Vector2 (XDistance (angle, power), YDistance (angle, power)));
		Debug.Log (XDistance (angle, power) + " " + YDistance (angle, power));

		angle = 0;
		power = 0;
	}

	private float XDistance (float angleInDegree, float distance)
	{
		return Mathf.Cos (angleInDegree * Mathf.PI / 180) * distance;
	}

	private float YDistance (float angleInDegree, float distance)
	{
		return Mathf.Sin (angleInDegree * Mathf.PI / 180) * distance;
	}
}

