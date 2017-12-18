using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : IClickable {

    private Image activeImage;
    private string imagePath;

    public SetImage(Image active_image, string image_path)
    {
        activeImage = active_image;
        imagePath = image_path;
    }

    public void Down()
    {
        activeImage.sprite = Resources.Load<Sprite>(imagePath);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
