using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InvestablePopUpController : MonoBehaviour 
{

	public static InvestablePopUpController investableController;
	[SerializeField] private Image popUpButtonSmall;
	[SerializeField] private Image popUpButtonExpanded;
	[SerializeField] private Image popUpDialog;
	[SerializeField] private Image inAppPopUpDialog;
	[SerializeField] private List<Text> balanceDisplay = new List<Text>();
	[SerializeField] private Text coinAmountText;
	[SerializeField] private Text purchaseAmountText;
	private bool isExpanded = false;


	void Awake()
	{
        DontDestroyOnLoad(transform.root.gameObject);
		investableController = this;
    }

	void Start () 
	{
		popUpButtonSmall.gameObject.SetActive(true);
		popUpButtonExpanded.gameObject.SetActive (false);
		popUpDialog.gameObject.SetActive (false);
		zTEMP_spoofBalanceAmount();
	}


	public void ButtonPressed_InvestablePopUpSmall () 
	{
		print("Investable Pop Up Button Pressed");
		popUpButtonSmall.gameObject.SetActive(false);
		popUpButtonExpanded.gameObject.SetActive(true);
		isExpanded = true;

	}


	public void ButtonPressed_InvestablePopUpExpanded () 
	{
		print("Investable Pop Up Expanded Button Pressed");
		popUpButtonSmall.gameObject.SetActive(false);
		popUpButtonExpanded.gameObject.SetActive(false);
		popUpDialog.gameObject.SetActive(true);
		isExpanded = false;
	}

	public void ButtonPressed_InvestableInAppPurchasePopUp (string coinAmount, string purchaseAmount) 
	{
		print("Investable Pop Up In-App Purchase Button Pressed");
		coinAmountText.text = "(" + coinAmount + " coins)";
		purchaseAmountText.text = purchaseAmount;
		inAppPopUpDialog.gameObject.SetActive(true);
	}

	public void ButtonPressed_PopUpInAppPurchaseModalClose ()
	{
		inAppPopUpDialog.gameObject.SetActive(false);
	}

	public void ButtonPressed_InvestableCashActivate ()
	{
		popUpButtonSmall.gameObject.SetActive (true);
	}

	public void ButtonPressed_PopUpModalClose ()
	{
		popUpButtonSmall.gameObject.SetActive(true);
		popUpButtonExpanded.gameObject.SetActive (false);
		popUpDialog.gameObject.SetActive (false);
	}



	public void ButtonPressed_PopUpModalInvest ()
	{
		Debug.Log (" 'Invest Now' Button Pressed");
	}

	public void ButtonPressed_PopUpModalViewBalance ()
	{
		Debug.Log (" 'View Balance' Button Pressed");
	}


	private void zTEMP_spoofBalanceAmount()
	{
		string newDisplayText = "$" + Random.Range(10, 19) + ".0" + Random.Range(0, 9);

		foreach(Text displayText in balanceDisplay)
		{
			displayText.text = newDisplayText;
		}
	}

    public void ToggleInvestableCash()
    {
		popUpButtonSmall.gameObject.SetActive(!transform.gameObject.activeInHierarchy);
    }
}
