﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : CharacterContainer {

	private Rigidbody2D playerRigidBody2D;
	private Animator anim;
	private SpriteRenderer spriteRenderer;

	public bool isMovable = false;
	public bool isAttackable = false;
	public bool isAlive = true;

	private bool isJump = false;
	private bool isRanged = true;
	private bool isMoving = false;

	public int health = 100;

	private int attackMeeleDamage = 5;
	private int attackRangedDamage = 10;

	private float movementSpeed = 3.0f;
	private float jumpStrength = 8.0f;


	void Start()
	{
		playerRigidBody2D = this.gameObject.GetComponent<Rigidbody2D> ();
		anim = this.gameObject.GetComponent<Animator> ();
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		if (isAlive) {
		
			if (health <= 0) {
				isAlive = false;
			}

			if (isMovable) {
				HandleMovement ();
			}	
				
			if (isAttackable) {
				HandleAttack ();
			}
		} 
		else 
		{
			//Respawn
		}
	}

	private void HandleMovement ()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			Move("Left");
		}

		if(Input.GetKey(KeyCode.RightArrow))
		{
			Move("Right");
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && !isJump)
		{
			Jump ();
		}
			
		if ((Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow))) 
		{
			Stop ();
		}
	}

	private void HandleAttack()
	{
		if (isRanged) {
		
		} 

		else 
		{
			
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

	private void Stop()
	{
		isMoving = false;
		anim.SetTrigger ("Stop");
	}

	private void Jump()
	{
		isJump = true;
		anim.ResetTrigger ("Stop");
		anim.SetTrigger ("Jump");
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
		if (anotherObject.collider.tag == "Ground") 
		{
			anim.ResetTrigger ("Stop");
			isJump = false;
		}

		if (anotherObject.collider.tag == "Bullet") 
		{
			anim.SetTrigger ("Hurt");
			anim.SetInteger ("Health", anim.GetInteger ("Health") - attackRangedDamage);
			health -= attackRangedDamage;
		}

		if (anotherObject.collider.tag == "Player") 
		{
			anim.SetTrigger ("Hurt");
			anim.SetInteger ("Health", anim.GetInteger ("Health") - attackMeeleDamage);
			health -= attackMeeleDamage;
		}
	}
}
