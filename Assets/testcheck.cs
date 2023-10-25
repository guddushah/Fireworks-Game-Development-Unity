using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcheck : MonoBehaviour {
	bool checkstate = false;
	bool goingToExplode = false;
	int timer = 0;

	[HideInInspector] public string blockname;
	string ballname;

	public bool rowDestroyer;
	public bool columnDestroyer;
	public bool areaDestroyer;
	bool isRowColumnEnabled = false;
	bool isAreaEnabled = false;

	bool ballCollided = false;

	GameObject ScoreManager;

    bool playAudio = false;
    GameObject soundObject;
    public GameObject[] explosion;
    bool canEffect = true;
	// Use this for initialization
	void Start () {
		blockname = GetComponent<ballcolorname>().ballColor;
		ScoreManager = GameObject.Find ("ScoreManager");
        soundObject = GameObject.Find("soundObj");
	}
	
	// Update is called once per frame
	void Update () {
		if (checkstate) {
			check4sides ();
		}
		if (goingToExplode) {
			timer += 1;
            soundObject.GetComponent<AudioSource>().Play();
			if (timer > 3) {
				IncreaseScore ();
              //  Instantiate(soundObject, new Vector3(0, 0, 0), Quaternion.identity);
               // Instantiate(explosion[1], transform.position, Quaternion.identity);
                
                GenerateExplosion();
				Destroy (this.gameObject);
			}

			 

		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == blockname) {
			if (transform.position.y < 7.13) {
				check4sides ();
				goingToExplode = true;
				EnableRowColumnAreaDestroyer ();
                canEffect = false;
			}

		}
		if (col.tag == "RowChecker") {
			goingToExplode = true;
			EnableRowColumnAreaDestroyer ();
		}
		if (col.tag == "ColumnChecker") {
			if (transform.position.y < 7.13) {
				goingToExplode = true;
				EnableRowColumnAreaDestroyer ();
			}
		}
		if (col.tag == "AreaChecker") {
			goingToExplode = true;

			EnableRowColumnAreaDestroyer ();
		}
		if (col.tag == "death") {
			//GameObject.Find ("GameObject").GetComponent<vel> ().gameOverPanel.SetActive (true);
			GameObject.Find("ScoreManager").GetComponent<scoreSystem>().storeScore();
			GameObject.Find ("GameObject").GetComponent<vel> ().startTimer = false;
			GameObject.Find ("GameObject").GetComponent<vel> ().move = false;
			GameObject.Find ("GameObject").GetComponent<vel> ().oneMoreChance.SetActive (true);
			GameObject.Find ("ball (1)").GetComponent<ball> ().canInteract = false;
			GameObject.Find ("GameObject").GetComponent<vel> ().runTimePlayed = false;
			int timePlayed = Mathf.RoundToInt(GameObject.Find ("GameObject").GetComponent<vel> ().timePlayed);
			PlayerPrefs.SetInt ("TimePlayed", timePlayed);
			GameObject.Find ("ScoreManager").GetComponent<scoreSystem> ().TimePlayed = timePlayed;

		}
	}

	void OnCollisionEnter2D(Collision2D col2){
		

		if (col2.gameObject.tag == "ball" )
		{
			
			ballname = col2.gameObject.GetComponent<ball>().ballColorName;
			if(ballname == blockname)
			{
				goingToExplode = true;
				checkstate = true;
				ballCollided = true;
                canEffect = false;
				if (rowDestroyer || columnDestroyer) {
					isRowColumnEnabled = true;
					CheckRowColumn ();
				}
				if (areaDestroyer) {
					isAreaEnabled = true;
					CheckArea ();
				}

				col2.gameObject.GetComponent<ball>().NewBall();

			}
			if (ballname != blockname) {
				/*
				if (rowDestroyer || columnDestroyer) {
					isRowColumnEnabled = true;
					CheckRowColumn ();
					goingToExplode = true;
				}

				if (areaDestroyer) {
					isAreaEnabled = true;
					CheckArea ();
					goingToExplode = true;
				}
					*/
				col2.gameObject.GetComponent<ball>().NewBall();


			}


		}
	}

	void check4sides(){
		this.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (1).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (2).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (3).gameObject.SetActive (true);
	}

	void CheckRowColumn(){
		this.gameObject.transform.GetChild (4).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (5).gameObject.SetActive (true);
	}

	void CheckArea(){
		this.gameObject.transform.GetChild (4).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (5).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (6).gameObject.SetActive (true);
		this.gameObject.transform.GetChild (7).gameObject.SetActive (true);
	}

	void EnableRowColumnAreaDestroyer(){
		if (rowDestroyer || columnDestroyer) {
			isRowColumnEnabled = true;
			CheckRowColumn ();
		}
		if (areaDestroyer) {
			isAreaEnabled = true;
			CheckArea ();
		}
	}

	void IncreaseScore(){
		ScoreManager.GetComponent<scoreSystem> ().score++;
		ScoreManager.GetComponent<scoreSystem> ().UpdateScoretext ();
	}
    void GenerateExplosion() {
        if (blockname == "red") {
            Instantiate(explosion[0], transform.position, Quaternion.identity);
        }
        if (blockname == "blue")
        {
            Instantiate(explosion[1], transform.position, Quaternion.identity);
        }
        if (blockname == "green")
        {
            Instantiate(explosion[2], transform.position, Quaternion.identity);
        }
        if (blockname == "yellow")
        {
            Instantiate(explosion[3], transform.position, Quaternion.identity);
        }
        if (blockname == "purple")
        {
            Instantiate(explosion[4], transform.position, Quaternion.identity);
        }
        if (blockname == "orange")
        {
            Instantiate(explosion[5], transform.position, Quaternion.identity);
        }
    }
}
