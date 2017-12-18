using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MyButton {
    private string sceneName;

    public HelpButton()
    {
        sceneName = "Help";
        iclickable = new GoToScene(sceneName);
    }

    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
