using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;


public class SpeedBoostPickup : MonoBehaviour {

    public TorqueAdjustmentClassFree TController;
    public CarController cCont;
    
    
    private int boostamnt = 500;
    private float speeedBoostDur = 5;
    public bool currentlyBoosting = false;
    private float time;
    public GameObject UIBob;
    public Collider col;
    [SerializeField]
    private Camera mainCam;
    float m_FieldOfView = 85f;

    bool changeFOV = false;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        TController = GameObject.FindGameObjectWithTag("Player").GetComponent<TorqueAdjustmentClassFree>();
        
        if (TController == null)
        {
            cCont = GameObject.FindGameObjectWithTag("Player").GetComponent<CarController>();
        }
    }

    private void Update()
    {
        if (changeFOV)
        {
            m_FieldOfView += 1;
            if (m_FieldOfView >= 75)
            {
                changeFOV = false;
            }
        }

        
        if (Time.timeSinceLevelLoad >= time && currentlyBoosting)
        {
            //Return values to default
            if (TController != null)
            {
                TController.maxVelocityKMh = 1500;
            }
            else if (TController == null)
            {
                cCont.m_Topspeed = 200;
            }
            
            Debug.Log("Returning to default boost amnt");
            currentlyBoosting = false;
            m_FieldOfView = 60f;
            UIBob.SetActive(false);
        }
        mainCam.fieldOfView = m_FieldOfView;

    }

    private void OnTriggerEnter(Collider other)
    {
        col = other;
        if (other.tag == "speedBoost" && !currentlyBoosting)
        {
            currentlyBoosting = true;
            Debug.Log("Have some boost");
            if (TController != null)
            {
                TController.maxVelocityKMh += boostamnt;
                Debug.Log("Max moter torque is now " + TController.maxVelocityKMh);
            }
            else if(TController == null)
            {
                cCont.m_Topspeed += boostamnt;
                Debug.Log("Max moter torque is now " + cCont.m_Topspeed);
            }
            
            
            time = Time.timeSinceLevelLoad;
            time += speeedBoostDur;
            changeFOV = true;
            Destroy(other.gameObject);
            UIBob.SetActive(true);
        }
    }
}
