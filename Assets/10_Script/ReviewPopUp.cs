using UnityEngine;
using System.Collections;

public class ReviewPopUp : MonoBehaviour {

	private int spinCounter;
	public GameObject reviewPopUp;
	private string review_reward;

	void Start()
	{
		spinCounter = PlayerPrefs.GetInt ("spinNO", 0);
		review_reward = PlayerPrefs.GetString ("Review", "not reviewed");
	}

	#region Enable / Disable

	void OnEnable()
	{
		Slot_Machine_System.NewSpin += SpinCounterCheck;
	}

	void OnDisable()
	{
		Slot_Machine_System.NewSpin -= SpinCounterCheck;
	}

	#endregion

	void SpinCounterCheck()
	{
		spinCounter++;

		if (spinCounter == 50 && review_reward == "not reviewed") 
		{
			if(reviewPopUp != null)
			{
				//reviewPopUp.SetActive(true);
			}
		}
	}
}
