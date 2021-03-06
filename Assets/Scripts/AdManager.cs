using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class AdManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    private RewardedInterstitialAd rewardedInterstitialAd;
    private float deltaTime;

    public UnityEvent OnAdLoadedEvent;
    public UnityEvent OnAdFailedToLoadEvent;
    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdFailedToShowEvent;
    public UnityEvent OnUserEarnedRewardEvent;
    public UnityEvent OnAdClosedEvent;
    public UnityEvent OnAdLeavingApplicationEvent;
    public bool showFpsMeter = true;
    public Text fpsMeter;
    public Text statusText;

    #region UNITY MONOBEHAVIOR METHODS

    public void Start()
    {
        
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(HandleInitCompleteAction);
        
        MobileAds.SetiOSAppPauseOnBackground(true);

        List<String> deviceIds = new List<String>() { AdRequest.TestDeviceSimulator };

        // Add some test device IDs (replace with your own device IDs).
#if UNITY_IPHONE
        deviceIds.Add("");
#elif UNITY_ANDROID
        deviceIds.Add("");
#endif

        // Configure TagForChildDirectedTreatment and test device IDs.
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.Unspecified)
            .SetTestDeviceIds(deviceIds).build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        RequestBannerAd();
        RequestAndLoadInterstitialAd();
        RequestAndLoadRewardedAd();
        RequestAndLoadRewardedInterstitialAd();
    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        // Callbacks from GoogleMobileAds are not guaranteed to be called on
        // main thread.
        // In this example we use MobileAdsEventExecutor to schedule these calls on
        // the next Update() loop.
        MobileAdsEventExecutor.ExecuteInUpdate(() => {
            statusText.text = "Initialization complete";
            RequestBannerAd();
        });
    }

    private void Update()
    {
        
        
        
            
        
    }

    #endregion

    #region HELPER METHODS

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("unity-admob-sample")
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    #endregion

    #region BANNER ADS

    public void RequestBannerAd()
    {
        statusText.text = "Requesting Banner Ad.";
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4528189983462256/6413908456";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a smart banner at bottom of the screen
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Add Event Handlers
        bannerView.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        bannerView.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        bannerView.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        bannerView.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        bannerView.OnAdLeavingApplication += (sender, args) => OnAdLeavingApplicationEvent.Invoke();

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }

    #endregion

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
        statusText.text = "Requesting Interstitial Ad.";
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4528189983462256~9231643487";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(adUnitId);

        // Add Event Handlers
        interstitialAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        interstitialAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        interstitialAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        interstitialAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        interstitialAd.OnAdLeavingApplication += (sender, args) => OnAdLeavingApplicationEvent.Invoke();

        // Load an interstitial ad
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            statusText.text = "Interstitial ad is not ready yet";
        }
    }

    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }
    #endregion

    #region REWARDED ADS

    public void RequestAndLoadRewardedAd()
    {
        statusText.text = "Requesting Rewarded Ad.";
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-4528189983462256~9231643487";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "unexpected_platform";
#endif

        // create new rewarded ad instance
        rewardedAd = new RewardedAd(adUnitId);

        // Add Event Handlers
        rewardedAd.OnAdLoaded += (sender, args) => OnAdLoadedEvent.Invoke();
        rewardedAd.OnAdFailedToLoad += (sender, args) => OnAdFailedToLoadEvent.Invoke();
        rewardedAd.OnAdOpening += (sender, args) => OnAdOpeningEvent.Invoke();
        rewardedAd.OnAdFailedToShow += (sender, args) => OnAdFailedToShowEvent.Invoke();
        rewardedAd.OnAdClosed += (sender, args) => OnAdClosedEvent.Invoke();
        rewardedAd.OnUserEarnedReward += (sender, args) => OnUserEarnedRewardEvent.Invoke();

        // Create empty ad request
        rewardedAd.LoadAd(CreateAdRequest());
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Show();
        }
        else
        {
            statusText.text = "Rewarded ad is not ready yet.";
        }
    }

    public void RequestAndLoadRewardedInterstitialAd()
    {
        statusText.text = "Requesting Rewarded Interstitial Ad.";
        // These ad units are configured to always serve test ads.
    #if UNITY_EDITOR
        string adUnitId = "unused";
    #elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-4528189983462256/7948505499";
    #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/6978759866";
    #else
            string adUnitId = "unexpected_platform";
    #endif

        // Create an interstitial.
        RewardedInterstitialAd.LoadAd(adUnitId, CreateAdRequest(), (rewardedInterstitialAd, error) =>
        {

          if (error != null)
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
                statusText.text = "RewardedInterstitialAd load failed, error: " + error;
            });
            return;
          }

          this.rewardedInterstitialAd = rewardedInterstitialAd;
          MobileAdsEventExecutor.ExecuteInUpdate(() => {
              statusText.text = "RewardedInterstitialAd loaded";
          });
          // Register for ad events.
          this.rewardedInterstitialAd.OnAdDidPresentFullScreenContent += (sender, args) =>
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
                statusText.text = "Rewarded Interstitial presented.";
            });
          };
          this.rewardedInterstitialAd.OnAdDidDismissFullScreenContent += (sender, args) =>
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
              statusText.text = "Rewarded Interstitial dismissed.";
            });
            this.rewardedInterstitialAd = null;
          };
          this.rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += (sender, args) =>
          {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
                statusText.text = "Rewarded Interstitial failed to present.";
            });
            this.rewardedInterstitialAd = null;
          };
        });
    }

    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        {
            rewardedInterstitialAd.Show((reward) => {
              MobileAdsEventExecutor.ExecuteInUpdate(() => {
                  statusText.text = "User Rewarded: " + reward.Amount ;
              });
            });
            
            RequestAndLoadRewardedInterstitialAd();
        }
        else
        {
            statusText.text = "Rewarded ad is not ready yet.";
        }
    }

    #endregion

    //Makes sure that there is new ad ready on opening a ad
    public void ReloadRequestAds()
    {

        RequestBannerAd();
        RequestAndLoadInterstitialAd();
        RequestAndLoadRewardedAd();
        RequestAndLoadRewardedInterstitialAd();
    }
}