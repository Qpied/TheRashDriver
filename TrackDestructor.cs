using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDestructor : MonoBehaviour {

    public GameObject destructionPoint;
   

    // Use this for initialization
    void Start () {
        destructionPoint = GameObject.Find("DestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < destructionPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
	}
}
