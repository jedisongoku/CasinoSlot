using UnityEngine;
using System.Collections;

public class WinAnimation : MonoBehaviour {
	
	public GameObject win;
	public GameObject bigWin;
	public GameObject videoReward;
	public GameObject hourlyBonus;
	public GameObject dailyBonus;
	public GameObject inAppPurchase;
	public GameObject doubleUpBonusGame;
	
	#region Enable/Disable
	
	void OnEnable()
	{
		Slot_Machine_System.PlayWinAnimation 				+= SmallWinAnimation;
		Slot_Machine_System.PlayBigWinAnimation 			+= BigWinAnimation;
		RewardSystem.PlayHourlyBonusAnimation 				+= HourlyBonusAnimation;
		RewardSystem.PlayDailyBonusAnimation 				+= DailyBonusAnimation;
		RewardSystem.PlayVideoRewardAnimation 				+= VideoRewardAnimation;
		Bonus_game_2.PlayDoubleUpBonusWinAnimation 			+= DoubleUpWinAnimation;
		iOS_IAP_Payment_Manager.SuccessfullPurchase 		+= InAppPurchaseAnimation;
	}
	
	void OnDisable()
	{
		Slot_Machine_System.PlayWinAnimation 				-= SmallWinAnimation;
		Slot_Machine_System.PlayBigWinAnimation 			-= BigWinAnimation;
		RewardSystem.PlayHourlyBonusAnimation 				-= HourlyBonusAnimation;
		RewardSystem.PlayDailyBonusAnimation 				-= DailyBonusAnimation;
		RewardSystem.PlayVideoRewardAnimation 				-= VideoRewardAnimation;
		Bonus_game_2.PlayDoubleUpBonusWinAnimation 			-= DoubleUpWinAnimation;
		iOS_IAP_Payment_Manager.SuccessfullPurchase 		-= InAppPurchaseAnimation;
	}
	
	#endregion
	
	
	public void SmallWinAnimation()
	{
		if(win != null)
		{
			if(!win.activeSelf)
			{
                win.SetActive(true);
			}
		}
	}
	
	public void BigWinAnimation()
	{
		if(bigWin != null)
		{
			if(!bigWin.activeSelf)
			{
				bigWin.SetActive(true);
			}
		}
	}
	
	public void VideoRewardAnimation()
	{
		if(videoReward != null)
		{
			if(!videoReward.activeSelf)
			{
				videoReward.SetActive(true);
			}
		}
	}
	
	public void HourlyBonusAnimation()
	{
		if(hourlyBonus != null)
		{
			if(!hourlyBonus.activeSelf)
			{
				hourlyBonus.SetActive(true);
			}
		}
	}
	
	public void DailyBonusAnimation()
	{
		if(dailyBonus != null)
		{
			if(!dailyBonus.activeSelf)
			{
				dailyBonus.SetActive(true);
			}
		}
	}
	
	public void InAppPurchaseAnimation()
	{
		if(inAppPurchase != null)
		{
			if(!inAppPurchase.activeSelf)
			{
				inAppPurchase.SetActive(true);
			}
		}
	}
	
	
	public void DoubleUpWinAnimation()
	{
		if(doubleUpBonusGame != null)
		{
			if(!doubleUpBonusGame.activeSelf)
			{
				doubleUpBonusGame.SetActive(true);
			}
		}
	}
}
