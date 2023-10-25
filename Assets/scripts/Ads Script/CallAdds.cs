using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAdds : MonoBehaviour {

	// Use this for initialization
	void Start () {
        advertisementManager.instance.showBanner();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void VideoAdd()
    {
        advertisementManager.instance.showVideo();
		
        GameObject.Find("SceneManager").GetComponent<GameManager>().OneMoreChancePannel.SetActive(false);
    }
    public void ShowBanner()
    {
        
        //advertisementManager.instance.showBanner();
    }
}
