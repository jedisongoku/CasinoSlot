using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class iOS_IAP_Payment_Manager : MonoBehaviour
{
	//write below how many coins do you wish your player will have after succesfull purchase
	public const int purchase_1 = 1500;					
	public const int purchase_2 = 3000;
	public const int purchase_3 = 10000;
	public const int purchase_4 = 25000;
	public const int purchase_5 = 75000;
	public const int purchase_6 = 300000;
	
	public const int purchase_7_offer_1 = 10000;
	public const int purchase_8_offer_2 = 35000;
	public const int purchase_9_offer_3 = 250000;
	
	//write below your own in app purchase id. Each purchase has its own so make sure you have it corectly
	public const string coin_package_one = 			"coin_package_1_slots11";
	public const string coin_package_two =			"coin_package_2";
	public const string coin_package_three = 		"coin_package_3";
	public const string coin_package_four = 		"coin_package_4";
	public const string coin_package_five = 		"coin_package_5";
	public const string coin_package_six = 			"coin_package_6";
	
	public const string coin_package_offer_one = 	"coin_package_offer1";
	public const string coin_package_offer_two = 	"coin_package_offer2";
	public const string coin_package_offer_three = 	"coin_package_offer3";
	
	private static bool IsInitialized = false;
	
	public static Slot_Machine_System myReels;
	
	public delegate void PurchaseSuccessfull();
	public static event PurchaseSuccessfull SuccessfullPurchase;
	
	public delegate void PurchaseFail();
	public static event PurchaseFail FailedPurchase;
	
	public delegate void StoreLoaded();
	public static event StoreLoaded StoreIsLoaded; 
	
	void Start()
	{
		GameObject myReelsObj = GameObject.Find ("AllReels");
		myReels = myReelsObj.GetComponent<Slot_Machine_System>();
		Debug.Log (myReelsObj + "this is my reels object");
		Debug.Log (myReels + "this is my reels script component");
	}
	
	public static void init() 
	{
		if(!IsInitialized) {
			
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_one);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_two);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_three);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_four);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_five);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_six);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_offer_one);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_offer_two);
			IOSInAppPurchaseManager.Instance.AddProductId(coin_package_offer_three);
			
			//Event Use Examples
			IOSInAppPurchaseManager.OnVerificationComplete += HandleOnVerificationComplete;
			IOSInAppPurchaseManager.OnStoreKitInitComplete += OnStoreKitInitComplete;
			
			IOSInAppPurchaseManager.OnTransactionComplete += OnTransactionComplete;
			IOSInAppPurchaseManager.OnRestoreComplete += OnRestoreComplete;
			
			IsInitialized = true;
			
		} 
		
		IOSInAppPurchaseManager.Instance.LoadStore();
	}
	
	public static void buyItem(string productId) 
	{
		IOSInAppPurchaseManager.Instance.BuyProduct(productId);
	}
	
	private static void UnlockProducts(string productIdentifier) 
	{
		switch(productIdentifier) {
		case coin_package_one:
			Coin_package_one_purchased();
			break;
		case coin_package_two:
			Coin_package_two_purchased();
			break;
		case coin_package_three:
			Coin_package_three_purchased();
			break;
		case coin_package_four:
			Coin_package_four_purchased();
			break;
		case coin_package_five:
			Coin_package_five_purchased();
			break;
		case coin_package_six:
			Coin_package_six_purchased();
			break;
		case coin_package_offer_one:
			Coin_package_offerOne_purchased();
			break;
		case coin_package_offer_two:
			Coin_package_offerTwo_purchased();
			break;
		case coin_package_offer_three:
			Coin_package_offerThree_purchased();
			break;
		}
		
		if(SuccessfullPurchase != null)
		{
			SuccessfullPurchase();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO SuccessfullPurchase DELEGATE");
	}
	
	private static void OnTransactionComplete (IOSStoreKitResult result) 
	{
		Debug.Log("OnTransactionComplete: " + result.ProductIdentifier);
		Debug.Log("OnTransactionComplete: state: " + result.State);
		
		switch(result.State) 
		{
		case InAppPurchaseState.Purchased:
			
			IOSNativePopUpManager.showMessage("Transaction Responce", " InAppPurchaseState is PURCHASED");
			
			UnlockProducts(result.ProductIdentifier);
			break;
		case InAppPurchaseState.Restored:
			
			IOSNativePopUpManager.showMessage("Transaction Responce", " InAppPurchaseState is RESTORED");
			
			//Our product been succsesly purchased or restored
			//So we need to provide content to our user depends on productIdentifier
			UnlockProducts(result.ProductIdentifier);
			break;
		case InAppPurchaseState.Deferred:
			
			IOSNativePopUpManager.showMessage("Transaction Responce", " InAppPurchaseState is DEFERRED");
			
			if(FailedPurchase != null)
			{
				FailedPurchase();
			}
			else Debug.LogWarning("NOTHING IS SUBSCRIBED TO FailedPurchase DELEGATE");
			
			//iOS 8 introduces Ask to Buy, which lets parents approve any purchases initiated by children
			//You should update your UI to reflect this deferred state, and expect another Transaction Complete  to be called again with a new transaction state 
			//reflecting the parent’s decision or after the transaction times out. Avoid blocking your UI or gameplay while waiting for the transaction to be updated.
			break;
		case InAppPurchaseState.Failed:
			//Our purchase flow is failed.
			//We can unlock intrefase and repor user that the purchase is failed. 
			Debug.Log("Transaction failed with error, code: " + result.Error.Code);
			Debug.Log("Transaction failed with error, description: " + result.Error.Description);
			
			IOSNativePopUpManager.showMessage("Transaction Responce", " InAppPurchaseState is FAILED");
			
			if(FailedPurchase != null)
			{
				FailedPurchase();
			}
			else Debug.LogWarning("NOTHING IS SUBSCRIBED TO FailedPurchase DELEGATE");
			
			
			break;
		}
		
		if(result.State == InAppPurchaseState.Failed) {
			IOSNativePopUpManager.showMessage("Transaction Failed", "Error code: " + result.Error.Code + "\n" + "Error description:" + result.Error.Description);
		} else {
			IOSNativePopUpManager.showMessage("Store Kit Response", "product " + result.ProductIdentifier + " state: " + result.State.ToString());
		}
		
	}
	
	private static void OnRestoreComplete (IOSStoreKitRestoreResult res) {
		if(res.IsSucceeded) {
			IOSNativePopUpManager.showMessage("Success", "Restore Compleated");
		} else {
			IOSNativePopUpManager.showMessage("Error: ", "Restore Failed");
		}
	}
	
	static void HandleOnVerificationComplete (IOSStoreKitVerificationResponse response) 
	{
		IOSNativePopUpManager.showMessage("Verification", "Transaction verification status: " + response.status.ToString());

		Debug.Log("ORIGINAL JSON: " + response.originalJSON);
	}
	
	private static void OnStoreKitInitComplete(ISN_Result result) 
	{
		if(result.IsSucceeded) 
		{
			IOSNativePopUpManager.showMessage("StoreKit Init Succeeded", "Available products count: " + IOSInAppPurchaseManager.instance.products.Count.ToString());
			
			if(StoreIsLoaded != null)
			{
				StoreIsLoaded();
			}
			else Debug.LogWarning("NOTHING IS SUBSCRIBED TO StoreIsLoaded DELEGATE");
			
		} 
		else 
		{
			IOSNativePopUpManager.showMessage("StoreKit Init Failed",  "Error code: " + result.Error.Code + "\n" + "Error description:" + result.Error.Description);
		}
	}
	
	public static void Coin_package_one_purchased()
	{
		myReels.CreditBought(purchase_1);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Handful of Coins is yours now!");
	}
	
	private static void Coin_package_two_purchased()
	{
		myReels.CreditBought(purchase_2);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Double Fist of Coins is yours now!");
	}
	
	private static void Coin_package_three_purchased()
	{
		myReels.CreditBought(purchase_3);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Back Pack of Coins is yours now!");
	}
	
	private static void Coin_package_four_purchased()
	{
		myReels.CreditBought(purchase_4);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Vegas Briefcase is yours now!");
	}
	
	private static void Coin_package_five_purchased()
	{
		myReels.CreditBought(purchase_5);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Casino Mastery Gear is yours now!");
	}
	
	private static void Coin_package_six_purchased()
	{
		myReels.CreditBought(purchase_6);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Oceans Casino Crew is ready now!");
	}
	
	private static void Coin_package_offerOne_purchased()
	{
		myReels.CreditBought(purchase_7_offer_1);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Oceans Casino Crew is ready now!");
	}
	
	private static void Coin_package_offerTwo_purchased()
	{
		myReels.CreditBought(purchase_8_offer_2);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Oceans Casino Crew is ready now!");
	}
	
	private static void Coin_package_offerThree_purchased()
	{
		myReels.CreditBought(purchase_9_offer_3);
		//IOSNativePopUpManager.showMessage("Succesfull purchase", "Oceans Casino Crew is ready now!");
	}
	
}

