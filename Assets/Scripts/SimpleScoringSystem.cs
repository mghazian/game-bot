using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScoringSystem : MonoBehaviour {

    protected List<CharacterScore> characterScores;

	public void Initialize ()
	{
		characterScores = new List<CharacterScore>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ScoreDebug (Character scoringCharacter)
	{
		Debug.Log (scoringCharacter + " SCORED [Score " + getPlayerScore (scoringCharacter) + "]");
	}

    // Add new character Score of a certain Character
    public void addCharacter(Character objectPointer)
    {
		objectPointer.OnDead.AddListener(CharacterDeadScoreHandler);
		objectPointer.OnDead.AddListener(ScoreDebug);
        CharacterScore newCharacterScore = new CharacterScore(objectPointer);
        characterScores.Add(newCharacterScore);
    }

	private void CharacterDeadScoreHandler (Character objectPointer)
	{
		addScoreToPlayer (objectPointer, 1);
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
