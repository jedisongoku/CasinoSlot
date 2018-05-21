using UnityEngine;
using System.Collections;
using System;

public class RewardSystem : MonoBehaviour 
{
	public int daily_reward;
	public int hourly_reward;
	public int reward_time_inSec;
	public int email_reward;
	
	public UILabel countdown_label;
	public GameObject daily_bonus;
	public GameObject hourly_bonus;
	public GameObject review_reward_popUp;
	
	private string daily_date_playerAwarded;
	private string hourly_date_playerAwarded;
	private int hour_playerAwarded;
	private int minute_playerAwarded;
	private int second_playerAwarded;
	private int total_playerAwarded;
	
	private string current_date;
	private int current_hour;
	private int current_minute;
	private int current_second;
	private int current_total;
	
	private DateTime getDateTime;
	
	private float countdown_time;
	private int day_max_sec = 86400;
	private bool displayCountdown = false;
	private string niceTime;
	
	private string firstTime = "first time";
	private string review_coins;
	private string emailReward;
	
	public static Slot_Machine_System myReels;
	
	public delegate void HourlyBonusAnimation();
	public static event HourlyBonusAnimation PlayHourlyBonusAnimation;
	
	public delegate void DailyBonusAnimation();
	public static event DailyBonusAnimation PlayDailyBonusAnimation;
	
	public delegate void VideoRewardAnimation();
	public static event VideoRewardAnimation PlayVideoRewardAnimation;

	
	void Awake()
	{
		getDateTime = DateTime.Now;
		//get saved variables or set current
		hour_playerAwarded = PlayerPrefs.GetInt ("last hour", getDateTime.Hour);
		minute_playerAwarded = PlayerPrefs.GetInt ("last minute", getDateTime.Minute);
		second_playerAwarded = PlayerPrefs.GetInt ("last second", getDateTime.Second);
		daily_date_playerAwarded = PlayerPrefs.GetString ("date player awarded", getDateTime.Date.ToString ());
		
		total_playerAwarded = (hour_playerAwarded * 3600) + (minute_playerAwarded * 60) + second_playerAwarded;
		
		CheckCurrentData();
	}
	
	void Start()
	{
		GameObject myReelsObj = GameObject.Find ("AllReels");
		myReels = myReelsObj.GetComponent<Slot_Machine_System>();
	}
	
	void Update()
	{
		if(displayCountdown)
		{
			if(countdown_time>0) 
			{
				countdown_time -= Time.deltaTime;
				
				TimeSpan t = TimeSpan.FromSeconds(countdown_time);
				
				niceTime = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
				//niceTime = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
				
				countdown_label.text= niceTime;
				
			}
			else
			{
				Debug.Log ("checking current data, time has passed");
				CheckCurrentData();
				displayCountdown = false;
			}
		}
		else
		{
			//not displaying anything
		}
	}
	
	public void CheckCurrentData()
	{
		if(PlayerPrefs.GetString ("first time", "first time") == firstTime)
		{
			PlayerPrefs.SetString ("first time", "not allowed");
			hourly_bonus.GetComponent<Collider>().enabled = true;
			daily_bonus.GetComponent<Collider>().enabled = true;
		}
		else
		{
			// get current time
			getDateTime = DateTime.Now;
			
			//set current variables
			current_hour = getDateTime.Hour;
			current_minute = getDateTime.Minute;
			current_second = getDateTime.Second;
			current_date = getDateTime.Date.ToString ();
			current_total = (current_hour * 3600) + (current_minute * 60) + current_second;
			
			hour_playerAwarded = PlayerPrefs.GetInt ("last hour");
			minute_playerAwarded = PlayerPrefs.GetInt ("last minute");
			second_playerAwarded = PlayerPrefs.GetInt ("last second");
			
			daily_date_playerAwarded = PlayerPrefs.GetString ("daily date player awarded");
			hourly_date_playerAwarded = PlayerPrefs.GetString ("hourly date player awarded");
			
			total_playerAwarded = (hour_playerAwarded * 3600) + (minute_playerAwarded * 60) + second_playerAwarded;
			
			print ("current total" + current_total);
			print ("player awarded plus reward time total" + (total_playerAwarded + reward_time_inSec));
			print ("daily date player awarded" + daily_date_playerAwarded);
			print ("hourly date player awarded" + hourly_date_playerAwarded);
			print ("current date" + current_date);
			
			
			
			// **** CHECKING DAILY BONUS ENTITLEMENT ****
			
			if(daily_date_playerAwarded == current_date)
			{
				daily_bonus.GetComponent<Collider>().enabled = false;
			}
			else
			{
				daily_bonus.GetComponent<Collider>().enabled = true;
				print ("daily reward entitlement" + daily_reward);
			}
			
			
			// **** CHECKING HOURLY BONUS ENTITLEMENT ****
			
			if(hourly_date_playerAwarded == current_date)
			{
				if(current_total >= (total_playerAwarded + reward_time_inSec))
				{
					hourly_bonus.GetComponent<Collider>().enabled = true;
					displayCountdown = false;
					print ("we are able for hourly bonus");
				}
				else
				{
					countdown_time = (float) total_playerAwarded + reward_time_inSec - current_total;
					displayCountdown = true;
					hourly_bonus.GetComponent<Collider>().enabled = false;
					print ("we are not entitled for hourly bonus so start counting down");
				}
			}
			else
			{
				// counting code for the other day
				print ("the other day counting begin");
				
				if((total_playerAwarded + reward_time_inSec) > day_max_sec)
				{
					int secFromTheOtherDay;
					secFromTheOtherDay = (total_playerAwarded + reward_time_inSec) - day_max_sec;
					
					if(current_total >= secFromTheOtherDay)
					{
						hourly_bonus.GetComponent<Collider>().enabled = true;
						displayCountdown = false;
						print ("we are able for hourly bonus");
					}
					else
					{
						countdown_time = (float) secFromTheOtherDay - current_total;
						displayCountdown = true;
						hourly_bonus.GetComponent<Collider>().enabled = false;
						print ("we are not entitled for hourly bonus so start counting down");
					}
				}
			}
		}
		
	}
	
