using UnityEngine;
using System.Collections;

public class iAD : MonoBehaviour {

	public bool iADuse;

	private iAdBanner banner1;
	
	private bool IsInterstisialsAdReady = false;

	void OnEnable()
	{
		//Slot_Machine_System.ShowIAD += ShowInterstitialAd;
	}

	void OnDisable()
	{
		//Slot_Machine_System.ShowIAD -= ShowInterstitialAd;
	}

	void Start() 
	{
		
		//using events example
		iAdBannerController.InterstitialAdDidLoadAction += HandleInterstitialAdDidLoadAction;
		iAdBannerController.InterstitialAdDidFinishAction += HandleInterstitialAdDidFinishAction;


		if(iADuse)
		{
			LoadInterstitialAd ();
		}
	}

	public void StartInterstitialAd()
	{
		if (iADuse) 
		{
			iAdBannerController.instance.StartInterstitialAd ();
		}
	}

	public void LoadInterstitialAd()
	{
		iAdBannerController.instance.LoadInterstitialAd ();
	}

	public void ShowInterstitialAd()
	{
		if(iADuse)
		{
			if (IsInterstisialsAdReady) 
			{
				iAdBannerController.instance.ShowInterstitialAd ();
			}

			LoadInterstitialAd ();
		}
	}
	
	public void CreateTopCenterBanner()
	{
		Debug.Log ("TOP CENTER BANNER IS ABOUT TO BE CREATED AND VISIBLE ON SCREEN");
		banner1 = iAdBannerController.instance.CreateAdBanner(TextAnchor.UpperCenter);
		Debug.Log ("TOP CENTER BANNER WAS CREATED AND SHOULD BE VISIBLE ON SCREEN");
	}

	public void CreateBottomCenterBanner()
	{
		banner1 = iAdBannerController.instance.CreateAdBanner(TextAnchor.LowerCenter);
	}
		
	public void ShowBanner()
	{
		banner1.Show();
	}

	public void HideBanner()
	{
		banner1.Hide();
	}

	public void DestroyBanner()
	{
		iAdBannerController.instance.DestroyBanner(banner1.id);
	}

	void HandleInterstitialAdDidFinishAction () 
	{
		IsInterstisialsAdReady = false;

		Debug.Log("OnInterstitialFinish action fired");
		//IOSMessage.Create("Ad Event", "Ad Did Finish");
	}

	void HandleInterstitialAdDidLoadAction ()
	{
		IsInterstisialsAdReady = true;
		Debug.Log("HandleInterstitialAdDidLoadAction event fired");
	}
}
