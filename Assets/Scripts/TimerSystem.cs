using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour {

	public Text timerText;
	private float startTime;
    private float timeToCount;

    // Use this for initialization
    TimerSystem(float time) {
        timeToCount = time;
    }

    private void printTimerText(string textToWrite)
    {
        timerText.text = textToWrite;
    }

    void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float timeLength = Time.time - startTime;

        //string seconds = timeLength.ToString ("f0");
        string timeLeft = (timeToCount - timeLength).ToString("f0");
        printTimerText(timeLeft);
	}

    // Print end of turn
    void Stop() {
        printTimerText("End Turn");
    }

    //To Stop Timer while still counting
    public void endTimer() {
        Stop();
    }
}
