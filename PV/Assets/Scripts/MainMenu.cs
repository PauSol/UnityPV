using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void GoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
