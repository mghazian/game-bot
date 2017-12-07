using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public CharacterContainer[] playersContainer = new CharacterContainer[2];
	public SpawnSystem spawnController;
	public TurnSystem turnController;

	public GameObject player1;
	public GameObject player2;
	public GameObject map; 	
	public bool player1Turn;
	public bool gameIsOver = false;

	private void Start(){
		map = GameObject.Find ("map");
		generatePlayers ();
	}

	void Update(){
		/*Game Phases:
			- Player idle
			- Player choose weapon
			- Player shoot
			- Change turn
			(Repeat process until somone dies)
		*/
		if (Input.GetKeyDown (KeyCode.Space)) { // check player, game will start when player press space
			TimerSystem timerController; 
			playerMove();
			//player1Turn = turnController.changeTurn;
		}

	}

	private void generatePlayers(){
		spawnController = map.GetComponent<SpawnSystem> ();
		spawnController.spawnPlayers (0, playersContainer, player1);
		spawnController.spawnPlayers (1, playersContainer, player2);

	}

	private void playerMove(){

	}

}
