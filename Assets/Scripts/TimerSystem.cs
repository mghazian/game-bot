using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

	public Text timerText;
	private float startTime;
    private float timeToCount;
    private bool isTimer;

    private TurnSystem turnSystem;

    // Use this for initialization
    void Start()
    {
        isTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        float startTime = Time.time;
        float timeLength = Time.time - startTime;

        if (isTimer)
        {
            if((timeToCount - timeLength)>0)
            {
                string timeLeft = (timeToCount - timeLength).ToString("f0");
                printTimerText(timeLeft);
            }
            else
            {
                end();
            }
        }
    }


    public void setTurnSystem(TurnSystem system) {
        turnSystem = system;
    }

    private void printTimerText(string textToWrite)
    {
        timerText.text = textToWrite;
    }

    public void begin(float time)
    {
        timeToCount += time;
        isTimer = true;
    }

    public void end()
    {
        timeToCount = 0;
        isTimer = false;
        turnSystem.EndTurn();
    }
}
