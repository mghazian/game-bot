using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem
{
	private const int RandomizeStep = 20;

	private List <int> turnOrder;
	private int currentOrder;

	public int playerNumber { get; set; }

	public TurnSystem (int playerAmount)
	{
		turnOrder = new List <int> ();
		playerNumber = playerAmount;
		GenerateTurnOrder ();
	}

	private void SwapOrder (int a, int b)
	{
		if (a >= playerNumber || b >= playerNumber)
		{
			Debug.LogWarning ("Index to be swapped is (are) out of bound");
			return;
		}

		int temp = turnOrder[a];
		turnOrder[a] = turnOrder[b];
		turnOrder[b] = temp;
	}

	public int GenerateTurnOrder ()
	{
		if ( playerNumber == 0 )
		{
			Debug.LogWarning ("Cannot generate turn order: no player is present");
			return -1;
		}

		turnOrder.Clear();

		// Populate
		for (int i = 0; i < playerNumber; i++)
		{
			turnOrder.Add (i);
		}

		// Randomize
		for (int i = 0; i < RandomizeStep; i++)
		{
			int lhs = i % playerNumber;
			int rhs = Random.Range (0, playerNumber - 1);
			SwapOrder (lhs, rhs);
		}

		// Additional visual cue is to be added here

		currentOrder = 0;
		return turnOrder[0];
	}

	public int WhoIsActive()
	{
		if (playerNumber == 0)
			return -1;
		
		return turnOrder[currentOrder];
	}

	public int changeTurn()
	{
		if (playerNumber == 0)
			return -1;
		
		// Additional visual cue is to be added here
		currentOrder = (currentOrder + 1) % playerNumber;
		return turnOrder[currentOrder];
	}
}
