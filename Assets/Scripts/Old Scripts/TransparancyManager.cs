using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TransparancyManager : MonoBehaviour {

    public float trans = 0.3f;

    public bool shouldChangeTransparency;

    public bool hasTriggered = false;

    public sideManager sm;

    // Use this for initialization
    void Start () {
        shouldChangeTransparency = false;

        sm = GameObject.FindGameObjectWithTag("Car").GetComponent<sideManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (shouldChangeTransparency == true)
        {
            Debug.Log("in trigger, changing trans");
            if (other.tag == "lane1Piece")
            {
                var col1 = other.GetComponent<Renderer>().material.color;
                col1.a = trans;
                other.GetComponent<Renderer>().material.color = col1;
            }
            if (other.tag == "lane2Piece")
            {
                var col2 = other.GetComponent<Renderer>().material.color;
                col2.a = trans;
                other.GetComponent<Renderer>().material.color = col2;
            }
            if (other.tag == "lane3Piece")
            {
                var col3 = other.GetComponent<Renderer>().material.color;
                col3.a = trans;
                other.GetComponent<Renderer>().material.color = col3;
            }
            if (other.tag == "lane4Piece")
            {
                var col4 = other.GetComponent<Renderer>().material.color;
                col4.a = trans;
                other.GetComponent<Renderer>().material.color = col4;
            }
            hasTriggered = true;
        }

        //if (shouldChangeTrans == false && hasTriggered == true)
        //{
        //    var col = other.GetComponent<Renderer>().material.color;
        //    if (other.tag == "lane1Piece")
        //    {
        //        col.a = 1;
        //        other.GetComponent<Renderer>().material.color = col;
        //    }
        //    if (other.tag == "lane2Piece")
        //    {
        //        col.a = 1;
        //        other.GetComponent<Renderer>().material.color = col;
        //    }
        //    if (other.tag == "lane3Piece")
        //    {
        //        col.a = 1;
        //        other.GetComponent<Renderer>().material.color = col;
        //    }
        //    if (other.tag == "lane4Piece")
        //    {
        //        col.a = 1;
        //        other.GetComponent<Renderer>().material.color = col;
        //    }
        //    hasTriggered = false;
        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "lane1Piece")
        {
            var col1 = other.GetComponent<Renderer>().material.color;
            col1.a = 1;
            other.GetComponent<Renderer>().material.color = col1;
        }
        if (other.tag == "lane2Piece")
        {
            var col2 = other.GetComponent<Renderer>().material.color;
            col2.a = 1;
            other.GetComponent<Renderer>().material.color = col2;
        }
        if (other.tag == "lane3Piece")
        {
            var col3 = other.GetComponent<Renderer>().material.color;
            col3.a = 1;
            other.GetComponent<Renderer>().material.color = col3;
        }
        if (other.tag == "lane4Piece")
        {
            var col4 = other.GetComponent<Renderer>().material.color;
            col4.a = 1;
            other.GetComponent<Renderer>().material.color = col4;
        }
    }
}
