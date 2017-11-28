using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	private uint id { get; }
	private uint health { get; set; }

	private uint scalarSpeed { get; set; }
	private uint jumpHeight { get; set; }

	// More personalization e.g. skins etc.
	// ...

	// Weapons
	// ...

	// State
	// ...

	public Character (uint id, uint scalarSpeed, uint jumpHeight)
	{
		this.id = id;
		this.scalarSpeed = scalarSpeed;
		this.jumpHeight = jumpHeight;
	}
}
