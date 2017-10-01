using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform playerCar;
    float offset;
    
    // Use this for initialization
	void Start () {
        GameObject playa = GameObject.FindGameObjectWithTag("Player");

        playerCar = playa.transform;
        offset = transform.position.y - playerCar.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCar != null)
        {
            Vector3 pos = transform.position;
            pos.y = playerCar.position.y + offset;
            transform.position = pos;
        }
	}
}
