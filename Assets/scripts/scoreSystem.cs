using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour {
	public int score;
	public Text scoreText;
	public int TimePlayed;
	public int totalScore;
	bool storeNow = true;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("HighScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScoretext(){
		scoreText.text = score.ToString ();
	}
	public void storeScore(){
		if (storeNow) {
			//TimePlayed = PlayerPrefs.GetInt ("TimePlayed");

			totalScore = TimePlayed + score;
			Debug.Log (totalScore);
			PlayerPrefs.SetInt ("Score", score);
			/*int tempHighScore = PlayerPrefs.GetInt ("HighScore");
			if (totalScore > tempHighScore) {
			
				PlayerPrefs.SetInt ("HighScore", totalScore);
			}*/
			storeNow = false;
		}

	}

	public void Reload(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
