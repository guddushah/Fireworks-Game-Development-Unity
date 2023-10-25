using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour {
	public string ballcolorname;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up);
		if (hit.collider != null) {
			//Debug.Log (hit.collider.gameObject.GetComponent<ballcolorname>().ballColor);
			ballcolorname = hit.collider.gameObject.GetComponent<ballcolorname> ().ballColor;
		}
	}
}
