﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingShortRangeTPPickup : MonoBehaviour {

    public GameObject carPos;
    public GameObject ForwardMarker;

    //Checking Vars
    private bool hasPickedUp;
    public Collider col;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("ShortTP") && hasPickedUp)
        {
            carPos.transform.position = ForwardMarker.transform.position;
            hasPickedUp = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        col = other;
        if (other.tag == "ShortRangeTP")
        {
            Destroy(other.gameObject);
            hasPickedUp = true;
        }
    }
}
