using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
	private string resourcePath = "Projectile";
	private GameObject projectilePrefab;
	public float angle { get; set; }
	public float power { get; set; }

	void Start ()
	{
		if (resourcePath != null)
		{
			projectilePrefab = Resources.Load (resourcePath) as GameObject;
		}
	}

	public override void Fire ()
	{
		var projectile = Instantiate (projectilePrefab);
		projectile.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 4f);
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

