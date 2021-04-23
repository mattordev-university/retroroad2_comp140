using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menucont : MonoBehaviour {

    public GameObject[] Menus;

   

    private void Awake()
    {
        foreach(GameObject menu in Menus)
        {
            menu.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
