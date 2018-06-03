using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public PlayerMovement player;

    private Vector3 currPlayerPos;

    private float moveDistance;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
        currPlayerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveDistance = player.transform.position.x - currPlayerPos.x;

        transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);

        currPlayerPos = player.transform.position;
	}
}
