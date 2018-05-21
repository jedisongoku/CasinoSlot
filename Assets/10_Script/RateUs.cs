using UnityEngine;
using System.Collections;

public class RateUs : MonoBehaviour {

	//public string title;
	//public string text;

	//private int count;
	//private int showing_no;
	//private string review_coins = "not reviewed";
	//private string reward_panel = "not active";

	#region ENABLE/DISABLE

	void OnEnable()
	{
		RateUs_InputListener.RateUs_ButtonPressed += RateMeOnAppStore;
	}

	void OnDisable()
	{
		RateUs_InputListener.RateUs_ButtonPressed -= RateMeOnAppStore;
	}

	#endregion

//	void Start()
//	{
//		review_coins = PlayerPrefs.GetString("Review",review_coins);
//		reward_panel = PlayerPrefs.GetString("reward panel",reward_panel);
//
//		if(reward_panel == "not active" || review_coins == "not reviewed")
//		{
//			Debug.Log("player didnt write review yet");
//		}
//		else if (reward_panel == "was activate" || review_coins == "not reviewed")
//		{
//			ActivateRewardPanel();
//		}
//		else if (reward_panel == "was activate" || review_coins == "is reviewed")
//		{
//			Debug.Log("player was awarded already");
//		}
//	}

	public void RateMeOnAppStore()
	{
		IOSNativeUtility.RedirectToAppStoreRatingPage();;
	}

//	public void RateUsPopUp()
//	{
//		showing_no = PlayerPrefs.GetInt ("rate_showing_count", 0);
//		showing_no++;
//		Debug.Log("showing no is" + showing_no);
//
//		if(showing_no == 3 || showing_no == 6|| showing_no == 9 || showing_no == 12 || showing_no == 15 || showing_no == 18 || showing_no == 21 || showing_no == 24)
//		{
//			count = PlayerPrefs.GetInt("rate_pop_up_count", 0);
//			count++;
//
//			if(count <= 5)
//			{
//				IOSRateUsPopUp rate = IOSRateUsPopUp.Create(title, text);
//			
//				rate.addEventListener(BaseEvent.COMPLETE, onRatePopUpClose);
//			}
//			PlayerPrefs.SetInt ("rate_pop_up_count", count);
//		}
//		PlayerPrefs.SetInt ("rate_showing_count", showing_no);
//	}

//	private void dismissAler() {
//		IOSNative.dismissCurrentAlert ();
//	}
	
//	private void onRatePopUpClose(CEvent e) 
//	{
//		(e.dispatcher as IOSRateUsPopUp).removeEventListener(BaseEvent.COMPLETE, onRatePopUpClose);
//		string result = e.data.ToString();
//		//IOSNative.showMessage("Result", result + " button pressed");
//		switch((IOSDialogResult)e.data) {
//		case IOSDialogResult.RATED:
//			//Debug.Log ("Yes button pressed");
//			//IOSNative.showMessage("RateUs Result", "Yes button pressed");
//			ActivateRewardPanel();
//			GA.API.Design.NewEvent("RateUs:Yes");
//			break;
//		case IOSDialogResult.REMIND:
//			//Debug.Log ("Remind button pressed");
//			//IOSNative.showMessage("RateUs Result", "Remind later button pressed");
//			GA.API.Design.NewEvent("RateUs:Later");
//			break;
//		case IOSDialogResult.DECLINED:
//			//Debug.Log ("No button pressed");
//			//IOSNative.showMessage("RateUs Result", "No button pressed");
//			GA.API.Design.NewEvent("RateUs:No");
//			break;
//		}
//	}

//	private void onDialogClose(CEvent e) {
//		
//		//romoving listner
//		(e.dispatcher as IOSDialog).removeEventListener(BaseEvent.COMPLETE, onDialogClose);
//		
//		//parsing result
//		switch((IOSDialogResult)e.data) {
//		case IOSDialogResult.YES:
//			Debug.Log ("Yes button pressed");
//			IOSNative.showMessage("Result", "Yes button pressed");
//			break;
//		case IOSDialogResult.NO:
//			Debug.Log ("Yes button pressed");
//			IOSNative.showMessage("Result", "No button pressed");
//			break;
//			
//		}
//		
//		string result = e.data.ToString();
//		IOSNative.showMessage("Result", result + " button pressed");
//	}
	
//	private void onMessageClose(CEvent e) {
//		(e.dispatcher as IOSMessage).removeEventListener(BaseEvent.COMPLETE,  onMessageClose);
//		IOSNative.showMessage("Result", "Message Closed");
//	}
}