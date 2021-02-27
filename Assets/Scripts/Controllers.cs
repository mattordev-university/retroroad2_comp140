using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controllers : MonoBehaviour
{

    

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    bool OpenCont = false;

    private void Start()
    {
        OpenCont = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenCont = Input.GetButtonUp("OpenControls");

        if (OpenCont == true)
        {
            if (GameIsPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}