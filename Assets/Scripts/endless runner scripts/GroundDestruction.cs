using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestruction : MonoBehaviour {

    public GameObject groundDestructSpot;

	// Use this for initialization
	void Start () {
        groundDestructSpot = GameObject.Find("ground destruct spot");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < groundDestructSpot.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
