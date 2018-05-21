using UnityEngine;
using System.Collections;

public class RateUs_InputListener : MonoBehaviour {

	public delegate void RateUs();
	public static event RateUs RateUs_ButtonPressed;

	public void RateMeOnStore()
	{
		if(RateUs_ButtonPressed != null)
		{
			RateUs_ButtonPressed();
		}
		else Debug.LogWarning("NOTHING IS SUBSCRIBED TO RateUs_ButtonPressed DELEGATE");
	}
}
