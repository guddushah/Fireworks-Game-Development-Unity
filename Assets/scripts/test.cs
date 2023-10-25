using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10);
		if (hit.collider.tag == "blue") {
			Debug.Log ("working");
		}
		Vector2 forward = transform.TransformDirection(-Vector2.up) * 10;
		Debug.DrawRay(transform.position, forward, Color.green);
	}

	/*void rayTest(){
		//RaycastHit hit;
		//Ray testRayUp = new Ray (transform.position, Vector2.right);

		if (Physics.Raycast (testRayUp, out hit, 20)) {
			if (hit.collider.tag == "blue") {
				Debug.Log("Blue on rightside");
			}
		}
	}*/
}
