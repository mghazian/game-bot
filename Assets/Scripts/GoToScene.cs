using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : IClickable {

    private string sceneName;
    public GoToScene(string name)
    {
        sceneName = name;
    }

    public void Down()
    {
        SceneManager.LoadScene(sceneName);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
