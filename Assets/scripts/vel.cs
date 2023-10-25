using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vel : MonoBehaviour {
	public float velocity;
	[HideInInspector]public bool move = true;
	Vector3 startPos;
	Vector3 newPos;
	[HideInInspector]public bool startTimer = false;
	bool storeNow = false;
	float timer;
	[HideInInspector]public float timePlayed;
	[HideInInspector]public bool runTimePlayed = true;
	newTest spawnScript;
	[HideInInspector]public GameObject gameOverPanel;
	public GameObject oneMoreChance;
	bool isOneMoreChance = false;
	Vector3 replayPos;

	// Use this for initialization
	void Start () {
		Debug.Log (Mathf.RoundToInt (13.4f));
		startPos = transform.position;
		newPos = transform.position;
		newPos.y -= 1.218f;
		spawnScript = GameObject.Find ("Hello").GetComponent<newTest> ();
		gameOverPanel = GameObject.Find ("GameOverPanel");
		//gameOverPanel.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		float speed = velocity * Time.deltaTime;
		//transform.position = new Vector2 (transform.position.x, transform.position.y+speed);
		if (move) {
			
			transform.position = Vector3.Lerp (transform.position, newPos, 8 * Time.deltaTime);
			if (transform.position == newPos) {
				timer = 0;
				startTimer = true;
				test ();
			}
		}

		if (startTimer) {
			timer += Time.deltaTime;
			if (timer > 10f) {
				move = true;
				spawnScript.GenerateNew ();
				startTimer = false;
			}
		}

		if (isOneMoreChance) {
			
			transform.position = Vector3.Lerp (transform.position, replayPos, 8 * Time.deltaTime);
			if (transform.position == replayPos) {
				timer = 0;
				newPos = transform.position;
				test ();
				startTimer = true;
				isOneMoreChance = false;

			}
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			EnableOneMoreChance ();
		}
		if (runTimePlayed) {
			timePlayed += Time.deltaTime;
		}
	}
	void test(){
		move = false;
		newPos.y -= 1.218f;
	}

	public void EnableOneMoreChance(){
		replayPos = transform.position;
		replayPos.y += 1.218f * 5;
		isOneMoreChance = true;
		GameObject.Find ("ball (1)").GetComponent<ball> ().canInteract = true;
		runTimePlayed = true;
	}
}
