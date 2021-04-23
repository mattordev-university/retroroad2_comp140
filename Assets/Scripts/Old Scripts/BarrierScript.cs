using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour {

    private BoxCollider col;
    public sideManager sm;


	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider>();
        //sm = GameObject.FindGameObjectWithTag("Player").GetComponent<sideManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if(sm == null && sm.side != "bottom")
        {
            sm = GameObject.FindGameObjectWithTag("Player").GetComponent<sideManager>();
        }
        
		else if (sm.side == "bottom")
        {
            col.enabled = false;
        }
       
	}
}
