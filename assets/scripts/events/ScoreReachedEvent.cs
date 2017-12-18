using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ScoreReachedEvent : UnityEvent
{
	public ScoreReachedEvent ()
	{
		this.AddListener ( EndGame );
	}

	//	Requires game system?
	private void EndGame ()
	{

	}
}

