﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	float horizontalMovement = 0f;
	float verticalMovement = 0f;
	const float minimumHeightForJump = 1.2f;
	Rigidbody rb;

	public float moveSpeed;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		horizontalMovement = 0f;
		verticalMovement = 0f;
		moveSpeed = 7.5f;
		rotationSpeed = 100f;

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Jump ();
	    Rotate ();
		Shoot (); 

	}

	void Move(){
		
		verticalMovement = Input.GetAxis ("Vertical");
		if (verticalMovement != 0) {
			gameObject.transform.Translate (0, 0, verticalMovement * moveSpeed * Time.deltaTime);
		}
	}

	void Rotate(){
		horizontalMovement = Input.GetAxis ("Horizontal");
		if ( horizontalMovement != 0) {
			gameObject.transform.Rotate (0, horizontalMovement * rotationSpeed * Time.deltaTime, 0);
		}
	}

	void Jump(){
		if (Input.GetKeyDown (KeyCode.Space) && rb.velocity.y <=0 && rb.velocity.y >= -0.1f) {
			rb.velocity = new Vector3 (0, 10f, 0);
		}
	}

	void Shoot(){
		
	}

	public void Dead(){
		transform.GetComponentInChildren<Camera> ().GetComponent<Transform> ().parent = null;
		Destroy (gameObject);
	}

}
