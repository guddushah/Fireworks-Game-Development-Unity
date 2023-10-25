using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public bool pause;
    public Transform PausePannel;
    public GameObject OneMoreChancePannel;
    public GameObject anotherCanvas;
	float timer = 0;
	bool startTimer = false;
	bool test = true;

    //public GameObject btnChance;
    //public GameObject btnDetath;
    //public GameObject texting;


    
    // Use this for initialization
    void Start () {
        pause = false;

    }

    // Update is called once per frame
    void Update () {

		if (startTimer) {
			timer += 1;
			Debug.Log (timer);
			if (timer > 20) {
				GameObject.Find ("ball (1)").GetComponent<ball> ().canInteract = true;
				Time.timeScale = 1;
				startTimer = false;
			}

		}
	}

    public void PauseButton()
    {
        pause = !pause;

        if (!pause)
        {
            PausePannel.gameObject.SetActive(false);
            //btnChance.SetActive(true);
            //btnDetath.SetActive(true);
            //texting.SetActive(true);
            //Time.timeScale = 1;
			if (test) {
				timer = 0;
				startTimer = true;
				test = false;
			}

            anotherCanvas.SetActive(true);
        }
        else if (pause)
        {
            PausePannel.gameObject.SetActive(true);

            //btnChance.SetActive(false);
            //btnDetath.SetActive(false);
            //texting.SetActive(false);
			//timer = 0;
			//startTimer = false;
			GameObject.Find ("ball (1)").GetComponent<ball> ().canInteract = false;
			if(!test){
				test = true;
			}
            Time.timeScale = 0;
            anotherCanvas.SetActive(false);
        }


    }

    public void oneMoreChance()
    {
        StartCoroutine("OneMoreChance");
    }
    IEnumerator OneMoreChance()
    {
        yield return new WaitForSeconds(0.0001f);
        //Time.timeScale = 0.5f;
        OneMoreChancePannel.SetActive(true);
        //btnChance.SetActive(false);
        //btnDetath.SetActive(false);
        //texting.SetActive(false);

    }

    public void DeathButton()
    {
        SceneManager.LoadScene("DeathScene");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("test3");
        Time.timeScale = 1;
    }
    public void replyButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void goHome()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void RateUS()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.srothcode.DashainAayo");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
