using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainBestScore : MonoBehaviour {
    public Text highscore;
    int highScore;
	// Use this for initialization
	void Start () {
      //  scoreText.text = (PlayerPrefs.GetInt("HighScore")).ToString();
         highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("HighScore" + highScore.ToString());
        highscore.text = highScore.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
        //score = PlayerPrefs.GetInt("HighScore");
       // scoreText.text = score.ToString();
	}
}
