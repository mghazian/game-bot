﻿using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
	private uint weapon;

	public RangedWeapon (uint damage, uint weapon) : base (damage)
	{
		this.weapon = weapon;
	}

	public void fire ()
	{

	}
}

