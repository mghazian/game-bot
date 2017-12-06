using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public CharacterContainer[] playersContainer = new CharacterContainer[2];
	public SpawnSystem spawnController;
	public GameObject player1;
	public GameObject player2;
	public GameObject map;

	bool isPlayer1 = true;

	private void Start(){
		map = GameObject.Find ("map");
		generateGame ();
	}

	private void generateGame(){
		spawnController = map.GetComponent<SpawnSystem> ();

		spawnController.spawnPlayers (0, playersContainer, player1);
		spawnController.spawnPlayers (1, playersContainer, player2);
	}
		

}
