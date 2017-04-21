using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour {

	// FIND THE HEALTH STUFF
	public HealthManagerScript hms;
	public SceneManagerScript sceneManager;

	// FOR SCORING
	public List <int> damageKeeper1;
	public List <int> damageKeeper2;
	public int total1;
	public int total2;
	public List <int> timesWon1;
	public List <int> timesWon2;

	// TEXT MESH
	public GameObject winner;
	public Text winnerText;

	// Use this for initialization
	public void Start () {

		hms = gameObject.GetComponent<HealthManagerScript> ();
		sceneManager = GameObject.Find ("GameManager").GetComponent<SceneManagerScript> ();

//		winner = GameObject.Find("Winner");
//		winnerText = winner.GetComponent<Text> ();
//		winnerText.text = " ";
		
	}

	public void FindTheWinner () {

		winner = GameObject.Find("Winner");
		winnerText = winner.GetComponent<Text> ();
		winnerText.text = " ";

		// total the lists
		//ListTotaler (damageKeeper1, total1);
		//ListTotaler (damageKeeper2, total2);

		total1 = damageKeeper1.Count;
		total2 = damageKeeper2.Count;

		// compare the values and add the wins
		if (total1 > total2) {
			timesWon1.Add(1);
			winnerText.text = "Player 1 wins this round";
		} else if (total2 > total1) {
			timesWon2.Add(1);
			winnerText.text = "Player 2 wins this round";
		} else if (total1 == total2) {
			winnerText.text = "It's a draw, r to reset";
		}
			
		// choosing scenes to reload
		if (winnerText.text.Contains ("1")) {
			sceneManager.P2InCharge ();
			sceneManager.reloads++;
		} else if (winnerText.text.Contains ("2")) {
			sceneManager.P1InCharge ();
			sceneManager.reloads++;
		} else if (winnerText.text.Contains ("draw")) {
			if (Input.GetKeyDown (KeyCode.R)) {
				//sceneManager.StartLevel ();
				sceneManager.P1InCharge();
				sceneManager.reloads++;
			}
		}
			
	}

	public void ListTotaler(List<int> list, int f){
		for (int i = 0; i < list.Count; i++){
			foreach (int j in list) {
				f += j;
			}
		}
	}
}
