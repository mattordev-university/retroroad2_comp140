using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGetter : MonoBehaviour {

    public GameObject[] carModels;
    int carValue;
    public GameObject[] PlayerObjs;

    // Use this for initialization
    void Start () {
        //Disable all models at the start
        foreach (GameObject obj in PlayerObjs)
        {
            obj.SetActive(false);
        }


#if UNITY_EDITOR
        if (carModels.Length == 0)
        {
            Debug.LogError("ADD THE CAR MODELS IN THE INSPECTOR!");
        }
#endif
    }

    // Update is called once per frame
    void Update () {
        carValue = PlayerPrefs.GetInt("CarValue");
        Debug.Log(carValue);

        if (carValue == 1)
        {
            PlayerObjs[0].SetActive(true);
            PlayerObjs[1].SetActive(false);
        }

        if (carValue == 2)
        {
            PlayerObjs[1].SetActive(true);
            PlayerObjs[0].SetActive(false);
        }
    }
}
