using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class CarWait : MonoBehaviour
{
    public GameObject Car;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.OnBoardConnectedEvent.AddListener(StartCar);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCar(UduinoDevice device) 
    {
        Car.SetActive(true);
    }
}
