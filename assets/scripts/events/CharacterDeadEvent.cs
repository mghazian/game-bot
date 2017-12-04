using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class CharacterDeadEvent : UnityEvent <int>
{

	public CharacterDeadEvent ()
	{
		this.AddListener ( AddScore );
		this.AddListener ( DisablePlayer );
		this.AddListener ( RegisterForRespawn );
	}

	//	Requires score system
	private void AddScore (int player)
	{

	}

	//	Requires turn system
	private void DisablePlayer (int player)
	{

	}

	//	Requires spawn system
	private void RegisterForRespawn (int player)
	{

	}
}

