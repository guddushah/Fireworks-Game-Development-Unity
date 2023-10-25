using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour
{
   [HideInInspector] public string blockname;
    string ballname;

    private void Start()
    {
        blockname = GetComponent<ballcolorname>().ballColor;
    }

	/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball" )
        {
            ballname = collision.gameObject.GetComponent<Ball>().ballColorName;
            if(ballname == blockname)
            {
                collision.gameObject.GetComponent<Ball>().NewBall();
                Destroy(this.gameObject);
            }
            if (ballname != blockname) {
                collision.gameObject.GetComponent<Ball>().NewBall();
                

            }
            
        }
    }
    */
}
