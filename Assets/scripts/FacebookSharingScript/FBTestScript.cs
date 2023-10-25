using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;
using UnityEngine.UI;

public class FBTestScript : MonoBehaviour
{

    //public Text Sucess;
    //public Text error;

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    public void FBshare()
    {

        FB.ShareLink(
        new Uri("https://developers.facebook.com/"),
        callback: ShareCallback
    );
    }
    //public void Invite()
    //{
    //    FB.Mobile.AppInvite(new System.Uri("https://play.google.com/store/apps/details?id=com.Tapturn.srothcode&hl=en")
    //    //,callback: ShareCallback

    //    );
    //}



    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
            //error.text = "Error" + result.Error;
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
			GameObject.Find ("GameObject").GetComponent<vel> ().EnableOneMoreChance ();
            GameObject.Find("SceneManager").GetComponent<GameManager>().OneMoreChancePannel.SetActive(false);
            //Sucess.text = "Sucess";
        }
    }
    public void inviteFrends()
    {
        List<string> recipient = null;
        string title, message, data = string.Empty;

        title = "Play Friend Smash with me!";
        message = "Friend Smash is smashing! Check it out.";
       
        FB.AppRequest(
           message,
           recipient,
           null,
           null,
           null,
           data,
           title,
           AppRequestCallback
           );
    }
    private void AppRequestCallback(IAppRequestResult result)
    {
        // Error checking
        Debug.Log("AppRequestCallback");
        if (result.Error != null)
        {
            Debug.LogError(result.Error);
            return;
            //error.text = "Error" + result.Error;
        }
        Debug.Log(result.RawResult);

        // Check response for success - show user a success popup if so
        object obj;
        if (result.ResultDictionary.TryGetValue("cancelled", out obj))
        {
            Debug.Log("Request cancelled");
        }
        else if (result.ResultDictionary.TryGetValue("request", out obj))
        {
            // PopupScript.SetPopup("Request Sent", 3f);
            Debug.Log("Request sent");
			GameObject.Find ("GameObject").GetComponent<vel> ().EnableOneMoreChance ();
            GameObject.Find("SceneManager").GetComponent<GameManager>().OneMoreChancePannel.SetActive(false);
           // Sucess.text = "Sucess";
        }
    }
}
