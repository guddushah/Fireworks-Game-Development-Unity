using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newTest : MonoBehaviour {
	public GameObject blockObj;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			GameObject go =Instantiate (blockObj, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
			go.transform.parent = GameObject.Find("GameObject").transform;
			Vector2 newPos = transform.position;
			newPos.y += 1.218f;
			transform.position = newPos;

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			GameObject go =Instantiate (blockObj, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
			go.transform.parent = GameObject.Find("GameObject").transform;
			Vector2 newPos = transform.position;
			newPos.y += 1.218f;
			transform.position = newPos;
		}

	}
	public void GenerateNew(){
		GameObject go =Instantiate (blockObj, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		go.transform.parent = GameObject.Find("GameObject").transform;
		Vector2 newPos = transform.position;
		newPos.y += 1.218f;
		transform.position = newPos;
	}

}
