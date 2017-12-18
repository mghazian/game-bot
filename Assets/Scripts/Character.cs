﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterContainer {

	private Rigidbody2D playerRigidBody2D;
	private Animator anim;
	private SpriteRenderer spriteRenderer;

	public bool isMovable = false;
	public bool isAttackable = false;
	private bool isJump = false;
	private bool isRanged = true;
	private bool isMoving = false;

	private float movementSpeed = 3.0f;
	private float jumpStrength = 8.0f;

	private RangedWeapon rangedWeapon;

	void Start()
	{
		playerRigidBody2D = this.gameObject.GetComponent<Rigidbody2D> ();
		anim = this.gameObject.GetComponent<Animator> ();
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		rangedWeapon = gameObject.AddComponent<RangedWeapon> ();
	}

	void Update()
	{
		if (isMovable)
		{
			HandleMovement();
			HandleAttack();
		}
	}

	private void HandleMovement ()
	{
		
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

		if ((Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) && !isJump) 
		{
			Stop ();
		}
	}

	private void HandleAttack ()
	{
		if ( !isJump && !isMoving )
		{
			if (Input.GetKey (KeyCode.W))
			{
				Debug.Log (rangedWeapon.angle);
				if (rangedWeapon.angle < 90)
					rangedWeapon.angle += 0.4f;
			}
			else if (Input.GetKey (KeyCode.S))
			{
				Debug.Log (rangedWeapon.angle);
				if (rangedWeapon.angle >= 0)
					rangedWeapon.angle -= 0.4f;
			}
			else if (Input.GetKey (KeyCode.Space))
			{
				Debug.Log (rangedWeapon.power);
				if (rangedWeapon.power <= 50)
					rangedWeapon.power += 0.4f;
				else
				{
					isMovable = false;
					rangedWeapon.Fire();
				}
			}

			else if (Input.GetKeyUp (KeyCode.Space))
			{
				isMovable = false;
				rangedWeapon.Fire();
			}
		}
	}

	private void Move(string direction)
	{
		if (!isMoving) 
		{
			anim.SetTrigger ("Move");
		}

		isMoving = true;

		if (direction == "Left") 
		{
			spriteRenderer.flipX = true;
			playerRigidBody2D.velocity = new Vector3 (-movementSpeed , playerRigidBody2D.velocity.y, 0.0f);
		} 

		else 
		{
			spriteRenderer.flipX = false;
			playerRigidBody2D.velocity = new Vector3 (movementSpeed, playerRigidBody2D.velocity.y, 0.0f);

		}
	}

	private void Stop(){
		isMoving = false;
		anim.SetTrigger ("Stop");
	}

	private void Jump()
	{
		anim.SetTrigger ("Jump");
		isJump = true;
		playerRigidBody2D.velocity = new Vector3 (playerRigidBody2D.velocity.x, jumpStrength, 0.0f);
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
