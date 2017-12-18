using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

    public class CharacterScore
    {
        private Character character;
        private int score;
        public CharacterScore(Character characterObject)
        {
            character = characterObject;
        }

        public bool characterCompare(Character characterObject)
        {
            if(character == characterObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addScore(int point)
        {
            score += point;
        }

        public int getCurrentScore()
        {
            return score;
        }
    }

    private CharacterScore[] characterScore;
    private int numberOfCharacter;
	// Use this for initialization
	void Start () {
        numberOfCharacter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addCharacterScore(Character characterObject)
    {
        characterScore[numberOfCharacter] = new CharacterScore(characterObject);
        numberOfCharacter++;
    }

    public void addScoreToCharacter(Character characterObject, int point)
    {
        for(int i = 0;i < numberOfCharacter; i++)
        {
            if(characterScore[i].characterCompare(characterObject))
            {
                characterScore[i].addScore(point);
            }
        }
    }
}
