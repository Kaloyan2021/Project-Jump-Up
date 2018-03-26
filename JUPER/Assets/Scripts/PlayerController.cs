using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidBody;
    public float jumpTime;
    private float jumpTimeCounter;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;



	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);


        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
            
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0) )
        {
            if (grounded)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);

            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButton(0))
        {

            if (jumpTimeCounter > 0)
            {

                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }

        }

        myAnimator.SetFloat("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
	}
}
