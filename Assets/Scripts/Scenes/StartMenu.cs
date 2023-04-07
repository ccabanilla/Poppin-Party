using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartButton() 
    {
        SceneManager.LoadScene("Level Select");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Timed");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
