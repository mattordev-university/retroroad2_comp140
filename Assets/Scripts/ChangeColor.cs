using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lane1Piece")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "lane2Piece")
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
}