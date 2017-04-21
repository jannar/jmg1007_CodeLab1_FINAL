using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorerScript : MonoBehaviour {

	// GAME OBJECTS
	public GameObject player1, player2;

	// VARIABLES FOR DAMAGE AND SPEED
	public int player1Damage, player2Damage;
	public PlayerMovementScript pms;
	private const int MIN_SPEED = 1;
	private const int MAX_SPEED = 50;

	// FIND THE HEALTH STUFF
	public GameObject gameManager;
	public HealthManagerScript hms;
	public ScoreManagerScript scoreManager;

	public bool damageDone;

	// TEXT MESH
	public Text healthText;

	// Use this for initialization
	void Start () {

		gameManager = GameObject.Find("GameManager");
		scoreManager = gameManager.GetComponent<ScoreManagerScript> ();
		hms = gameManager.GetComponent<HealthManagerScript> ();
		pms = gameObject.GetComponent<PlayerMovementScript> ();
		healthText = GameObject.Find ("Health").GetComponent<Text> ();

		healthText.text = "Health Remaining: " + hms.BoxHealth;
		healthTextColorChanger ();

	}
	
	// Update is called once per frame
	void Update () {

		if (this.pms.speed < MIN_SPEED) {
			this.pms.speed = MIN_SPEED;
		}

		if (this.pms.speed > MAX_SPEED) {
			this.pms.speed = MAX_SPEED;
		}

		healthTextColorChanger ();

		if (hms.BoxHealth == 0) {
			this.pms.speed = MIN_SPEED;
			scoreManager.FindTheWinner();
		}
	}

	void FixedUpdate(){

		if (pms.player2Move && Input.GetKey (KeyCode.RightShift)) {
			healthReturn (player1Damage);
			Debug.Log ("health added: " + hms.BoxHealth);
		}

		healthText.text = "Health Remaining: " + hms.BoxHealth;

	}

	void OnCollisionEnter2D(Collision2D other) {

		CameraShake shake = GameObject.Find ("Shaker").GetComponent<CameraShake> ();

		if (other.gameObject.name.Contains ("Player1") && pms.player2Move) {
			Damager (player2, player2Damage);
			scoreManager.damageKeeper1.Add (player2Damage);
			shake.Shake(0.1f, 0.25f);
		}

		if (other.gameObject.name.Contains("Player2") && pms.player1Move) {
			Damager (player1, player1Damage);
			scoreManager.damageKeeper2.Add (player1Damage);
			shake.Shake(0.1f, 0.25f);
		}

		healthText.text = "Health Remaining: " + hms.BoxHealth;
	}

	public void Damager(GameObject go, int damage){

		hms.BoxHealth = hms.BoxHealth - damage;

		if (go == player1) {
//			scoreManager.damageKeeper1.Add (damage);
			damage++;
			pms.speed--;
			Debug.Log ("Damage done 1: " + damage);
			damageDone = true;

		} else if (go == player2) {
//			scoreManager.damageKeeper2.Add (damage);
			damage--;
			pms.speed = pms.speed + 0.5f;
			Debug.Log ("Damage done 2: " + damage);
			damageDone = true;
		}

		damageDone = false;

		if (damage > 1) {
			damage = 1;
		}
	}

	public void healthReturn(int plusHealth){
		hms.BoxHealth = hms.BoxHealth + (plusHealth - 2);
	}

	public void healthTextColorChanger(){
		if (hms.BoxHealth >= 30) {
			healthText.color = Color.green;
		}

		if (hms.BoxHealth < 30 && hms.BoxHealth > 10) {
			healthText.color = Color.yellow;
		}

		if (hms.BoxHealth < 10) {
			healthText.color = Color.red;
		}
	}
}
