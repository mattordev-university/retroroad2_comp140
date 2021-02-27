using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class FlipPickupScript : MonoBehaviour
{

    public GameObject UnderCar;

    public GameObject FlipIcon;

    public bool isTopCar;
    public bool isUnderCar;

    public GameObject Marker;

    //Top car stuff.
    public bool TopCarCanCollide;
    //Top car scripts.
    public SpeedBoostPickup TopSpeedBoost;
    public ShortRangeTPPickup TopShortRangeTP;

    //Under car stuff.
    public bool UnderCarCanCollide;

    //Under car scripts.
    public SpeedBoostPickup UnderSpeedBoost;
    public ShortRangeTPPickup UnderShortRangeTP;

    public GameObject TopCarBody;
    public GameObject TopCarWheels;
    public GameObject TopLights;

    public sideManager sm;
    public LaneFallScript lfs;

    public GameObject ExitDisabler;
    public GameObject ExitDisablerLoc;
    public GameObject ForwardReEnabler;
    public bool hasPickedUp;
    public TransparancyManager Tmanager;

    private float maxTimeInFlip = 30f; //30 Seconds
    private bool timerIsRunning;

    //this manages the visual feedback for this script and any other variables that the countdown needs
    //public TMP_Text CountdownText;
    //private float timeLeft = 30f;
    //private bool canCDRun;

    // Use this for initialization
    void Start()
    {
        Marker = GameObject.FindGameObjectWithTag("UnderMarker");
        TopCarBody = GameObject.FindGameObjectWithTag("TopCarGraphic");
        TopCarWheels = GameObject.FindGameObjectWithTag("TopCarWheels");
        lfs = GameObject.FindGameObjectWithTag("ExitMarker").GetComponent<LaneFallScript>();
        ExitDisabler = GameObject.FindGameObjectWithTag("ExitMarker");
        ForwardReEnabler = GameObject.FindGameObjectWithTag("FMLoc");
        ExitDisablerLoc = GameObject.FindGameObjectWithTag("EDLoc");
        TopLights = GameObject.FindGameObjectWithTag("TopCarLights");
        Tmanager = GameObject.FindGameObjectWithTag("TMan").GetComponent<TransparancyManager>();
        //Car = GameObject.FindGameObjectWithTag("Player");

        timerIsRunning = false;

        if (UnderCarCanCollide == true)
        {
            //UnderCarCanCollide = false;
            TopCarCanCollide = true;
        }
        else
        {
            TopCarCanCollide = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (canCDRun)
        //{
        //    StartCoroutine("LoseTime");
        //    CountdownText.text = ("" + timeLeft);
        //}

        if (isTopCar == true && isUnderCar == false)
        {
            //We need to get the scripts and assign them here.
            TopSpeedBoost = gameObject.GetComponent<SpeedBoostPickup>();
            TopShortRangeTP = gameObject.GetComponent<ShortRangeTPPickup>();
        }
        else
        {
            TopSpeedBoost = null;
            TopShortRangeTP = null;
        }

        if (isUnderCar == true && isTopCar == false)
        {
            UnderSpeedBoost = UnderCar.GetComponent<SpeedBoostPickup>();
            UnderShortRangeTP = UnderCar.GetComponent<ShortRangeTPPickup>();
        }
        else
        {
            UnderSpeedBoost = null;
            UnderShortRangeTP = null;
        }


        if (sm.tb == true && sm.side == "top" && lfs.choice == true)
        {
            ExitDisabler.transform.SetParent(ExitDisablerLoc.transform);
        }

        //Heres the main part of the pickup
        if (Input.GetButtonDown("flipPickup") && hasPickedUp)
        {
            Tmanager.shouldChangeTrans = true;

            hasPickedUp = false;
            timerIsRunning = true;

            //This tells other scripts that top(tb(top/bottom)) = false, i.e the undercar is enabled.
            sm.tb = false;
            sm.side = "bottom";
            lfs.choice = false;

            if (isTopCar)
            {
                TopCarBody.SetActive(false);
                TopLights.SetActive(false);
            }

            if (UnderCarCanCollide == true)
            {
                //Debug.LogError("WORKED");
                Debug.Log("moving undercar");
                UnderCar.transform.position = Marker.transform.position;
                UnderCar.transform.rotation = Marker.transform.rotation;

                UnderCar.transform.SetParent(Marker.transform);

                ExitDisabler.transform.position = ForwardReEnabler.transform.position;
                ExitDisabler.transform.rotation = ForwardReEnabler.transform.rotation;

                ExitDisabler.transform.SetParent(ForwardReEnabler.transform);
            }
            //canCDRun = true;
            
            StartCoroutine(Sequence());

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FlipPickup")
        {
            //Handles the deletion of the model
            Destroy(other.gameObject);

            //enable the underside car, and disable the top one
            TopCarCanCollide = false;
            UnderCarCanCollide = true;

            //This tells the rest of the script that the user can now use the pickup
            hasPickedUp = true;
            FlipIcon.SetActive(true);
            Debug.Log("Icon On");
        }
    }

    IEnumerator Sequence()
    {
        if (timerIsRunning == true)
        {
            yield return new WaitForSeconds(maxTimeInFlip);
            Debug.Log("Returning to normal mode");
            timerIsRunning = false;

            Tmanager.shouldChangeTrans = false;
            UnderCarCanCollide = false;

            //return to top code
            //This tells other scripts that top(tb(top/bottom)) = false, i.e the undercar is enabled.
            sm.tb = true;
            sm.side = "top";
            lfs.choice = true;

            if (isTopCar)
            {
                TopCarBody.SetActive(true);
                TopLights.SetActive(true);
            }

            if (UnderCarCanCollide == false)
            {
                Debug.Log("stopping following.");
                UnderCar.transform.position = UnderCar.transform.position;
                UnderCar.transform.rotation = UnderCar.transform.rotation;

                UnderCar.transform.SetParent(null);

                ExitDisabler.transform.position = ExitDisablerLoc.transform.position;
                ExitDisabler.transform.rotation = ExitDisablerLoc.transform.rotation;

                ExitDisabler.transform.SetParent(gameObject.transform);
            }
            FlipIcon.SetActive(false);
            Debug.Log("Icon Off");
        }
    }
    //IEnumerator LoseTime()
    //{
        
    //    yield return new WaitForSeconds(1);
    //    timeLeft--;
    //    if (timeLeft <= 0)
    //    {
    //        canCDRun = false;
    //    }
    //}
}