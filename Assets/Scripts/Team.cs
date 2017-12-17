using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {

    private string teamName;
    List<Character> characters;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Give team name when creating new object
    public Team(string name)
    {
        teamName = name;
    }

    // add a certain Character Object to a certain Team Object
    public void addCharacter(Character objectPointer)
    {
        characters.Add(objectPointer);
    }

    // get all Character of a Team
    public List<Character> getCharacters()
    {
        if(characters.Count != 0)
        {
            return characters;
        }
        else
        {
            return null;
        }
    }
}
