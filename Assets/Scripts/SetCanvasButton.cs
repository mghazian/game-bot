using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCanvasButton : MyButton {
    [SerializeField]
    public Image activeImage;
    public string imagePath;

    // Use this for initialization
    void Start () {
        iclickable = new SetCanvas(activeImage,imagePath);
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
