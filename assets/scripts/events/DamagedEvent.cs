using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class DamagedEvent : UnityEvent <int>
{
	//	TODO: Change 'object' to its proper class
	private object parentCharacter;

	public DamagedEvent (object character)
	{
		parentCharacter = character;
		this.AddListener ( DamageMe );
	}

	private void DamageMe (int value)
	{
		/*
		if ( parentCharacter != null )
			parentCharacter.health -= value;
		*/
	}
}