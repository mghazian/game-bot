using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	protected uint damage;

	public Weapon (uint damage)
	{
		this.damage = damage;
	}

	public abstract void Fire ();
}

