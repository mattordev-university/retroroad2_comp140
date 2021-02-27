using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour {

    public GameObject CinematicCar;

	// Use this for initialization
	void Start () {
        Instantiate(CinematicCar);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
