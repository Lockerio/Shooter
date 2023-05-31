using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public Animator transition;
    public float transition_time = 1f;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(0);
            }
        }
    }

    public void Load_Next_Level()
    {
        StartCoroutine(Load_Level(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Load_Level(int level_index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transition_time);
        SceneManager.LoadScene(level_index);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
