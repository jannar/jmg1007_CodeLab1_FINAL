using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// USE ALL THE THINGS!!!!

public class SceneManagerScript : MonoBehaviour {

	public Button startText;
	public Button instructionsText;

	public static SceneManagerScript instance;

	// FOR BEIN' ABLE TO TELL IF THIS HAS ALL BEEN DONE BEFORE
	public int reloads = 0;

	// FOR LOADING NEW LEVELS
	// offsets
	public float offsetX = -10;
	public float offsetY = -4;

	// array for text levels
	// note: i really wanted to generate these procedurally
	// but I did not have the time
	// I did, however, read that book on Spelunky, so I hope that counts for something
	public string[] fileNames;
	public static int levelNum = 0;

	public Text text;

	public Scene currentScene;
	public Scene inactiveScene1;
	public Scene inactiveScene2;
	public string sceneName;
	public string inactive1;
	public string inactive2;

	// Use this for initialization
	public void Start () {

		currentScene = SceneManager.GetActiveScene ();

		sceneName = currentScene.name;

		inactiveScene1 = SceneManager.GetSceneByName ("p1-winning");
		inactive1 = inactiveScene1.name;
		inactiveScene2 = SceneManager.GetSceneByName ("p2-winning");
		inactive2 = inactiveScene2.name;

		if (sceneName == "instructions") {
			startText = startText.GetComponent<Button> ();
			instructionsText = instructionsText.GetComponent<Button> ();
		}

		LevelLoader (inactiveScene1, inactiveScene2);
		
	}

	public void StartLevel(){
		SceneManager.LoadScene (1);
	}

	public void ShowInstructions(){
		SceneManager.LoadScene (0);
	}

	public void P1InCharge(){
		SceneManager.LoadScene (3);
		//LevelLoader ();
	}

	public void P2InCharge(){
		SceneManager.LoadScene (4);
		//LevelLoader ();
	}

	public void LevelLoader(Scene scene1, Scene scene2){
		//currentScene = SceneManager.GetActiveScene ();

		//sceneName = currentScene.name;

		if (inactive1 == "p1-winning" || inactive2 == "p2-winning") {
			Font style = Resources.Load <Font> ("Nunito-Regular");

			// strings for places and things for the streamreader
			//string filename = fileNames [levelNum];
			string filename = ("level1.txt");
			string filePath = (Path.Combine (Application.dataPath, filename));

			// streamreader to read levels from files
			StreamReader sr = new StreamReader (filePath);

			// keep track of where the fuck we are
			int yPos = 0;

			// instantiate players from prefabs
			GameObject player1 = Instantiate (Resources.Load ("prefabs/Player1") as GameObject);
			GameObject player2 = Instantiate (Resources.Load ("prefabs/Player2") as GameObject);

			while (!sr.EndOfStream) {
				string line = sr.ReadLine ();

				for (int xPos = 0; xPos < line.Length; xPos++) {
					float randomX = Random.Range (0.5f, 2f);
					float randomY = Random.Range (1f, 3f);

					if (line [xPos] == 'X') {
						GameObject cube = Instantiate (Resources.Load ("prefabs/Cube") as GameObject);

						cube.transform.localScale = new Vector3 (randomX, randomY, 0);

						cube.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);
						Debug.Log ("cube moved");
					}

					if (line [xPos] == '1') {
						player1.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);
					}

					if (line [xPos] == '2') {
						player1.transform.position = new Vector3 (xPos + offsetX, yPos + offsetY, 0);
					}
				}

				yPos--;
			}

			sr.Close ();

			levelNum++;

			Canvas canvas = FindObjectOfType<Canvas> ();

			text = canvas.gameObject.AddComponent<Text> ();
			text.transform.parent = canvas.transform;
			text.font = style;
			text.fontSize = 25;
			text.alignment = TextAnchor.MiddleCenter;
			text.text = "CRAZY RANDOM BLOCK MODE Y'ALL";

			if (Input.anyKey) {
				Destroy (text);
			}
		}
	}
}
