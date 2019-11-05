using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //gets the next scene in the que so it will load the level
    public void PlayButton() { SceneManager.LoadScene(/*SceneManager.GetActiveScene().buildIndex + */1); }

    public void QuitButton()
    {
        Debug.Log("Quite Button is working");
        Application.Quit();
    }
}
