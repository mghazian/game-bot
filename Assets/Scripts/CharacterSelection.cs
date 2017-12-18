using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

	private GameObject[] characterList;
	private int index;

	void Start () {
		index = PlayerPrefs.GetInt("CharacterSelected");
		characterList = new GameObject[transform.childCount];

		for(int i = 0; i < transform.childCount; i++){
			characterList [i] = transform.GetChild (i).gameObject;
		}

		foreach (GameObject go in characterList) {
			go.SetActive (false);
		}

		if (characterList [index]) {
			characterList [index].SetActive (true);
		}
	}

	public void toggleLeft(){
		if (index > 0) {
			characterList [index].SetActive (false);
			index = index - 1;
			characterList [index].SetActive (true); 
		}
		/*
		characterList [index].SetActive (false);

		index = index - 1;
		if (index < 0) {
			index = characterList.Length - 1;
		}

		characterList [index].SetActive (true); 
		*/
	}

	public void toggleRight(){
		if (index < characterList.Length - 1) {
			characterList [index].SetActive (false);
			index = index + 1;
			characterList [index].SetActive (true); 
		}
		/*
		characterList [index].SetActive (false);

		index = index + 1;
		if (index == characterList.Length) {
			index = 0;
		}

		characterList [index].SetActive (true); 
		*/
	}

	public void selectButton(){
		PlayerPrefs.SetInt ("CharacterSelected", index);
		SceneManager.LoadScene ("Main Game");
	}
}
