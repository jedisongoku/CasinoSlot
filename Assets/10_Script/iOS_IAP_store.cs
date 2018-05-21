using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class iOS_IAP_store : MonoBehaviour {
	
	public GameObject progressBar;
	private bool storeKitInited = false;
	
	#region Enable/Disable
	
	void OnEnable ()
	{
		if (!storeKitInited) 
		{
			iOS_IAP_Payment_Manager.init();
			storeKitInited = true;
		}
		
		iOS_IAP_Payment_Manager.FailedPurchase 			+= PurchaseFail;
		iOS_IAP_Payment_Manager.SuccessfullPurchase 	+= PurchaseSuccesful;
		iOS_IAP_Payment_Manager.StoreIsLoaded 			+= StoreLoaded;
		
		Store_Input_Listener.BuyItem_1 					+= Buy_coin_package_1;
		Store_Input_Listener.BuyItem_2 					+= Buy_coin_package_2;
		Store_Input_Listener.BuyItem_3 					+= Buy_coin_package_3;
		Store_Input_Listener.BuyItem_4 					+= Buy_coin_package_4;
		Store_Input_Listener.BuyItem_5 					+= Buy_coin_package_5;
		Store_Input_Listener.BuyItem_6 					+= Buy_coin_package_6;
		Store_Input_Listener.BuyItem_7 					+= Buy_coin_package_offer_1;
		Store_Input_Listener.BuyItem_8 					+= Buy_coin_package_offer_2;
		Store_Input_Listener.BuyItem_9 					+= Buy_coin_package_offer_3;
	}
	
	void OnDisable ()
	{
		iOS_IAP_Payment_Manager.FailedPurchase 			-= PurchaseFail;
		iOS_IAP_Payment_Manager.SuccessfullPurchase 	-= PurchaseSuccesful;
		iOS_IAP_Payment_Manager.StoreIsLoaded 			-= StoreLoaded;
		
		Store_Input_Listener.BuyItem_1 					-= Buy_coin_package_1;
		Store_Input_Listener.BuyItem_2 					-= Buy_coin_package_2;
		Store_Input_Listener.BuyItem_3 					-= Buy_coin_package_3;
		Store_Input_Listener.BuyItem_4 					-= Buy_coin_package_4;
		Store_Input_Listener.BuyItem_5 					-= Buy_coin_package_5;
		Store_Input_Listener.BuyItem_6 					-= Buy_coin_package_6;
		Store_Input_Listener.BuyItem_7 					-= Buy_coin_package_offer_1;
		Store_Input_Listener.BuyItem_8 					-= Buy_coin_package_offer_2;
		Store_Input_Listener.BuyItem_9 					-= Buy_coin_package_offer_3;
	}
	
	#endregion
	
	//	void Awake() 
	//	{
	//		iOS_IAP_Payment_Manager.init();
	//	}
	
	void Buy_coin_package_1()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_one);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_2()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_two);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_3()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_three);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_4()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_four);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_5()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_five);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_6()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_six);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_offer_1()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_offer_one);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_offer_2()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_offer_two);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	void Buy_coin_package_offer_3()
	{
		if(storeKitInited)
		{
			iOS_IAP_Payment_Manager.buyItem(iOS_IAP_Payment_Manager.coin_package_offer_three);
			DontAllowAnyOtherPurchase();
		}
		else
		{
			NoConnection();
		}
	}
	
	public void StoreLoaded()
	{
		Debug.Log ("store is loaded");
		storeKitInited = true;
	}
	
	public void PurchaseSuccesful()
	{
		Debug.Log ("purchase succesful");
		
		HideProgressBar();
	}
	
	public void PurchaseFail()
	{
		Debug.Log ("purchased fail");
		
		HideProgressBar();
	}
	
	void DontAllowAnyOtherPurchase()
	{
		ShowProgressBar();
	}
	
	void ShowProgressBar()
	{
		if(progressBar != null)
		{
			progressBar.SetActive(true);
		}
		else Debug.Log("ATTACH progressBar OBJECT");
	}
	
	void HideProgressBar()
	{
		if(progressBar != null)
		{
			progressBar.SetActive(false);
		}
		else Debug.Log("ATTACH progressBar OBJECT");
	}
	
	void NoConnection()
	{
		IOSNativePopUpManager.showMessage("Connection Fail", "Connect your device to the internet and try again");
		
		if(!storeKitInited)
		{
			iOS_IAP_Payment_Manager.init();
		}
	}
}
