using UnityEngine;
using System.Collections;
using admob;

public class advertisementManager : MonoBehaviour
{

    public static advertisementManager instance { set; get; }

    public string bannerId;
    public string videoId;

    void Start()
    {
      //  showBanner();// To call from other advertismantManager.Instance.ShowBanner();
        //showVideo();
        instance = this;
        DontDestroyOnLoad(gameObject);


#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(bannerId, videoId);
        
        //Admob.Instance().setTesting(true);
        Admob.Instance().loadInterstitial();
#endif
    }

    public void showBanner()
    {

#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 3);
#endif
    }

    public void showVideo()
    {

#if UNITY_EDITOR
#elif UNITY_ANDROID
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        GameObject.Find ("GameObject").GetComponent<vel> ().EnableOneMoreChance ();
        }
           else
        {
            Admob.Instance().loadInterstitial();
            Admob.Instance().showInterstitial();
        GameObject.Find ("GameObject").GetComponent<vel> ().EnableOneMoreChance ();
        }
#endif
    }
}