	public void CheckReviewEntitlement()
	{
		Debug.LogWarning ("review_coins value is " + review_coins);
		review_coins = PlayerPrefs.GetString ("Review", "not reviewed");
		Debug.LogWarning ("review_coins value is " + review_coins);
		
		if (review_coins == "not reviewed") 
		{
			//take me to the app store
			if(review_reward_popUp != null)
			{
				review_reward_popUp.SetActive(true);
			}
		} 
		else if (review_coins == "is reviewed")
		{
			Debug.Log ("UNFORTUNATELLY YOU HAVE BEEN ALREADY AWARDED");
		}
	}
	
	public void Collect_Hourly_Bonus()
	{
		hourly_bonus.GetComponent<Collider>().enabled = false;
		
		getDateTime = DateTime.Now;
		
		myReels.CreditBought(hourly_reward);
		
		if(PlayHourlyBonusAnimation != null)
		{
			PlayHourlyBonusAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayHourlyBonusAnimation DELEGATE");
		
		PlayerPrefs.SetInt ("last hour", getDateTime.Hour);
		PlayerPrefs.SetInt ("last minute", getDateTime.Minute);
		PlayerPrefs.SetInt ("last second", getDateTime.Second);
		PlayerPrefs.SetString ("hourly date player awarded", getDateTime.Date.ToString ());
		
		hour_playerAwarded = PlayerPrefs.GetInt ("last hour");
		minute_playerAwarded = PlayerPrefs.GetInt ("last minute");
		second_playerAwarded = PlayerPrefs.GetInt ("last second");
		
		total_playerAwarded = (hour_playerAwarded * 3600) + (minute_playerAwarded * 60) + second_playerAwarded;
		
		current_hour = getDateTime.Hour;
		current_minute = getDateTime.Minute;
		current_second = getDateTime.Second;
		
		current_total = (current_hour * 3600) + (current_minute * 60) + current_second;
		
		countdown_time = (float) total_playerAwarded + reward_time_inSec - current_total;
		
		displayCountdown = true;
		
		Debug.LogWarning(countdown_time);
		
		//GA.API.Design.NewEvent("BoughtCoins:HourlyReward");
	}
	
	public void Collect_Daily_Bonus()
	{
		daily_bonus.GetComponent<Collider>().enabled = false;
		
		getDateTime = DateTime.Now;
		
		PlayerPrefs.SetString ("daily date player awarded", getDateTime.Date.ToString ());
		
		myReels.CreditBought(daily_reward);
		
		if(PlayDailyBonusAnimation != null)
		{
			PlayDailyBonusAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayDailyBonusAnimation DELEGATE");
		
		//GA.API.Design.NewEvent("BoughtCoins:DailyReward");
	}
	
	public void CollectEmailBonus()
	{	
		emailReward = PlayerPrefs.GetString("Email", "not awarded");
		
		if (emailReward == "not awarded") 
		{
			myReels.CreditBought(email_reward);
			
			PlayerPrefs.SetString ("Email", "awarded");
			
			if(PlayDailyBonusAnimation != null)
			{
				PlayDailyBonusAnimation();
			}
			else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayDailyBonusAnimation DELEGATE");
			
			//GA.API.Design.NewEvent("BoughtCoins:EmailReward");
		}
	}
	
	public void RewardInterstitialWatched(int amount)
	{	
		Debug.Log ("REWARD SHOULD BE ADDED FOR WATCHING VIDEOS");
		myReels.CreditBought(amount);
		
		if(PlayVideoRewardAnimation != null)
		{
			PlayVideoRewardAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayVideoRewardAnimation DELEGATE");
	}
}
