using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{

	private List <GameObject> characters;
	private SpawnSystem spawnController;
	private TurnSystem turnController;

	private GameObject map;

	public GameObject playerPrefab;

	private void Start(){
		characters = new List <GameObject> ();
		map = GameObject.Find ("ground");
		//generatePlayers ();
		turnController = new TurnSystem(2);
		spawnController = new SpawnSystem();
	}

	void Update(){
		/*Game Phases:
			- Player idle
			- Player choose weapon
			- Player shoot
			- Change turn
			(Repeat process until somone dies)
		*/
		if (Input.GetKeyDown (KeyCode.Space))
		{
			// check player, game will start when player press space
			TimerSystem timerController; 
			playerMove();
			Debug.Log ("Game started");
			//player1Turn = turnController.changeTurn;
			generatePlayers(5);
			turnController.playerNumber = 5;
			turnController.GenerateTurnOrder();
		}

	}

	private void generatePlayers (int playerNumber)
	{
		for (int i = 0; i < playerNumber; i++)
		{
			GameObject go = Instantiate (playerPrefab);
			Debug.Log (i + " " + go);
			characters.Add (go);
			spawnController.SpawnPlayer (go);
		}
	}

	private void playerMove(){

	}

}
