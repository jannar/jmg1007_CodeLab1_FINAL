using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is all copied from player movement but like
// it seemed like too much effort to replace the whole thing here
// when it all works somewhere else
// why reinvent the wheel, yanno?

public class PlatformWrapScript : MonoBehaviour {

	// screen boundary variables
	public float leftConstraint, rightConstraint, bottomConstraint, topConstraint;
	public float buffer = 1.0f;		// this is for the purpose of disappearing before reappearing
	public float distanceZ = 10.0f;
	Camera cam;

	// Use this for initialization
	void Start () {

		cam = Camera.main;
		distanceZ = Mathf.Abs (cam.transform.position.z + transform.position.z);
		leftConstraint = cam.ScreenToWorldPoint (new Vector3(0.0f, 0.0f, distanceZ)).x;
		rightConstraint = cam.ScreenToWorldPoint (new Vector3(Screen.width, 0.0f, distanceZ)).x;
		bottomConstraint = cam.ScreenToWorldPoint (new Vector3(0.0f, 0.0f, distanceZ)).y;
		topConstraint = cam.ScreenToWorldPoint (new Vector3 (0.0f, Screen.height, distanceZ)).y;
		
	}

	void FixedUpdate(){

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
}
