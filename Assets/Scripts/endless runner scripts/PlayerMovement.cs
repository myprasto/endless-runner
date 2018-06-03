using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D playerRb;

    public bool onGround;
    public LayerMask whatGround;

    private Collider2D playerCollid;

    private Animator playerAnim;

	// Use this for initialization
	void Start () {
        playerRb = GetComponent<Rigidbody2D>();

        playerCollid = GetComponent<Collider2D>();

        playerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.IsTouchingLayers(playerCollid, whatGround);

        playerRb.velocity = new Vector2(moveSpeed, playerRb.velocity.y);

        /*for (int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(onGround)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
        }

        /*playerAnim.SetFloat("Speed", playerRb.velocity.x);
        playerAnim.SetBool("OnGround", onGround);*/
	}
}
