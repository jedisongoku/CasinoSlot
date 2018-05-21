using UnityEngine;
using System.Collections;

public class Android_Payment_Manager : MonoBehaviour { 

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
	public const string coin_package_one = 				"com_slotsgame_coin_package_1";
	public const string coin_package_two = 				"com_slotsgame_coin_package_2";
	public const string coin_package_three = 			"com_slotsgame_coin_package_3";
	public const string coin_package_four = 			"com_slotsgame_coin_package_4";
	public const string coin_package_five = 			"com_slotsgame_coin_package_5";
	public const string coin_package_six = 				"com_slotsgame_coin_package_6";

	public const string coin_package_offer_one = 		"com_slotsgame_coin_package_offfer1";
	public const string coin_package_offer_two = 		"com_slotsgame_coin_package_offfer2";
	public const string coin_package_offer_three = 		"com_slotsgame_coin_package_offfer3";

	private static bool _isInited = false;
	private static bool ListnersAdded = false;

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
		if(ListnersAdded) {
			return;
		}
		
		//Filling product list
		//You can skip this if you alredy did this in Editor settings menu
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_one);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_two);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_three);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_four);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_five);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_six);

		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_offer_one);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_offer_two);
		AndroidInAppPurchaseManager.instance.AddProduct(coin_package_offer_three);
		
		
		//listening for purchase and consume events

		AndroidInAppPurchaseManager.ActionProductPurchased += OnProductPurchased;
		AndroidInAppPurchaseManager.ActionProductConsumed += OnProductConsumed;
		AndroidInAppPurchaseManager.ActionBillingSetupFinished += OnBillingConnected;
		
		//you may use loadStore function without parametr if you have filled base64EncodedPublicKey in plugin settings
		AndroidInAppPurchaseManager.Instance.LoadStore();
		
		ListnersAdded = true;
	}

	public static void purchase(string SKU) 
	{
		AndroidInAppPurchaseManager.Instance.Purchase (SKU);
	}

	public static void consume(string SKU) 
	{
		AndroidInAppPurchaseManager.Instance.Consume (SKU);
	}

	public static bool isInited 
	{
		get 
		{
			return _isInited;
		}
	}

	private static void OnProcessingPurchasedProduct(GooglePurchaseTemplate purchase) 
	{
		//AndroidMessage.Create("OnProcessingPurchasedProduct", "This purchase funcition was called");
		//some stuff for processing consumable product purchse. Add coins, unlock track, etc
		
		switch(purchase.SKU) 
		{
		case coin_package_one:
			Coin_package_one_purchased();
			consume(coin_package_one);
			break;
		case coin_package_two:
			Coin_package_two_purchased();
			consume(coin_package_two);
			break;
		case coin_package_three:
			Coin_package_four_purchased();
			consume(coin_package_three);
			break;
		case coin_package_four:
			Coin_package_four_purchased();
			consume(coin_package_four);
			break;
		case coin_package_five:
			Coin_package_five_purchased();
			consume(coin_package_five);
			break;
		case coin_package_six:
			Coin_package_six_purchased();
			consume(coin_package_six);
			break;
		case coin_package_offer_one:
			Coin_package_offerOne_purchased();
			consume(coin_package_offer_one);
			break;
		case coin_package_offer_two:
			Coin_package_offerTwo_purchased();
			consume(coin_package_offer_two);
			break;
		case coin_package_offer_three:
			Coin_package_offerThree_purchased();
			consume(coin_package_offer_three);
			break;
		}

		if(SuccessfullPurchase != null)
		{
			SuccessfullPurchase();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO SuccessfullPurchase DELEGATE");
	}

	private static void OnProcessingConsumeProduct(GooglePurchaseTemplate purchase) 
	{
		//AndroidMessage.Create("OnProcessingConsumeProduct", "This purchase funcition was called");

		switch(purchase.SKU) 
		{
			case coin_package_one:
				PlayerPrefs.SetString ("android_package_1", "consumed");
				break;
			case coin_package_two:
				PlayerPrefs.SetString ("android_package_2", "consumed");;
				break;
			case coin_package_three:
				PlayerPrefs.SetString ("android_package_3", "consumed");;
				break;
			case coin_package_four:
				PlayerPrefs.SetString ("android_package_4", "consumed");;
				break;
			case coin_package_five:
				PlayerPrefs.SetString ("android_package_5", "consumed");;
				break;
			case coin_package_six:
				PlayerPrefs.SetString ("android_package_6", "consumed");;
				break;
			case coin_package_offer_one:
				PlayerPrefs.SetString ("android_package_7", "consumed");;
				break;
			case coin_package_offer_two:
				PlayerPrefs.SetString ("android_package_8", "consumed");;
				break;
			case coin_package_offer_three:
				PlayerPrefs.SetString ("android_package_9", "consumed");;
				break;
		}
		
		if(SuccessfullPurchase != null)
		{
			SuccessfullPurchase();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO SuccessfullPurchase DELEGATE");
	}

	private static void OnProductPurchased(BillingResult result)
	{
		//this flag will tell you if purchase is available
		//result.isSuccess
		
		
		//infomation about purchase stored here
		//result.purchase
		
		//here is how for example you can get product SKU
		//result.purchase.SKU
		
		
		if(result.isSuccess) 
		{
			OnProcessingPurchasedProduct (result.purchase);
		} 
		else 
		{
			if(FailedPurchase != null)
			{
				FailedPurchase();
			}
			else Debug.LogWarning("NOTHING IS SUBSCRIBED TO FailedPurchase DELEGATE");

			AndroidMessage.Create("Product Purchase Failed", result.response.ToString() + " " + result.message);
		}
		Debug.Log ("Purchased Responce: " + result.response.ToString() + " " + result.message);
	}

	private static void OnProductConsumed(BillingResult result)
	{
		if(result.isSuccess) 
		{
			OnProcessingConsumeProduct (result.purchase);
		} 
		else 
		{
			AndroidMessage.Create("Product Consume Failed", result.response.ToString() + " " + result.message);
		}
		Debug.Log ("Cousume Responce: " + result.response.ToString() + " " + result.message);
	}

	private static void OnBillingConnected(BillingResult result)
	{
		AndroidInAppPurchaseManager.ActionBillingSetupFinished -= OnBillingConnected;

		if(result.isSuccess) 
		{
			//Store connection is Successful. Next we loading product and customer purchasing details

			if(StoreIsLoaded != null)
			{
				StoreIsLoaded();
			}
			else Debug.LogWarning("NOTHING IS SUBSCRIBED TO StoreIsLoaded DELEGATE");

			AndroidInAppPurchaseManager.ActionRetrieveProducsFinished += OnRetrieveProductsFinised;
			AndroidInAppPurchaseManager.Instance.RetrieveProducDetails();
		} 
		
		//AndroidMessage.Create("Connection Responce", result.response.ToString() + " " + result.message);
		Debug.Log ("Connection Responce: " + result.response.ToString() + " " + result.message);
	}

	private static void OnRetrieveProductsFinised(BillingResult result)
	{
		AndroidInAppPurchaseManager.ActionRetrieveProducsFinished -= OnRetrieveProductsFinised;

		if(result.isSuccess) 
		{
			UpdateStoreData();
			_isInited = true;
		} 
		else 
		{
			//AndroidMessage.Create("Connection Responce", result.response.ToString() + " " + result.message);
		}
		
	}

	private static void UpdateStoreData() 
	{
		foreach(GoogleProductTemplate p in AndroidInAppPurchaseManager.instance.inventory.products) {
			Debug.Log("Loaded product: " + p.title);
		}
		
		//chisking if we already own some consuamble product but forget to consume those
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_one) && PlayerPrefs.GetString ("android_package_1", "null") != "paid") {
			Coin_package_one_purchased();
			consume(coin_package_one);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_two) && PlayerPrefs.GetString ("android_package_2", "null") != "paid") {
			Coin_package_two_purchased();
			consume(coin_package_two);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_three) && PlayerPrefs.GetString ("android_package_3", "null") != "paid") {
			Coin_package_three_purchased();
			consume(coin_package_three);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_four) && PlayerPrefs.GetString ("android_package_4", "null") != "paid") {
			Coin_package_four_purchased();
			consume(coin_package_four);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_five) && PlayerPrefs.GetString ("android_package_5", "null") != "paid") {
			Coin_package_five_purchased();
			consume(coin_package_five);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_six) && PlayerPrefs.GetString ("android_package_6", "null") != "paid") {
			Coin_package_six_purchased();
			consume(coin_package_six);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_offer_one) && PlayerPrefs.GetString ("android_package_7", "null") != "paid") {
			Coin_package_offerOne_purchased();
			consume(coin_package_offer_one);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_offer_two) && PlayerPrefs.GetString ("android_package_8", "null") != "paid") {
			Coin_package_offerTwo_purchased();
			consume(coin_package_offer_two);
		}
		if(AndroidInAppPurchaseManager.instance.Inventory.IsProductPurchased(coin_package_offer_three) && PlayerPrefs.GetString ("android_package_9", "null") != "paid") {
			Coin_package_offerThree_purchased();
			consume(coin_package_offer_three);
		}
		
		//Check if non-consumable rpduct was purchased, but we do not have local data for it.
		//It can heppens if game was reinstalled or download on oher device
		//This is replacment for restore purchase fnunctionality on IOS

		//		if(AndroidInAppPurchaseManager.instance.inventory.IsProductPurchased(COINS_BOOST)) {
		//			GameDataExample.EnableCoinsBoost();
		//		}
		
		
	}

	public static void Coin_package_one_purchased()
	{
		myReels.CreditBought(purchase_1);
		PlayerPrefs.SetString ("android_package_1", "paid");
	}

	private static void Coin_package_two_purchased()
	{
		myReels.CreditBought(purchase_2);
		PlayerPrefs.SetString ("android_package_2", "paid");
	}

	private static void Coin_package_three_purchased()
	{
		myReels.CreditBought(purchase_3);
		PlayerPrefs.SetString ("android_package_3", "paid");
	}

	private static void Coin_package_four_purchased()
	{
		myReels.CreditBought(purchase_4);
		PlayerPrefs.SetString ("android_package_4", "paid");
	}

	private static void Coin_package_five_purchased()
	{
		myReels.CreditBought(purchase_5);
		PlayerPrefs.SetString ("android_package_5", "paid");
	}

	private static void Coin_package_six_purchased()
	{
		myReels.CreditBought(purchase_6);
		PlayerPrefs.SetString ("android_package_6", "paid");
	}

	private static void Coin_package_offerOne_purchased()
	{
		myReels.CreditBought(purchase_7_offer_1);
		PlayerPrefs.SetString ("android_package_7", "paid");
	}

	private static void Coin_package_offerTwo_purchased()
	{
		myReels.CreditBought(purchase_8_offer_2);
		PlayerPrefs.SetString ("android_package_8", "paid");
	}

	private static void Coin_package_offerThree_purchased()
	{
		myReels.CreditBought(purchase_9_offer_3);
		PlayerPrefs.SetString ("android_package_9", "paid");
	}
}
