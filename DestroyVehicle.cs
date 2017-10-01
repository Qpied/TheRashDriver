using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVehicle : MonoBehaviour {

    public GameObject destructionPoint;
    // Use this for initialization
    void Start () {
        destructionPoint = GameObject.Find("DestructionPoint");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
