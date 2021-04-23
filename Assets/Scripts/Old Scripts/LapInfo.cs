using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapInfo : MonoBehaviour
{

    int CurrentLap;
    int CurrentSection;
    public int MaxLaps;

    float CurrentLapTime;
    float BestLapTime;

    //   public Text HUD;
    public GameObject Obstacles;

    // Use this for initialization
    void Start()
    {
        CurrentLap = 1;
        CurrentSection = 0;
    }

    void Update()
    {
        //HUD.text = "Lap " + CurrentLap.ToString() + "/" + MaxLaps.ToString();
        if (CurrentLap >= 2)
        {
            Obstacles.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Section0")
        {
            if (CurrentSection == 2)
            {
                CurrentLap++;
                CurrentSection = 0;
            }
        }
        else if (other.tag == "Section1")
        {
            if (CurrentSection == 0)
            {
                CurrentSection++;
            }
        }
        else if (other.tag == "Section2")
        {
            if (CurrentSection == 1)
            {
                CurrentSection++;
            }
        }
    }
}