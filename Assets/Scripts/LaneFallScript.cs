 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneFallScript : MonoBehaviour
{

    //Tile falling checks and vars
    public GameObject currentTile;
    private Vector3 tileMoveVector;
    private float tileVerticalVelocity = 0f;
    public bool shouldFall = false;
    private float gravity = 12f;

    public sideManager sm;


    //if this equals true, it means the tiles will be DISABLED.
    //if this equals false, it means the tiles will be ENABLED.
    public bool choice = true;

    public void Start()
    {
        //sm = GetComponent<sideManager>();

    }

    public void Update()
    {
        //if (sm = null)
            //sm = GetComponent<sideManager>();

        //Any tile stuff regaurding physics will be done here
        if (shouldFall == false)
        {
            tileVerticalVelocity = 0f;
        }
        else
        {
            tileVerticalVelocity -= gravity * 10;
        }

        tileMoveVector.x = 0f;
        tileMoveVector.y = tileVerticalVelocity;
        tileMoveVector.z = 0f;
    }


    public void OnTriggerExit(Collider other)
    {
        if (choice == true)
        {
            if (sm.tb == true)
            {
                currentTile = other.transform.gameObject;

                var disCount = 0;

                if (other.tag == "lane1Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = false;
                            disCount += 1;
                            Debug.Log("Disabled the collider of " + disCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = false;
                        }
                    }
                    Debug.Log("On lane 1");
                    //currentTile.gameObject.SetActive(false);
                }

                if (other.tag == "lane2Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = false;
                            disCount += 1;
                            Debug.Log("Disabled the collider of " + disCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = false;
                        }
                    }
                    Debug.Log("On lane 2");
                    //currentTile.gameObject.SetActive(false);
                }

                if (other.tag == "lane3Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = false;
                            disCount += 1;
                            Debug.Log("Disabled the collider of " + disCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = false;
                        }
                    }
                    Debug.Log("On lane 3");
                    //currentTile.gameObject.SetActive(false);
                }

                if (other.tag == "lane4Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = false;
                            disCount += 1;
                            Debug.Log("Disabled the collider of " + disCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = false;
                        }
                    }
                    Debug.Log("On lane 4");
                    //currentTile.gameObject.SetActive(false);
                }
            }
        }      
    }



    //This part handles the reactivation of the tiles.
    private void OnTriggerEnter(Collider other)
    {
        if (choice == false)
        {
            if (sm.tb == false)
            {
                currentTile = other.transform.gameObject;

                var enaCount = 0;

                if (other.tag == "lane1Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = true;
                            enaCount += 1;
                            Debug.Log("Disabled the collider of " + enaCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = true;
                        }
                    }
                    Debug.Log("On lane 1");
                    //currentTile.gameObject.SetActive(false);
                }

                if (other.tag == "lane2Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = true;
                            enaCount += 1;
                            Debug.Log("Disabled the collider of " + enaCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = true;
                        }
                    }
                    Debug.Log("On lane 2");
                    //currentTile.gameObject.SetActive(false);
                }

                if (other.tag == "lane3Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = true;
                            enaCount += 1;
                            Debug.Log("Disabled the collider of " + enaCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = true;
                        }
                    }
                    Debug.Log("On lane 3");
                    //currentTile.gameObject.SetActive(false);
                }

                if (other.tag == "lane4Piece")
                {
                    foreach (var i in other.GetComponentsInChildren<Collider>())
                    {
                        if (!i.isTrigger)
                        {
                            i.enabled = true;
                            enaCount += 1;
                            Debug.Log("Disabled the collider of " + enaCount + " pieces.");
                            i.GetComponent<Renderer>().enabled = true;
                        }
                    }
                    Debug.Log("On lane 4");
                    //currentTile.gameObject.SetActive(false);
                }
            }
        }     
    }
}
