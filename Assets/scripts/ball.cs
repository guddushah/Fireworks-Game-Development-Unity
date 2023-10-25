using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	Rigidbody2D ballrb;
	private Vector2 mouseStartPosition;
	private Vector2 mouseEndPosition;
	public bool didClick;
	public bool didDrag;
	public bool canInteract;
	private float ballVelocityX;
	private float ballVelocityY;
	public float constantSpeed;
	public GameObject arrow;
	Vector2 startPosition;
	public GameObject dotarray;

	int randomColorNumber;
	public string ballColorName = "purple";

	public GameObject[] newballcolor;

	// Use this for initialization
	void Start () {
		ballrb = GetComponent<Rigidbody2D> ();
		startPosition = new Vector2 (transform.position.x, transform.position.y);
		NewBall ();
	

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && canInteract) {
			MouseClicked ();
		}
		if (Input.GetMouseButton (0) && canInteract) {
			MouseDragged ();
		}
		if (Input.GetMouseButtonUp(0) && canInteract) {
			MouseReleased ();
		}

		//Test Reload
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void MouseClicked(){
		//mouseStartPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseStartPosition = startPosition;
		didClick = true;
		arrow.SetActive (true);
	}

	void MouseDragged(){
		didDrag = true;
		//Moving Arrow
		arrow.SetActive(true);
		Vector2 tempMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float diffx = (mouseStartPosition.x - tempMousePosition.x);
		float diffy = (mouseStartPosition.y - tempMousePosition.y);

//		if (diffy <= 0) {
//			diffy = 0.01f;
//		}
		float arrowAngle = Mathf.Rad2Deg * Mathf.Atan (diffx / diffy);
		arrow.transform.rotation = Quaternion.Euler (0f, 0f, -arrowAngle);
	}

	void MouseReleased(){
		mouseEndPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x);
		ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y);
		Vector2 tempVelocity = new Vector2 (ballVelocityX, ballVelocityY).normalized;
		if (mouseEndPosition.y < 7.24f) {
			ballrb.velocity = -tempVelocity * constantSpeed;
			GetComponent<AudioSource> ().Play ();
		}
		arrow.SetActive (false);
		if (ballrb.velocity == Vector2.zero) {
			return;
		}
		didClick = false;
		didDrag = false;
		canInteract = false;

	}

	/// <summary>
	/// G/////////////////////////////////	/// 
	public void GenerateBallColor() {
		/*
		randomColorNumber = Random.Range (0, 6);
		if (randomColorNumber == 0) {
			ballColorName = "red";
			GetComponent<SpriteRenderer> ().color = Color.red;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.red;
		} else if (randomColorNumber == 1) {
			ballColorName = "green";
			GetComponent<SpriteRenderer> ().color = Color.green;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.green;
		} else if (randomColorNumber == 2) {
			ballColorName = "blue";
			GetComponent<SpriteRenderer> ().color = Color.blue;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.blue;
		} else if (randomColorNumber == 3) {
			ballColorName = "yellow";
			GetComponent<SpriteRenderer> ().color = Color.yellow;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.yellow;
		} else if (randomColorNumber == 4) {
			ballColorName = "orange";
			GetComponent<SpriteRenderer> ().color = new Color (0.93333f, 0.5090f, 0.117647f);
			dotarray.GetComponent<SpriteRenderer> ().color = new Color (0.93333f, 0.5090f, 0.117647f);
		} else if (randomColorNumber == 5) {
			ballColorName = "purple";
			GetComponent<SpriteRenderer> ().color = new Color (0.29019f, 0.1960f, 0.48235f);
			dotarray.GetComponent<SpriteRenderer> ().color = new Color (0.29019f, 0.1960f, 0.48235f);
		}
		//GetComponent<SpriteRenderer> ().color = new Color (0.93333f, 0.5090f, 0.117647f);
		*/
//		ballColorName = "red";
//		GetComponent<SpriteRenderer> ().color = Color.red;
//		dotarray.GetComponent<SpriteRenderer> ().color = Color.red;
//		newballcolor[Random.Range(0,8)].GetComponent<raycast>().ballcolorname

		randomColorNumber = Random.Range (0, 6);
		Debug.Log (newballcolor [randomColorNumber].GetComponent<raycast> ().ballcolorname);
		Debug.Log (randomColorNumber);
		if (newballcolor[randomColorNumber].GetComponent<raycast>().ballcolorname == "red") {
			ballColorName = "red";
			GetComponent<SpriteRenderer> ().color = Color.red;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.red;
		} else if (newballcolor[randomColorNumber].GetComponent<raycast>().ballcolorname == "green") {
			ballColorName = "green";
			GetComponent<SpriteRenderer> ().color = Color.green;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.green;
		} else if (newballcolor[randomColorNumber].GetComponent<raycast>().ballcolorname == "blue") {
			ballColorName = "blue";
			GetComponent<SpriteRenderer> ().color = Color.blue;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.blue;
		} else if (newballcolor[randomColorNumber].GetComponent<raycast>().ballcolorname == "yellow") {
			ballColorName = "yellow";
			GetComponent<SpriteRenderer> ().color = Color.yellow;
			dotarray.GetComponent<SpriteRenderer> ().color = Color.yellow;
		} else if (newballcolor[randomColorNumber].GetComponent<raycast>().ballcolorname == "orange") {
			ballColorName = "orange";
			GetComponent<SpriteRenderer> ().color = new Color (0.93333f, 0.5090f, 0.117647f);
			dotarray.GetComponent<SpriteRenderer> ().color = new Color (0.93333f, 0.5090f, 0.117647f);
		} else if (newballcolor[randomColorNumber].GetComponent<raycast>().ballcolorname == "purple") {
			ballColorName = "purple";
			GetComponent<SpriteRenderer> ().color = new Color (0.29019f, 0.1960f, 0.48235f);
			dotarray.GetComponent<SpriteRenderer> ().color = new Color (0.29019f, 0.1960f, 0.48235f);
		}
	}

	public void NewBall(){
		ballrb.velocity = new Vector2 (0,0);
		transform.position = startPosition;
		GenerateBallColor ();
		canInteract = true;
		Debug.Log("working");
	}

}
