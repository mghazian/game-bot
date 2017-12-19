using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
	private const int RandomizeStep = 20;
	private const int UndefinedOrder = -1;

	private Dictionary <int, GameObject> turnOrder;
	private int currentOrder;

    private TimerSystem timer;

	public void Initialize (List <GameObject> player)
	{
		initializeTurnOrder (player);
		registerForEndOfTurn (player);
		GenerateTurnOrder ();
		timer = this.gameObject.AddComponent <TimerSystem>();
		timer.Initialize();
        timer.setTurnSystem(this);
		timer.OnTimerExpired.AddListener (EndTurn);
	}

	/**
	 * @brief Swaps the occurence order of two players
	 * @param int a
	 * @param int b
	 * @return void
	 */
	private void SwapOrder (int a, int b)
	{
		if (a >= turnOrder.Count || b >= turnOrder.Count)
		{
			Debug.LogWarning ("Index to be swapped is (are) out of bound");
			return;
		}

		GameObject temp = turnOrder[a];
		turnOrder[a] = turnOrder[b];
		turnOrder[b] = temp;
	}

	/**
	 * @brief Populates the turnOrder attribute with default value i.e. ascending occurence
	 * order according to the input's order
	 * @param List <GameObject> player
	 * @return void
	 */
	private void initializeTurnOrder (List <GameObject> player)
	{
		turnOrder = new Dictionary <int, GameObject> ();
		for (int i = 0; i < player.Count; i++)
		{
			turnOrder.Add (i, player[i]);
		}
	}

	private void registerForEndOfTurn (List <GameObject> player)
	{
		foreach (var p in player)
		{
			p.GetComponent <Character> ().OnAttacked.AddListener(EndTurn);
		}
	}

	/**
	 * @brief Create a randomized order of players' turn. The generation causes
	 * the existing order to be invalid. That means the supposedly next player to
	 * move could be different.
	 * @return GameObject The first player to move or null if no player is registered in the class
	 */
	public GameObject GenerateTurnOrder ()
	{
		if ( turnOrder.Count == 0 )
		{
			Debug.LogWarning ("Cannot generate turn order: no player is present");
			return null;
		}

		// Randomize
		for (int i = 0; i < RandomizeStep; i++)
		{
			int lhs = i % turnOrder.Count;
			int rhs = Random.Range (0, turnOrder.Count - 1);
			SwapOrder (lhs, rhs);
		}

		// Additional visual cue is to be added here

		currentOrder = 0;
		return turnOrder[0];
	}

	/**
	 * @brief Returns the player whose turn is imminent
	 * @return GameObject or null if no player is registered in the class
	 */
	public GameObject WhoIsActive()
	{
		if (turnOrder.Count == 0)
			return null;
		
		return turnOrder[currentOrder];
	}

	/**
	 * @brief Finished the current player's turn, and move on to the next. Note that
	 * the next player's turn doesn't start immediately by invoking this function.
	 * @return GameObject or null if no player is registered in the class
	 */
	public GameObject NextTurn()
	{
		if (turnOrder.Count == 0)
			return null;
		
		// Additional visual cue is to be added here

		currentOrder = (currentOrder + 1) % turnOrder.Count;
		return turnOrder[currentOrder];
	}

	/**
	 * @brief Starts the current player's turn i.e. enable the player to act
	 * @return void
	 */
	public void BeginTurn ()
	{
		if (turnOrder.Count == 0)
		{
			Debug.LogWarning ("Unable to begin player's turn: no player is present");
			return;
		}

		Character currentPlayer = turnOrder[currentOrder].GetComponent<Character>();
		if ( currentPlayer == null )
		{
			Debug.LogWarning ("Unable to begin player's turn: the player doesn't have Character script attached");
			return;
		}

		currentPlayer.isMovable = true;
        // Start the timer

        float timeToCount = 5;

        timer.begin(timeToCount);
	}

	/**
	 * @brief Ends the current player's turn i.e. stops the player from acting
	 * @return void
	 */
	public void EndTurn ()
	{
		if (turnOrder.Count == 0)
		{
			Debug.LogWarning ("Unable to end player's turn: no player is present");
			return;
		}

		Character currentPlayer = turnOrder[currentOrder].GetComponent<Character>();
		if ( currentPlayer == null )
		{
			Debug.LogWarning ("Unable to end player's turn: the player doesn't have Character script attached");
			return;
		}

		currentPlayer.isMovable = false;
		currentPlayer.isAttackable = false;
		// Dispose the timer
	}
}
