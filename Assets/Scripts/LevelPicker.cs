using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{
    public GameObject TutMapButton;
    public GameObject firstmapbutton;
    public int onLevel = 0;

    // Use this for initialization
    void Start()
    {
        //TutMapButton = GameObject.FindGameObjectWithTag("tutmapbutton").GetComponent<GameObject>();
        //firstmapbutton = GameObject.FindGameObjectWithTag("firstmapbutton").GetComponent<GameObject>();

        TutMapButton.SetActive(false);
        firstmapbutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (onLevel == 1)
        {
            //LoadLevel1();
            TutMapButton.SetActive(true);
            firstmapbutton.SetActive(false);
        }

        if (onLevel == 2)
        {
            //LoadLevel2();
            firstmapbutton.SetActive(true);
            TutMapButton.SetActive(false);
            
        }
    }

    public void Picker()
    {
        if (EventSystem.current.currentSelectedGameObject.tag == "TutorialMap")
        {
            onLevel = 1;
        }

        if (EventSystem.current.currentSelectedGameObject.tag == "1stMap")
        {
            onLevel = 2;
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(4);
        //Time.timeScale = 1;
        Debug.Log("BoofS");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(1);
        //Time.timeScale = 1;
    }
}

