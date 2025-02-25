﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;



	// Update is called once per frame
	 void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("Jumping", true);
		}

		//if (Input.GetButtonDown("Crouch"))
		//{
		//	crouch = true;
		//}
		//else if (Input.GetButtonUp("Crouch"))
		//{
		//	crouch = false;
		//}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Coin"))
		{
			Destroy(collision.gameObject);
		}
	}

	public void OnLanding()
	{
		animator.SetBool("Jumping", false);
	}

 void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
