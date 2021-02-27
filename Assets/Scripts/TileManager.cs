﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public Transform playerTransform;

    private float spawnZ = -12.0f; //Where the tile will spawn.
    private float tileLength = 9f; //The length of the tile.
    private float safeZone = 15f; 
    private int amnTilesOnScreen = 12; //The max amount of tiles that can be seen on the screen

    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }
	
	
	void Update () {
		if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)       
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject; //Spawn the tile/prefab      
        else        
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
              
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
