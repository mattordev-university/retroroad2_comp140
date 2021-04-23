using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using System;

public class CarContUduino : MonoBehaviour
{
#region UDUINO_VARS
    [Header("Uduino Variables")]
    // not sure if this is needed, but will keep for now
    //UduinoManager uduino;   

    // analog pins
    //int steeringPot = 0;
    //int throttlePot = 2;
    //int brakePot = 3;

    // other pins
    int buttonAPin = 2;
    int buttonBPin = 3;
    int buttonCPin = 4;
    int buttonDPin = 5;

    int buttonValue = 0;
    int prevButtonValue = 0;
    bool buttonState;

    public int steeringPotValue;
    public int throttlePotValue;
    public int brakePotValue;

    // ref: https://forum.unity.com/threads/mapping-or-scaling-values-to-a-new-range.180090/
    public float steeringPotMapped;
    public float throttlePotMapped;
    public float brakePotMapped;

    #endregion

#region CAR_VARS
 
    [Header("Car Variables")]

    // Calibration min - the lowest value we expect to see from the sensor
    [Range(0,1023)]
    public float throttleCalMin = 0f;

    // Calibration max - the highest value we expect to see from the sensor
    [Range(0,1023)]
    public float throttleCalMax = 1023f;

    // Calibration min - the lowest value we expect to see from the sensor
    [Range(0, 1023)]
    public float steeringCalMin = 0f;

    // Calibration max - the highest value we expect to see from the sensor
    [Range(0, 1023)]
    public float steeringCalMax = 1023f;

    // Calibration min - the lowest value we expect to see from the sensor
    [Range(0, 1023)]
    public float brakeCalMin = 0f;

    // Calibration max - the highest value we expect to see from the sensor
    [Range(0, 1023)]
    public float brakeCalMax = 1023f;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    [SerializeField] private bool isBreaking;
    [SerializeField] private float breakForce;
    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    private float smoothAmount = 10f;
    Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject COM;
    [SerializeField] private bool useCOM;

#endregion

#region ABILITY_VARIABLES

    // Global ablity vars
    public GameObject forwardMarker; // Forward point

    [Header("Teleport variables")]
    // Teleport vars
    public GameObject carPos; // Pos of car
    public GameObject teleportUI; // Model of the pickup

    private bool hasPickedUpTP;

    [Header("Speedboost variables")]
    // Speedboost vars
    private int boostAmount = 500;
    private float speedBoostDuration = 5f;
    private bool currentlyBoosting = false;
    private float time;
    public GameObject speedboostUI;
    [SerializeField] private Camera mainCam;
    private float fieldOfView;
    private float defaultFieldOfView = 60f;
    private float maxFieldOfView = 75f;
    private bool changeFOV;

    [Header("Flip variables")]
    //Flip vars
    public bool hasPickedUpFlip;
    public bool isTopCar;
    public bool isFlippedCar;
    public bool TopCarCanCollide;
    public bool flipTimerIsRunning;

    public GameObject flippedCar;
    public GameObject flipPickupUI;
    public GameObject topCarObj;
    public GameObject exitDisabler;
    public GameObject exitDisablerOriginalLocation;
    public GameObject forwardReEnabler;
    public GameObject underMarker;

    private float maxTimeInFlip = 30f;

    // checks
    bool checkAb1;
    bool checkAb2;
    bool checkAb3;
    bool checkAb4;

    //scripts
    public sideManager sideMan;
    public LaneFallScript laneFallScript;
    public TransparancyManager transparancyManager;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GetAbilityAssignables();

        // Button pinMode setups
        UduinoManager.Instance.pinMode(buttonAPin, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(buttonBPin, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(buttonCPin, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(buttonDPin, PinMode.Input_pullup);

        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input); // Steering
        UduinoManager.Instance.pinMode(AnalogPin.A1, PinMode.Input); // Throttle
        UduinoManager.Instance.pinMode(AnalogPin.A2, PinMode.Input); // Brake

        flipTimerIsRunning = false;

        if (useCOM)
        { 
            rb.centerOfMass = COM.transform.position;                                                                                                                                                 
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;

        // INPUT
        GetKeyboardInput();
        GetInput();

        ReadPots();

        CheckAbility(buttonAPin);
        CheckAbility(buttonBPin);
        CheckAbility(buttonCPin);
        CheckAbility(buttonDPin);

        if (changeFOV)
        {
            fieldOfView += 1;
            if (fieldOfView >= maxFieldOfView)
            {
                changeFOV = false;
            }
        }

        if (sideMan.side == "top" && laneFallScript.choice == true)
        {
            exitDisabler.transform.SetParent(exitDisablerOriginalLocation.transform);
        }
    }

#region MISC_FUNCTIONS

    void CheckAbility(int abilityNo)  
    {
        // Check the state of the button
        if (CheckPinValue(abilityNo)) 
        {
            TriggerAbility(abilityNo);
        }
    }

    bool CheckPinValue(int pinNo) 
    {
        buttonValue = UduinoManager.Instance.digitalRead(pinNo);

        // In this case, we compare the current button value to the previous button value, 
        // to trigger the change only once the value change.
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0)
            {
                buttonState = true;
            }
            else if (buttonValue == 1)
            {
                buttonState = false;
            }
        }
        prevButtonValue = buttonValue; // Here we assign prev button value to the new value
        

        //Debug.Log(UduinoManager.Instance.digitalRead(pinNo) == 0);
        return buttonState;
    }

