using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageButton : MyButton {
    [SerializeField]
    public Image activeImage;
    public string imagePath;

    // Use this for initialization
    void Start () {
        iclickable = new SetImage(activeImage,imagePath);
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
