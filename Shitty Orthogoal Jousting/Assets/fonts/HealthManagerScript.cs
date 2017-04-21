using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

	// VARIABLES FOR HEALTH
	// MAKE THESE MORE INTERESTING
	private const int BOX_HEALTH_MIN = 0;
	private const int BOX_HEALTH_MAX = 50;

	private static int boxHealth;

	public int BoxHealth{

		get{ 
			return boxHealth;
		}

		set { 
			boxHealth = value;

			if (boxHealth > BOX_HEALTH_MAX) {
				boxHealth = BOX_HEALTH_MAX;
			}
			if (boxHealth < BOX_HEALTH_MIN) {
				boxHealth = BOX_HEALTH_MIN;
			}
		}
		
	}

	// VARIABLES FOR DAMAGE

	// Use this for initialization
	void Start () {

		BoxHealth = BOX_HEALTH_MAX;
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
