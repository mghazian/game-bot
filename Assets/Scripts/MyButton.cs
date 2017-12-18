using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MyButton : MonoBehaviour {
    protected Button parent;
    protected IClickable iclickable;

    protected void Initialize()
    {
        parent = this.gameObject.GetComponent<Button>();
        parent.onClick.AddListener(Down);
    }

    public void Down()
    {
        iclickable.Down();
    }
}
