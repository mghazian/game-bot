using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScoringSystem : MonoBehaviour {

    protected List<CharacterScore> characterScores;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Add new character Score of a certain Character
    public void addCharacter(Character objectPointer)
    {
        CharacterScore newCharacterScore = new CharacterScore(objectPointer);
        characterScores.Add(newCharacterScore);
    }

    // add score to a certain character in characterscores list 
    public void addScoreToPlayer(Character objectPointer, int point)
    {
        foreach(var characterScore in characterScores)
        {
            if(characterScore.characterCompare(objectPointer))
            {
                characterScore.addScore(point);
            }
        }
    }

    // get a certain Character Current Score
    public int getPlayerScore(Character objectPointer)
    {
        int characterScoreValue = 0;
        foreach (var characterScore in characterScores)
        {
            if (characterScore.characterCompare(objectPointer))
            {
                characterScoreValue += characterScore.getCurrentScore();
            }
        }
        return characterScoreValue;
    }
}
