using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using System;
//[Serializable]
//public class carElement
//{
//    public float speed;
//    public bool isLethal;
//    public GameObject carObj;
//    public int[] example4;
//}
public class CarPicker : MonoBehaviour
{
    //public carElement[] cars;
    public Canvas SelectScreen;

    public Image[] appearences;

    public GameObject[] carModels;

    public int onCar;
    private bool shown1;
    private bool shown2;
    public Camera previewCam;
    public Transform previewView;
    public Transform cameraOriginalLoc;
    public bool hasPreviewed;

    public bool caseSwitch = false;

    // Use this for initialization
    void Start()
    {
        previewView = GameObject.FindGameObjectWithTag("previewLoc").GetComponent<Transform>();
        previewCam = GameObject.FindGameObjectWithTag("previewCam").GetComponent<Camera>();
        cameraOriginalLoc = GameObject.FindGameObjectWithTag("cameraOriginalLoc").GetComponent<Transform>();

        hasPreviewed = false;

#if UNITY_EDITOR
        if (appearences.Length == 0)
        {
            Debug.LogError("ADD THE IMAGE APPEARENCES IN THE INSPECTOR!");
        }
        if (carModels.Length == 0)
        {
            Debug.LogError("ADD THE CAR MODELS IN THE INSPECTOR!");
        }
#endif
        //here we make sure that the images of the cars are disabled, and firstly that the canvas is edisabled
        //SelectScreen.enabled = false;

        foreach (Image obj in appearences)
        {
            obj.enabled = false;
        }

        onCar = 0;

        foreach (GameObject cars in carModels)
        {
            cars.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PreviewCar();
    }



    public void picker()
    {
        //first enable the select screen
        //SelectScreen.enabled = true;

        if (EventSystem.current.currentSelectedGameObject.name == "countachButton")
        {
            if (shown1 = !shown1)
            {
                shown1 = !shown1;
                appearences[0].enabled = !appearences[0].enabled;
                onCar = 1;

                PlayerPrefs.SetInt("CarValue", onCar);
                PlayerPrefs.Save();

#if UNITY_EDITOR
                Debug.Log("Toggling the Countach");
                Debug.Log("Car is on " + PlayerPrefs.GetInt("CarValue"));
#endif
            }

            if (appearences[1].enabled == true)
            {
                appearences[1].enabled = false;
            }
        }

        if (EventSystem.current.currentSelectedGameObject.name == "robinButton")
        {
            if (shown2 = !shown2)
            {
                shown2 = !shown2;
                appearences[1].enabled = !appearences[1].enabled;
                onCar = 2;

                PlayerPrefs.SetInt("CarValue", onCar);
                PlayerPrefs.Save();

#if UNITY_EDITOR
                Debug.Log("Toggling the Robin");
                Debug.Log("Car is on " + PlayerPrefs.GetInt("CarValue"));
#endif
            }

            if (appearences[0].enabled == true)
            {
                appearences[0].enabled = false;
            }
        }
    }

    void PreviewCar()
    {
        if (Input.GetButtonDown("previewCar"))
        {
            caseSwitch = !caseSwitch;
            if (caseSwitch == true)
            {
                hasPreviewed = true;
                if (onCar == 1)
                {
                    carModels[0].SetActive(true);
                    SelectScreen.enabled = false;
                    previewCam.transform.position = previewView.transform.position;
                    previewCam.transform.rotation = previewView.transform.rotation;
                }

                if (onCar == 2)
                {
                    carModels[1].SetActive(true);
                    SelectScreen.enabled = false;
                    previewCam.transform.position = previewView.transform.position;
                    previewCam.transform.rotation = previewView.transform.rotation;
                }
            }

            if (caseSwitch == false)
            {
                if (Input.GetButtonDown("previewCar"))
                {
                    SelectScreen.enabled = true;
                    previewCam.transform.position = cameraOriginalLoc.transform.position;
                    previewCam.transform.rotation = cameraOriginalLoc.transform.rotation;

                    foreach (GameObject obj in carModels)
                    {
                        obj.SetActive(false);
                    }
                }
            }
        }
    }
}