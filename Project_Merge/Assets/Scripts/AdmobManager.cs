using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
public class AdmobManager : MonoBehaviour
{
    public bool isTestMode;
    //public Text LogText;
    //public Button FrontAdsBtn, RewardAdsBtn;
    // Start is called before the first frame update
    void Start()
    {
        LoadBannerAd();
        //LoadRewardAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice("331247D1AFD5E740").Build();
    }
    #region 배너광고
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-4925895011467232/8017914646";
    BannerView bannerAd;
    void LoadBannerAd()
    {
        bannerAd = new BannerView(isTestMode ? bannerTestID : bannerID, AdSize.Banner, AdPosition.Top);
        bannerAd.LoadAd(GetAdRequest());
        ToggleBannerAd(true);
    }
    public void ToggleBannerAd(bool b)
    {
        if (b) bannerAd.Show();
        else bannerAd.Hide();
    }
    #endregion
}