using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomblock : MonoBehaviour {
	public GameObject[] blockObj;
	float initialPosX = -4.273999f;
	int randomNumber;
	public GameObject gameoverPanel;
	// Use this for initialization
	void Start () {
		/*for (int i = 0; i < 8; i++) {
			GameObject go = Instantiate (blockObj [Random.Range (0, 9)], new Vector2 (initialPosX, transform.position.y), Quaternion.identity) as GameObject;
			go.transform.parent = GameObject.Find("GameObject").transform;
			initialPosX += 1.218f;
		}
		*/
		for (int i = 0; i < 8; i++) {
			randomNumber = Random.Range (0, 30);
			if (randomNumber == 3) {
				GameObject go = Instantiate (blockObj [Random.Range (6, 9)], new Vector2 (initialPosX, transform.position.y), Quaternion.identity) as GameObject;
				go.transform.parent = GameObject.Find ("GameObject").transform;
				initialPosX += 1.218f;
			} else {
				GameObject go = Instantiate (blockObj [Random.Range (0, 6)], new Vector2 (initialPosX, transform.position.y), Quaternion.identity) as GameObject;
				go.transform.parent = GameObject.Find ("GameObject").transform;
				initialPosX += 1.218f;
			}
		}

		gameoverPanel = GameObject.Find ("GameOverPanel");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "death") {
			Debug.Log ("You Died");
			GameObject.Find ("GameObject").GetComponent<vel> ().gameOverPanel.SetActive (false);
		}
	}
}
