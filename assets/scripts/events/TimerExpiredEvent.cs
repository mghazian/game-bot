using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TimerExpiredEvent : UnityEvent
{
	public TimerExpiredEvent ()
	{
		this.AddListener ( NextPlayer );
	}

	//	Requires turn system
	public void NextPlayer ()
	{

	}
}

