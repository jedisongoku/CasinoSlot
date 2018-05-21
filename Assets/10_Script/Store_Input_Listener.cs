using UnityEngine;
using System.Collections;

public class Store_Input_Listener : MonoBehaviour {

	public delegate void Purchase_One();
	public static event Purchase_One BuyItem_1;

	public delegate void Purchase_Two();
	public static event Purchase_Two BuyItem_2;

	public delegate void Purchase_Three();
	public static event Purchase_Three BuyItem_3;

	public delegate void Purchase_For();
	public static event Purchase_For BuyItem_4;

	public delegate void Purchase_Five();
	public static event Purchase_Five BuyItem_5;

	public delegate void Purchase_Six();
	public static event Purchase_Six BuyItem_6;

	public delegate void Purchase_Seven();
	public static event Purchase_Seven BuyItem_7;

	public delegate void Purchase_Eight();
	public static event Purchase_Eight BuyItem_8;

	public delegate void Purchase_Nine();
	public static event Purchase_Nine BuyItem_9;

	public void BuyProduct_1()
	{
		InvestablePopUpController.investableController.ButtonPressed_InvestableInAppPurchasePopUp ("1,500","$ 1.99");
		if(BuyItem_1 != null)
		{
			BuyItem_1();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_1 DELEGATE");
	}

	public void BuyProduct_2()
	{
		InvestablePopUpController.investableController.ButtonPressed_InvestableInAppPurchasePopUp ("3,000","$ 2.99");
		if(BuyItem_2 != null)
		{
			BuyItem_2();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_2 DELEGATE");
	}

	public void BuyProduct_3()
	{
		InvestablePopUpController.investableController.ButtonPressed_InvestableInAppPurchasePopUp ("10,000","$ 5.99");
		if(BuyItem_3 != null)
		{
			BuyItem_3();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_3 DELEGATE");
	}

	public void BuyProduct_4()
	{
		InvestablePopUpController.investableController.ButtonPressed_InvestableInAppPurchasePopUp ("25,000","$ 9.99");
		if(BuyItem_4 != null)
		{
			BuyItem_4();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_4 DELEGATE");
	}

	public void BuyProduct_5()
	{
		InvestablePopUpController.investableController.ButtonPressed_InvestableInAppPurchasePopUp ("75,000","$ 19.99");
		if(BuyItem_5 != null)
		{
			BuyItem_5();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_5 DELEGATE");
	}

	public void BuyProduct_6()
	{
		InvestablePopUpController.investableController.ButtonPressed_InvestableInAppPurchasePopUp ("300,000","$ 39.99");
		if(BuyItem_6 != null)
		{
			BuyItem_6();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_6 DELEGATE");
	}

	public void BuyProduct_7()
	{
		if(BuyItem_7 != null)
		{
			BuyItem_7();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_7 DELEGATE");
	}

	public void BuyProduct_8()
	{
		if(BuyItem_8 != null)
		{
			BuyItem_8();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_8 DELEGATE");
	}

	public void BuyProduct_9()
	{
		if(BuyItem_9 != null)
		{
			BuyItem_9();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO BuyItem_9 DELEGATE");
	}
}
