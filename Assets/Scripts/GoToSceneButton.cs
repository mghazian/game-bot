using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToSceneButton : MyButton {
    [SerializeField]
    public string sceneName;

    void Start()
    {
        iclickable = new GoToScene(sceneName);
        Initialize();
    }
}
