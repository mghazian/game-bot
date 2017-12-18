using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScore : MonoBehaviour {

    private Character characterObject;
    private int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Class Constructor need Character Object to be created
    public CharacterScore(Character objectPointer)
    {
        characterObject = objectPointer;
        score = 0;
    }

    // Compare if a certain Character is the object's Character
    public bool characterCompare(Character objectPointer)
    {
        if(characterObject == objectPointer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Add Score based on Points obtained
    public void addScore(int point)
    {
        score += point;
    }

    // Get the current Score of a certain Character 
    public int getCurrentScore()
    {
        return score;
    }
}