    void TriggerAbility(int abilityNo) 
    {
        Debug.Log($"Ability triggered: {abilityNo}");

        if (abilityNo == buttonAPin && checkAb1) {
            ShortTeleport();
        } else if (abilityNo == buttonBPin && checkAb2) {
            SpeedBoost();
        } else if (abilityNo == buttonCPin && checkAb3) {
            Flip();
        } else if (abilityNo == buttonDPin) {
            TilePlacer();
        } else {
            Debug.Log("Ability doesn't exist");
        }
    }

    void ReadPots()
    {

        
        steeringPotMapped = MapIntToFloat(steeringPotValue, steeringCalMin, steeringCalMax, -1f, 1f);
        throttlePotMapped = MapIntToFloat(throttlePotValue, throttleCalMin, throttleCalMax, -1f, 1f);
        //throttlePot8Bit = PotTo8Bit(throttlePotValue);
        brakePotMapped = MapIntToFloat(brakePotValue, brakeCalMin, brakeCalMax, 0.25f, 10f * speed * 1.1f);

        if(speed <= 0) 
        {
        
        }

        // implement brake deadzone. When speed is below a certain value, and brake is high enough * it by 1000.

        steeringPotValue = UduinoManager.Instance.analogRead(AnalogPin.A0);
        throttlePotValue = UduinoManager.Instance.analogRead(AnalogPin.A1);
        brakePotValue = UduinoManager.Instance.analogRead(AnalogPin.A2);
    }

    // Unused, will remove soon
    int PotTo8Bit(int potValue)
    {
        potValue = (int)Mathf.Lerp(0, 1023, Mathf.InverseLerp(0, 255, steeringPotValue));
        return potValue;
    }

