using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

	private Vector2 mapOffset = new Vector2 (-10.0f, 0.0f);
	private GameObject[] player = new GameObject[2];

	void Start () {
		
	}

	void Update () {
		
	}
		
	public void spawnPlayers(int numPlayer, CharacterContainer[] pContainer, GameObject playerToBeSpawn){
		player[numPlayer] = Instantiate (playerToBeSpawn);
		//player.transform.SetParent (transform);
		//CharacterContainer c = player.GetComponent<CharacterContainer> ();
		//c = pContainer [numPlayer];
		placePlayer (numPlayer);
	}

	private void placePlayer(int numPlayer){
		if (numPlayer == 0) {
			player[numPlayer].transform.position = mapOffset;
		} else {
			player[numPlayer].transform.position = (mapOffset * -1)	;
		}
	}
}
