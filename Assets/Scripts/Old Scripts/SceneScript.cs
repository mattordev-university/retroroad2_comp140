using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
 
    public void LoadGame()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void LoadFail()
    {
        SceneManager.LoadScene(2);

    }

    public void LoadGameBlah()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }

    public void LoadGameCiRc()
    {
        SceneManager.LoadScene(4);
    }

    public void Reload1STMap()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}