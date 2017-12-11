using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterContainer {

	private uint id { get; }
	private uint health { get; set; }

	private uint scalarSpeed { get; set; }
	private uint jumpHeight { get; set; }

	private Rigidbody2D playerRigidBody2D;

	private bool isJump = false;
	private bool isRanged = true;
	public bool isMovable = false;
	// More personalization e.g. skins etc.
	// ...

	// Weapons
	// ...
	void Start()
	{
		playerRigidBody2D = this.gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (isMovable)
		{
			HandleMovement();
		}
	}

	public Character (uint id, uint scalarSpeed, uint jumpHeight)
	{
		this.id = id;
		this.scalarSpeed = scalarSpeed;
		this.jumpHeight = jumpHeight;
	}

	private void HandleMovement ()
	{
		//control movement
		if(Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
		{
			Jump ();
		}

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			Move("Left");
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			Move("Right");
		}	
	}

	// State

	private void Move(string direction)
	{
		if (direction == "Left") 
		{
			playerRigidBody2D.velocity = new Vector3 (-3.0f , playerRigidBody2D.velocity.y, 0.0f);
		} 

		else 
		{
			playerRigidBody2D.velocity = new Vector3 (3.0f, playerRigidBody2D.velocity.y, 0.0f);

		}
	}

	private void Jump()
	{
		isJump = true;
		playerRigidBody2D.velocity = new Vector3 (playerRigidBody2D.velocity.x, 8f,0.0f);
	}

	private void Attack()
	{

	}

	private void ChangeWeapon()
	{

	}

	void OnCollisionStay2D (Collision2D anotherObject)
	{
		if (anotherObject.collider.tag == "Ground") {
			isJump = false;
		}
	}
}
