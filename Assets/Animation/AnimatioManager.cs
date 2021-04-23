using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimatioManager : MonoBehaviour
{
    public GameObject MiniMap;
    public TMP_Text SkipText;
    public GameObject car;
    public GameObject Cinematic2;
    public GameObject NewCinematic;
    public GameObject Manager;
    public GameObject followCam;

    // Use this for initialization
    void Start()
    {
        MiniMap.SetActive(false);
        StartCoroutine(TheSequence());
        car = GameObject.FindGameObjectWithTag("Car");
        car.SetActive(false);
        Cinematic2.SetActive(false);
        followCam.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MiniMap.SetActive(true);
            car.SetActive(true);
            NewCinematic.SetActive(false);
            Manager.SetActive(false);
            SkipText.enabled = false;
            followCam.SetActive(true);
            Debug.Log("skipping cutscene");
        }   

        if (Input.GetButtonDown("SkipCutScene"))
        {
            MiniMap.SetActive(true);
            NewCinematic.SetActive(false);
            Manager.SetActive(false);
            car.SetActive(true);
            SkipText.enabled = false;
            followCam.SetActive(true);
            Debug.Log("skipping cutscene");
        }
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(4);
        Cinematic2.SetActive(true);
        Debug.Log ("First Cut");
        NewCinematic.SetActive(false);
        yield return new WaitForSeconds(3);
        car.SetActive(true);
        Cinematic2.SetActive(false);
        MiniMap.SetActive(true);
        followCam.SetActive(true);
        SkipText.enabled = false;
        Debug.Log("Second Cut");
    }  
}

