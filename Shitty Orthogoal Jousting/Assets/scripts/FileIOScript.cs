//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//
//public class FileIOScript : MonoBehaviour {
//
//	// I FEEL LIKE THIS IS ALL TOTALLY UNNECESSARY AND I'M BEING INEFFICIENT AND WRONG
//	// SO I'VE CUT IT ALL
// 	// RIP
//
//	// SCRIPTS
//	public ScorerScript scorer;
//	public HealthManagerScript healthManager;
//
//	// KEEPING TRACK OF DAMAGE
//	public string damageFileName = "damageKeeper.txt";
//
//	public List <int> damageKeeper1;
//	public List <int> damageKeeper2;
//
//	// KEEPING TRACK OF SCORES
//	public string scoreFileName = "scoreKeeper.txt";
//	string finalFilePathDamage;
//	string finalFilePathScore;
//
//	public List <int> timesWon1;
//	public List <int> timesWon2;
//
//
//	// Use this for initialization
//	void Start () {
//
//		scorer = GameObject.Find ("Player1").GetComponent<ScorerScript> ();
//		healthManager = gameObject.GetComponent<HealthManagerScript> ();
//
//		// finding where the computer stores the thing
////		Debug.Log ("Path: " + Application.dataPath);
////
////		finalFilePathDamage = Application.dataPath + "/" + damageFileName;
////		finalFilePathScore = Application.dataPath + "/" + scoreFileName;
////
////		// score tracker for 1
////		StreamWriter winner1 = new StreamWriter (finalFilePathScore, true);
////
////		for (int i = 0; i < timesWon1.Count; i++) {
////			winner1.WriteLine ("1 won: " + timesWon1[i]);
////		}
////
////		winner1.Close ();
////
////		// score tracker for 2
////		StreamWriter winner2 = new StreamWriter (finalFilePathScore, true);
////
////		for (int i = 0; i < timesWon2.Count; i++) {
////			winner2.WriteLine ("2 won: " + timesWon2[i]);
////		}
////
////		winner2.Close ();
////
////		// READ FROM A FILE
////		StreamReader srDmg = new StreamReader (finalFilePathDamage);
////		while (!srDmg.EndOfStream) {
////
////			string line = srDmg.ReadLine ();
////
////			string[] splitLine = line.Split (':');
////
////			string players = splitLine [0];
////			string values = splitLine [1];
////
////			if (players.Contains ("damage 1")) {
////				damageKeeper1.Add(values[0]);
////			} else if (players.Contains("damage 2")){
////				damageKeeper2.Add (values[1]);
////			}
////		}
////
////		srDmg.Close ();
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//		Debug.Log ("Damage 1: " + damageKeeper1.Count);
//		Debug.Log ("Damage 2: " + damageKeeper2.Count);
//
////		if (scorer.damageDone == true) {
////			// writing the damage info to a file
////			StreamWriter swDmg1 = new StreamWriter(finalFilePathDamage, true);
////
////			for (int i = 0; i < damageKeeper1.Count; i++){
////				swDmg1.WriteLine ("damage 1: " + damageKeeper1[i]);
////			}
////
////			swDmg1.Close ();
////
////			// damage writer for 2
////			StreamWriter swDmg2 = new StreamWriter (finalFilePathDamage, true);
////
////			for (int i = 0; i < damageKeeper2.Count; i++) {
////				swDmg2.WriteLine ("damage 2: " + damageKeeper2[i]);
////			}
////
////			swDmg2.Close ();
////		}
//	}
//}
