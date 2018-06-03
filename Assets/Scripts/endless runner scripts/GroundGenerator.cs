using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

    public GameObject Ground;
    public Transform generationPoint;
    public float distanceBetween;

    public float distanceBetweenMax;
    public float distanceBetweenMin;

    private float groundWidth;

	// Use this for initialization
	void Start () {
        groundWidth = Ground.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + groundWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(Ground, transform.position, transform.rotation);
        }
	}
}
