using UnityEngine;
using System.Collections;

public class Weapon
{
	private uint damage;

	public Weapon (uint damage)
	{
		this.damage = damage;
	}

	abstract void fire ();
}

