using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour {

	private bool isPlayer1Turn = true;

	void Start () {
		
	}

	void Update () {
		
	}

	public bool checkTurn(){
		return isPlayer1Turn;
	}

	public bool changeTurn(){
		isPlayer1Turn = !isPlayer1Turn;
		return isPlayer1Turn;
	}

}
