using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDeathScene : MonoBehaviour {
	public Text ScoreText;
	public Text HighScoreText;
	public Text TimeText;
	public Text TotalScoreText;
	int score;
	int highScore;
	int timePlayed;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		highScore = PlayerPrefs.GetInt ("HighScore");

		ScoreText.text = "Blocks : " + score.ToString ();

		timePlayed = PlayerPrefs.GetInt ("TimePlayed");
		TimeText.text = "Time: " + timePlayed.ToString();
		int totalScore = score + timePlayed;
		TotalScoreText.text = "Total : " + totalScore.ToString ();
		if (totalScore > highScore) {
			highScore = totalScore;
		}
		HighScoreText.text = "HighScore : " + highScore.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
