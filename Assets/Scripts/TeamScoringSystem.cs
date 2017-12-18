using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScoringSystem : SimpleScoringSystem {

    private List<Team> teams;

    public void addTeam(string teamName, List<Character> characters)
    {
        Team newTeam = new Team(teamName);
        foreach (var character in characters)
        {
            newTeam.addCharacter(character);
        }
    }

    public int getTeamScore(string teamName)
    {
        int teamScoreValue = 0;
        foreach(var team in teams)
        {
            if(team.teamNameCompare(teamName))
            {
                List<Character> characters;
                characters = team.getCharacters();
                foreach(var character in characters)
                {
                    foreach(var characterScore in characterScores)
                    {
                        if(characterScore.characterCompare(character))
                        {
                            teamScoreValue += characterScore.getCurrentScore();
                        }
                    }
                }
            }
        }
        return teamScoreValue;
    }
}
