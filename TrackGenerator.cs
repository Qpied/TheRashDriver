using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour {

    public GameObject track;
    public Transform generationPoint;
    public float distanceBetween;

    private float TrackUnitLength;
    
    // Use this for initialization
	void Start () {
        TrackUnitLength = track.GetComponent<BoxCollider2D>().size.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + TrackUnitLength + distanceBetween, transform.position.z);
            Instantiate(track, transform.position, transform.rotation); 
        }
	}
}
