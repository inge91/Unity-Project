﻿using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	
	bool right = false;
	bool left = false;
	bool up = false;
	bool down = false;
	
	float speed = 3;
	float move_block = 150;
	float jump_speed = 0;
	
	
	
	GameObject camera; 	
	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {	
		handleInput();
		handleMotion();
	}
	
	void handleInput()
	{
		if(Input.GetKeyDown(KeyCode.D))
		{	
			right = true;
		}

		if(Input.GetKeyUp (KeyCode.D))
		{
			right = false;
		}
		
		if(Input.GetKeyDown(KeyCode.A))
		{	
			left = true;
		}

		if(Input.GetKeyUp (KeyCode.A))
		{
			left = false;
		}

		if(Input.GetKeyDown (KeyCode.Space))
		{
			rigidbody.velocity += 300 * Vector3.up;
		}

	}
	
	void handleMotion()
	{
		if(right)
		{ 
			transform.Translate(speed, 0, 0);
			moveCamera(speed);
		}
		if(left)
		{
			transform.Translate(-speed, 0, 0);
			moveCamera(-speed);	
		}
	}
	
	void moveCamera(float offset)
	{
		if(transform.position.x > camera.transform.position.x + move_block && right)
		{
			camera.transform.Translate (offset, 0, 0);
		}	
		if(transform.position.x < camera.transform.position.x - move_block && left)
		{
			camera.transform.Translate (offset, 0, 0);
		}	
	}
	
	
}
