using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLaneFallScript : MonoBehaviour {

    //Tile falling checks and vars
    public GameObject currentTile;
    private Vector3 tileMoveVector;
    private float tileVerticalVelocity = 0f;
    public bool shouldFall = false;
    private float gravity = 12f;


    private void Update()
    {
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


    private void OnTriggerExit(Collider other)
    {
        currentTile = other.transform.gameObject;

        if (other.tag == "lane1Piece")
        {
            //currentTile = other.gameObject; //Set the current tile.
            Debug.Log("On lane 1");
            TileFall(); //Make the current tile fall.

            if (shouldFall == true)
                //We then delete that tile
                Destroy(currentTile);

            //Then we set should fall to false
            shouldFall = false;
        }

        if (other.tag == "lane2Piece")
        {
            //currentTile = other.gameObject; //Set the current tile.
            Debug.Log("On lane 2");
            TileFall(); //Make the current tile fall.

            if (shouldFall == true)
                //We then delete that tile
                Destroy(currentTile);

            //Then we set should fall to false
            shouldFall = false;
        }

        if (other.tag == "lane3Piece")
        {
            //currentTile = other.gameObject; //Set the current tile.
            Debug.Log("On lane 3");
            TileFall(); //Make the current tile fall.

            if (shouldFall == true)
                //We then delete that tile
                Destroy(currentTile);

            //Then we set should fall to false
            shouldFall = false;
        }

        if (other.tag == "lane4Piece")
        {
            //currentTile = other.gameObject; //Set the current tile.
            Debug.Log("On lane 4");
            TileFall(); //Make the current tile fall.

            if (shouldFall == true)
                //We then delete that tile
                Destroy(currentTile);

            //Then we set should fall to false
            shouldFall = false;
        }
    }

    private void TileFall()
    {
        //        StartCoroutine(coroutine);
        shouldFall = true;
    }


}
