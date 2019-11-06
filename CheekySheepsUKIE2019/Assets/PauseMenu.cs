using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PasMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                //GamePas();
                Unpause();
            }
            else
            {
                //Unpause();
                GamePas();
            }

        }
    }

    void Unpause()
    {
        PasMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void GamePas()
    {
        PasMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
