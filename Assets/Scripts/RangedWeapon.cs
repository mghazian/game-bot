using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
	private string resourcePath;
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
		projectile.transform.position = gameObject.transform.position;
		projectilePrefab.GetComponent<Rigidbody2D>().velocity = new Vector2 (XDistance (angle, power), YDistance (angle, power));
	}

	private float XDistance (float angleInDegree, float distance)
	{
		return Mathf.Cos (angleInDegree) * distance;
	}

	private float YDistance (float angleInDegree, float distance)
	{
		return Mathf.Sin (angleInDegree) * distance;
	}
}

