using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
	private List <GameObject> characters;
	private SpawnSystem spawnController;
	private TurnSystem turnController;
	private SimpleScoringSystem scoreController;

	private GameObject map;

	public GameObject playerPrefab;

	private void Start()
	{
		characters = new List <GameObject> ();
		map = GameObject.Find ("ground");
		//generatePlayers ();
		spawnController = new SpawnSystem();
		scoreController = gameObject.AddComponent<SimpleScoringSystem>();
		scoreController.Initialize();
		turnController = gameObject.AddComponent<TurnSystem>();
	}

	void Update(){
		/*Game Phases:
			- Player idle
			- Player choose weapon
			- Player shoot
			- Change turn
			(Repeat process until somone dies)
		*/
		if (Input.GetKeyDown (KeyCode.P))
		{
			// check player, game will start when player press space
			playerMove();
			Debug.Log ("Game started");
			//player1Turn = turnController.changeTurn;
			generatePlayers(2);
			turnController.Initialize (characters);
			turnController.GenerateTurnOrder();
			turnController.BeginTurn();
		}

		if (Input.GetKeyDown (KeyCode.A))
		{
			turnController.EndTurn();
			turnController.NextTurn();

			var player = turnController.WhoIsActive();
			if (player.GetComponent<Character>().isDead)
				spawnController.SpawnPlayer (player);

			turnController.BeginTurn();
		}
	}

	private void generatePlayers (int playerNumber)
	{
		for (int i = 0; i < playerNumber; i++)
		{
			GameObject go = Instantiate (playerPrefab);
			go.GetComponent<Character>().Initialize();
			Debug.Log (i + " " + go.GetComponent<Character>());
			characters.Add (go);
			scoreController.addCharacter (go.GetComponent<Character>());
			spawnController.SpawnPlayer (go);
		}
	}

	private void playerMove()
	{

	}
}
