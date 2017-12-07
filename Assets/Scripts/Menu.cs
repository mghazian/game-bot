using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button btn_play,btn_exit,btn_help;

    void Start () {
        btn_play.onClick.AddListener(GoToPlay);
        btn_help.onClick.AddListener(GoToHelp);
        btn_exit.onClick.AddListener(ExitApplication);
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void GoToHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}