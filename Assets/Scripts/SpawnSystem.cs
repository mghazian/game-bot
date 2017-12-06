using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

	private Vector2 mapOffset = new Vector2 (-10.0f, 0.0f);

	void Start () {
		
	}

	void Update () {
		
	}
		
	public void spawnPlayers(int numPlayer, CharacterContainer[] pContainer, GameObject playerToBeSpawn){
		GameObject player = Instantiate (playerToBeSpawn) as GameObject;
		player.transform.SetParent (transform);
		CharacterContainer c = player.GetComponent<CharacterContainer> ();
		pContainer [numPlayer] = c;
		placePlayer (player,numPlayer);
	}
		

	private void placePlayer(GameObject cc, int numPlayer){
		if (numPlayer == 0) {
			cc.transform.position = mapOffset;
		} else {
			cc.transform.position = (mapOffset * -1);
		}
	}
}
