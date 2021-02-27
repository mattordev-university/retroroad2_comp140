using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSpeedBoostPickup : MonoBehaviour {

    public TestingCarController Controller;
    
    private float boostamnt = 500f;
    private float speeedBoostDur = 5;
    public bool currentlyBoosting = false;
    private float time;

    public Collider col;
    [SerializeField]
    private Camera mainCam;
    float m_FieldOfView = 60f;

    private void Start()
    {
        mainCam = GetComponentInChildren<Camera>();
        Controller = gameObject.GetComponent<TestingCarController>();
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad >= time && currentlyBoosting)
        {
            Controller.maxMotorTorque = 1500;
            Debug.Log("Returning to default boost amnt");
            currentlyBoosting = false;
            m_FieldOfView = 60f;
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
            Controller.maxMotorTorque += boostamnt;
            Debug.Log("Max moter torque is now " + Controller.maxMotorTorque);
            time = Time.timeSinceLevelLoad;
            time += speeedBoostDur;
            m_FieldOfView += 15f;
            Destroy(other.gameObject);
        }
    }
}
