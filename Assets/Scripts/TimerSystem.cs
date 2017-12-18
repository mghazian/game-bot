using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem {

	public Text timerText;
	private float startTime;
    private float timeToCount;

    private TurnSystem turnSystem;

    // Use this for initialization
    public TimerSystem(TurnSystem system) {
        turnSystem = system;
        timeToCount = 0;
    }

    private void printTimerText(string textToWrite)
    {
        timerText.text = textToWrite;
    }

    public void begin(float time)
    {
        timeToCount += time;
        float startTime = Time.time;
        float timeLength = Time.time - startTime;
        
        while((timeToCount - timeLength)>0)
        {
            string timeLeft = (timeToCount - timeLength).ToString("f0");
            printTimerText(timeLeft);
        }
        
        end();
    }

    public void end()
    {
        timeToCount = 0;
        turnSystem.EndTurn();
    }
}
