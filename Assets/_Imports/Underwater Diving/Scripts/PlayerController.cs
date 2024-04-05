using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public GameObject bubbles;
    private Vector2 playerMovementInput;
	SpriteRenderer playerSpriteRenderer;
	float horizontalInput;
	float verticalInput;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
		playerSpriteRenderer = GetComponent<SpriteRenderer>();

		horizontalInput = 0;
		verticalInput = 0;
    }

    void Update()
    {
        HandleMovement();
        HandleSpriteDirection();
    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerMovementInput = new Vector2(horizontalInput, verticalInput);
        
		myRigidBody.AddForce(playerMovementInput * moveSpeed * Time.deltaTime);
        
		myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
    }

	private void HandleSpriteDirection(){
		if (horizontalInput > 0f)
        {
			playerSpriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
			playerSpriteRenderer.flipX = true;
        }
	}

    public void hurt()
    {
        gameObject.GetComponent<Animator>().Play("PlayerHurt");
    }
}
