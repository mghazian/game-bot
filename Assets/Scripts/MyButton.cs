using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyButton : Button {


    protected IClickable iclickable;

    public MyButton()
    {
        this.onClick.AddListener(Down);
    }
    public void Down()
    {
        iclickable.Down();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