    // A handy function to map an int from a source range to a target range, both expressed in floats
    // It's kinda like the Arduino's map() function
    float MapIntToFloat(int inputValue, float fromMin, float fromMax, float toMin, float toMax)
    {     
        float i = ((((float)inputValue - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin );
        i = Mathf.Clamp(i,toMin,toMax);
        return i;
    }

#endregion

#region ABILITYS

    private void ShortTeleport()
    {
        if (hasPickedUpTP)
        {
            // Moving car to tp pos
            carPos.transform.position = forwardMarker.transform.position;
            // Allows other TP pickups to be picked up
            hasPickedUpTP = false;
            // disable model
            teleportUI.SetActive(false);
            checkAb1 = false;
        }
    }

    private void SpeedBoost()
    {
        motorForce += boostAmount;
#if UNITY_EDITOR
            Debug.Log($"currently boosting, motor force is: {motorForce}");
#endif

        time = Time.timeSinceLevelLoad;
        time += speedBoostDuration;
        changeFOV = true;
        StartCoroutine(SpeedboostWait(speedBoostDuration));

        checkAb2 = false;
    }

    private void Flip()
    {
        transparancyManager.shouldChangeTransparency = true;

        hasPickedUpFlip = true;
        flipTimerIsRunning = false;

        sideMan.side = "bottom";
        laneFallScript.choice = false;

        if (isTopCar)
            topCarObj.SetActive(false);
        

        if(isFlippedCar)
        {
#if UNITY_EDITOR
            Debug.Log("Swapping to the flipped car");
#endif
            flippedCar.transform.position = underMarker.transform.position;
            flippedCar.transform.rotation = underMarker.transform.rotation;

            underMarker.transform.SetParent(underMarker.transform);

            exitDisabler.transform.position = forwardReEnabler.transform.position;
            exitDisabler.transform.rotation = forwardReEnabler.transform.rotation;

            exitDisabler.transform.SetParent(forwardReEnabler.transform);
        }

        StartCoroutine(FlipSequence(maxTimeInFlip));

        checkAb3 = false;
    }

    private void TilePlacer()
    {
        // Allows the player to place one extra tile
        throw new NotImplementedException();
    }

    // Handles all trigger stuff
    private void OnTriggerEnter (Collider other)
    {
#region Teleport
        if (other.tag == "ShortRangeTP")
        {
            Destroy(other.gameObject);
            hasPickedUpTP = true;
            teleportUI.SetActive(true);
            checkAb1 = true;
        }
#endregion

#region Speedboost
        if (other.tag == "speedBoost" && !currentlyBoosting)
        {
            currentlyBoosting = true;
            
            Destroy(other.gameObject);
            speedboostUI.SetActive(true);
            checkAb2 = true;
        }
#endregion

#region Flip
        if(other.tag == "FlipPickup")
        {
            Destroy(other.gameObject);

            isTopCar = false;
            isFlippedCar = true;
            hasPickedUpFlip = true;
            flipPickupUI.SetActive(true);
            checkAb3 = true;
        }
#endregion
    }

    IEnumerator SpeedboostWait(float time) 
    {
        yield return new WaitForSeconds(time);
        if (Time.timeSinceLevelLoad >= time && currentlyBoosting)
        {
            currentlyBoosting = false;
            fieldOfView = defaultFieldOfView;
            speedboostUI.SetActive(false);
        }
        mainCam.fieldOfView = fieldOfView;

    }

    IEnumerator FlipSequence(float time)
    {
        if(flipTimerIsRunning)
        {
            yield return new WaitForSeconds(time);
#if UNITY_EDITOR
            Debug.Log("Swapping to top car.");
#endif
            flipTimerIsRunning = false;
            transparancyManager.shouldChangeTransparency = false;
            isFlippedCar = false;

            sideMan.side = "top";
            laneFallScript.choice = true;

            if(isTopCar)
                topCarObj.SetActive(true);
            
            if (isFlippedCar)
            {
#if UNITY_EDITOR
                Debug.Log("stopping the top car from following");
#endif
                flippedCar.transform.position = flippedCar.transform.position;
                flippedCar.transform.rotation = flippedCar.transform.rotation;
                flippedCar.transform.SetParent(null);

                exitDisabler.transform.position = exitDisablerOriginalLocation.transform.position;
                exitDisabler.transform.rotation = exitDisablerOriginalLocation.transform.rotation;
                exitDisabler.transform.SetParent(gameObject.transform);
            }
            flipPickupUI.SetActive(false);
        }
    }

    public void GetAbilityAssignables()
    {
        forwardMarker = GameObject.FindGameObjectWithTag("ForwardMarker");
        underMarker = GameObject.FindGameObjectWithTag("UnderMarker");
        topCarObj = GameObject.FindGameObjectWithTag("TopCarGraphic");
        laneFallScript = GameObject.FindGameObjectWithTag("ExitMarker").GetComponent<LaneFallScript>();
        exitDisabler = GameObject.FindGameObjectWithTag("ExitMarker");
        forwardReEnabler = GameObject.FindGameObjectWithTag("FMLoc");
        transparancyManager = GameObject.FindGameObjectWithTag("TMan").GetComponent<TransparancyManager>();
        flippedCar = GameObject.FindGameObjectWithTag("UnderCar");
        sideMan = GameObject.FindGameObjectWithTag("Car").GetComponent<sideManager>();
        rb = GetComponent<Rigidbody>();
        carPos = gameObject;
        mainCam = Camera.main;
    }

    #endregion

#region CAR_FUNCTIONS

    private void FixedUpdate()
    {
        // Input functions have been moved to the Update function
        HandleMoter();
        HandleSteering();
        UpdateWheels();
    }

    
    private void GetKeyboardInput() 
   {
        // Keyboard inputs
        // Forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalInput = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            verticalInput = 0f;
        }

        // Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            horizontalInput = 0f;
        }

        // Back
        if (Input.GetKeyDown(KeyCode.S))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            verticalInput = 0f;
        }

        //Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalInput = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            horizontalInput = 0f;
        }

        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void GetInput()
    {
        
        if (UduinoManager.Instance.isConnected())
        {
            /* Call the MapIntToFloat function for each input to change the value of the analog pot pin (0 to 1023) to the 
            value range expected by the steering (-1 to 1) also taking into account the calibration properties*/

            horizontalInput = steeringPotMapped;

            verticalInput = throttlePotMapped;

            if (brakePotMapped > 0)
            {
                currentBreakForce = brakePotMapped;
                isBreaking = true;
            }else
            {
                currentBreakForce = 0;
                isBreaking = false;
            }
        }
    }

    private void HandleMoter()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? brakePotMapped : 0.25f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontLeftWheelCollider.wheelDampingRate = currentBreakForce;
        frontRightWheelCollider.wheelDampingRate = currentBreakForce;
        backLeftWheelCollider.wheelDampingRate = currentBreakForce;
        backRightWheelCollider.wheelDampingRate = currentBreakForce;
        Debug.Log(frontLeftWheelCollider.wheelDampingRate);
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        
        wheelCollider.GetWorldPose(out pos, out rot);
        Quaternion currentPos = rot * Quaternion.Euler(new Vector3(0, 90, 0));
        wheelTransform.rotation = Quaternion.Lerp(wheelTransform.rotation, currentPos, smoothAmount * Time.deltaTime);
        wheelTransform.position = pos;
    }

#endregion

}