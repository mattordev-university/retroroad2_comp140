using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSpeedBoostClass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            //Set the speedboost thing to this
        }
    }
}
