using UnityEngine;
using System.Collections;

public class RateUs_Android : MonoBehaviour {

	public string rateUrl = "https://play.google.com/store/apps/details?id=com.bocean.KingOfSlots";

	#region ENABLE/DISABLE
	
	void OnEnable()
	{
		RateUs_InputListener.RateUs_ButtonPressed += RateMeOnPlayStore;
	}
	
	void OnDisable()
	{
		RateUs_InputListener.RateUs_ButtonPressed -= RateMeOnPlayStore;
	}
	
	#endregion

	void RateMeOnPlayStore()
	{
		AndroidNativeUtility.OpenAppRatingPage(rateUrl);
	}
}
