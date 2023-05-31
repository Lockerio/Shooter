using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool game_is_paused = false;

    public GameObject pause_menu_UI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_is_paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pause_menu_UI.SetActive(false);
        Time.timeScale = 1f;
        game_is_paused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pause_menu_UI.SetActive(true);
        Time.timeScale = 0f;
        game_is_paused = true;
    }

    public void Load_Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
