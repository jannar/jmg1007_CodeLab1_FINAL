using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

	// inputs
	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;

	// game objects
	public GameObject player1, player2;
	public bool player1Move, player2Move;

	// game speed modifiers
	public float p1Mod, p2Mod;
	public float speed;

	// make this into a property/getset thing later
	float originalSpeed;

	// screen boundary variables
	public float leftConstraint, rightConstraint, bottomConstraint, topConstraint;
	public float buffer = 1.0f;		// this is for the purpose of disappearing before reappearing
	public float distanceZ = 10.0f;
	Camera cam;

	// Use this for initialization
	void Start () {

		// SCREEN WRAPPING
		cam = Camera.main;
		distanceZ = Mathf.Abs (cam.transform.position.z + transform.position.z);
		leftConstraint = cam.ScreenToWorldPoint (new Vector3(0.0f, 0.0f, distanceZ)).x;
		rightConstraint = cam.ScreenToWorldPoint (new Vector3(Screen.width, 0.0f, distanceZ)).x;
		bottomConstraint = cam.ScreenToWorldPoint (new Vector3(0.0f, 0.0f, distanceZ)).y;
		topConstraint = cam.ScreenToWorldPoint (new Vector3 (0.0f, Screen.height, distanceZ)).y;
		
	}
	
	// Update is called once per frame
	void Update () {

		// MOVEMENT KEYS
		Move (Vector3.up, upKey);
		Move (Vector3.down, downKey);
		Move (Vector3.left, leftKey);
		Move (Vector3.right, rightKey);
		
	}

	void FixedUpdate(){

		// SCREEN WRAPPING
		if (transform.position.x < leftConstraint - buffer) {
			transform.position = new Vector3 (rightConstraint - buffer, transform.position.y, transform.position.z);
		}

		if (transform.position.x > rightConstraint + buffer) {
			transform.position = new Vector3 (leftConstraint - buffer, transform.position.y, transform.position.z);
		}

		if (transform.position.y < bottomConstraint - buffer){
			transform.position = new Vector3 (transform.position.x, topConstraint + buffer, transform.position.z);
		}

		if (transform.position.y > topConstraint + buffer){
			transform.position = new Vector3 (transform.position.x, bottomConstraint - buffer, transform.position.z);
		}

	}

	void Move(Vector3 dir, KeyCode key){

		// P1 MOVEMENT RULES
		if (this.gameObject== player1) {
			if (Input.GetKey (key)) {
				transform.Translate (dir * (speed + p1Mod) * Time.deltaTime);
				player1Move = true;
			} else {
				player1Move = false;
			}
		}

		// P2 MOVEMENT RULES
		if (this.gameObject == player2){
			if (Input.GetKey (key)) {
				transform.Translate (dir * (speed + p2Mod) * Time.deltaTime);
				player2Move = true;
			} else {
				player2Move = false;
			}
		}
	}
}
