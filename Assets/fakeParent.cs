using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeParent : MonoBehaviour {
    private Vector3 offset;
    public Transform target;
	// Use this for initialization
	void Awake() {
        offset = gameObject.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        gameObject.transform.position = offset + target.transform.position;
	}
}
