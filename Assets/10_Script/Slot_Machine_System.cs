//--------------COPYRIGHT----------------------
// Copyright © 2014 SSC Production Entertainment
// 			Design by Mikey      
//			info@slovack.com
//********************************************** 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Slot_Machine_System : MonoBehaviour 
{
	//set values
	public bool runBG_onPair;
	public bool reset_game;
	public int def_balance_value = 1000;
	public int def_bet_value = 5;
	//public int win_1_x = 1000;
	//public int win_2_x = 750;
	//public int win_3_x = 500;
	public int five_diamond_x;
	public int five_seven_x;
	public int five_plum_x;
	public int five_bell_x;
	public int five_melon_x;
	public int five_cherry_x;
	public int five_lemon_x;
	public int five_bar_x;
	public int win_4_x = 200;
	public int win_5_x = 100;
	public int win_6_x = 50;
	public int win_7_x = 25;
	public int win_8_x = 5;
	public int win_9_x = 5;
	public int win_10_x = 1;
	public string symbol1 = "Diamond";
	public string symbol2 = "Seven";
	public string symbol3 = "Plum";
	public string symbol4 = "Bell";
	public string symbol5 = "Melon";
	public string symbol6 = "Cherry";
	public string symbol7 = "Lemon";
	public string symbol8 = "Bar";
	public float autospin_yield = 2.5f;

	// input reciever
		//NGUI components
	public UILabel balance_label_UIL;
	public UILabel bet_label_UIL;
	public UILabel win_label_UIL;
	public UILabel spin_counter_label_UIL;
	public UILabel autospin_option_no;

	//state machine
	public GameObject left_animation;
	public GameObject m_left_animation;
	public GameObject middle_animation;
	public GameObject m_right_animation;
	public GameObject right_animation;

	public GameObject win_message_1;
	public GameObject win_message_2;
	public GameObject win_message_3;
	public GameObject win_message_4;
	public GameObject win_message_5;
	public GameObject win_message_6;
	public GameObject win_message_7;
	public GameObject win_message_8;
	public GameObject win_message_9;
	public GameObject win_message_10;
	public GameObject spin_counter;
	public GameObject spin_counter_def;
	public GameObject autospin_up;
	public GameObject autospin_down;
	public GameObject start_autospin;
	public GameObject stop_autospin;
	public GameObject run_bonus_game_2;
	public GameObject gameCenterObj;
	public GameObject bonusGameObj;
	public GameObject levelSystemObj;
	public GameObject more_coins;
	public GameObject more_coins_background;
	public GameObject blockCollider1;

	//private variables
	private int winCount = 0;
	private int bigWinCount = 0;
	private int level_counter = 0;
	private int winAmount;
	private int autospinNO;
	private int default_autospinNO = 5;
	private string winMessage;
	private string m_firstReel;
	private string m_secondReel;
	private string m_thirdReel;
	private string m_fourthReel;
	private string m_fifthReel;
	private bool showAutospinValues;
	public bool autospin = false;
	private bool firstspin = false;
	private bool spining = false;
	public bool bonusGame = false;
	//private bool winningGame = false;
	private bool showAd1 = false;
	private bool showAd2 = false;
	private bool isWinMessageOn = false;
	private bool gameActive;
	private bool lastAutoSpin = false;
	private List<GameObject> obj_winMessage = new List<GameObject>();
	private iOs_GameCenter gameCenter;
	private Bonus_game_2 bg_2;
	private Level_System levelSystem;

	public delegate void SpinCounter();
	public static event SpinCounter NewSpin;

	public delegate void ActivateCoinOffer();
	public static event ActivateCoinOffer CoinOffer;

	//public delegate void ShowInterstitial_IAD();
	//public static event ShowInterstitial_IAD ShowIAD;

	public delegate void ShowInterstitial();
	public static event ShowInterstitial _ShowInterstitial;

	public delegate void DisplayWinAnimation();
	public static event DisplayWinAnimation PlayWinAnimation;

	public delegate void DisplayBigWinAnimation();
	public static event DisplayBigWinAnimation PlayBigWinAnimation;
	 
	void Start()
	{
		GetComponent<SWP_SlotMachine>().OnReelStart += OnReelStart;
		GetComponent<SWP_SlotMachine>().OnEachReelFinished += OnEachReelFinished;
		GetComponent<SWP_SlotMachine>().OnReelsFinished += OnReelsFinished;

		gameCenter = gameCenterObj.GetComponent<iOs_GameCenter>();
		bg_2 = bonusGameObj.GetComponent<Bonus_game_2>();
		levelSystem = levelSystemObj.GetComponent<Level_System>();

		if (reset_game)
		{
			PlayerPrefs.DeleteAll();
		}
		
		def_balance_value = PlayerPrefs.GetInt ("balance",def_balance_value);
		level_counter = PlayerPrefs.GetInt ("levelCounter", level_counter);

		//RewriteBalance("" + def_balance_value);
		//RewriteBet("" + def_bet_value);
		//print (def_bet_value.ToString("#.00"));
		//print (def_balance_value);
		RewriteBet(def_bet_value.ToString("#"));
		RewriteBalance(def_balance_value.ToString("#"));
	}
	
	//coroutines
	IEnumerator SpinAutomatically()
	{
		if (firstspin)
		{
			yield return new WaitForSeconds (0.5f);
			firstspin = false;
		}
		else
		{
			yield return new WaitForSeconds (autospin_yield);
		}

		if (def_balance_value >= def_bet_value)
		{	
			if (autospin && autospinNO >= 0)
			{
				ActivateSpinCounter();
				SpinStopButton();
			}
		}
		else if (def_balance_value < def_bet_value && def_balance_value != 0)
		{
			if(def_balance_value >= 5 && def_balance_value < 10)
			{
				def_bet_value = 5;
			}
			else if(def_balance_value >= 10 && def_balance_value < 25)
			{
				def_bet_value = 10;
			}
			else if(def_balance_value >= 25 && def_balance_value < 50)
			{
				def_bet_value = 25;
			}
			else if(def_balance_value >= 50 && def_balance_value < 100)
			{
				def_bet_value = 50;
			}
			else if(def_balance_value >= 100 && def_balance_value < 250)
			{
				def_bet_value = 100;
			}
			else if(def_balance_value >= 250 && def_balance_value < 500)
			{
				def_bet_value = 250;
			}
			else if(def_balance_value >= 500 && def_balance_value < 1000)
			{
				def_bet_value = 500;
			}

			RewriteBet("" + def_bet_value.ToString("#"));


			if (autospin && autospinNO >= 0)
			{
				ActivateSpinCounter();
				SpinStopButton();
			}
		}
		else if (autospin && def_balance_value == 0)
		{
			autospin = false;
			autospinNO = 0;
			more_coins.SetActive (true);
			more_coins_background.SetActive (true);
			start_autospin.SetActive (true);
			stop_autospin.SetActive (false);
			Debug.Log ("buy some package of coins");
			DeactivateSpinCounter();
			//ActivateSelectedButtons();
		}
	}

	IEnumerator ActivateButtons()
	{
		if(!spining)
		{
			yield return new WaitForSeconds(0.05f);
			if(!autospin)
			{
				if(lastAutoSpin)
				{
					blockCollider1.SetActive(false);
					start_autospin.SetActive(true);
					stop_autospin.SetActive(false);
					lastAutoSpin = false;
				}
				else
				{
					blockCollider1.SetActive(false);
				}
			}
//			else
//			{
//				spin.collider.enabled = true;
//				coins.collider.enabled = true;
//				bet.collider.enabled = true;
//				payouts.collider.enabled = true;
//				start_autospin.collider.enabled = true;
//			}
		}
	}

	void ActivateSpinCounter()
	{
		spin_counter.SetActive(true);
		spin_counter_def.SetActive(false);
	}

	void DeactivateSpinCounter()
	{
		spin_counter.SetActive(false);
		spin_counter_def.SetActive (true);
	}

	public void SpinStopButton ()
	{
		if(!spining && !bonusGame)
		{
			run_bonus_game_2.SetActive(false);
			left_animation.SetActive(false);
			m_left_animation.SetActive(false);
			middle_animation.SetActive(false);
			m_right_animation.SetActive(false);
			right_animation.SetActive (false);
		
			if (def_bet_value == 5)
			{
				//GA.API.Design.NewEvent("BetValue:5");
				Debug.Log ("event 5 sent");
			}
			else if(def_bet_value == 10)
			{
				//GA.API.Design.NewEvent("BetValue:10");
				Debug.Log ("event 10 sent");
			}
			else if(def_bet_value == 25)
			{
				//GA.API.Design.NewEvent("BetValue:25");
				Debug.Log ("event 25 sent");
			}
			else if(def_bet_value == 50)
			{
				//GA.API.Design.NewEvent("BetValue:50");
				Debug.Log ("event 50 sent");
			}
			else if(def_bet_value == 100)
			{
				//GA.API.Design.NewEvent("BetValue:100");
				Debug.Log ("event 100 sent");
			}
			else if(def_bet_value == 250)
			{
				//GA.API.Design.NewEvent("BetValue:250");
				Debug.Log ("event 250 sent");
			}
			else if(def_bet_value == 500)
			{
				//GA.API.Design.NewEvent("BetValue:500");
				Debug.Log ("event 500 sent");
			}
			else if(def_bet_value == 1000)
			{
				//GA.API.Design.NewEvent("BetValue:1000");
				Debug.Log ("event 1000 sent");
			}
			else
			{
				//GA.API.Design.NewEvent("BetValue:Other");
				Debug.Log ("event other sent");
			}

			if(isWinMessageOn)
			{
				DeactivateWinMessage();
				isWinMessageOn = false;
			}
			if (autospin)
			{
				autospinNO--;
				RewriteAutospinCounter();
			}

			if(def_balance_value > 0)
			{
				if (def_balance_value >= def_bet_value)
				{
					blockCollider1.SetActive (true);

					if(NewSpin != null)
					{
						NewSpin();
					}
					else Debug.LogWarning ("NOTHING IS ASSIGN TO NewSpin DELEGATE");

					def_balance_value = def_balance_value - def_bet_value;
					RewriteBalance("" + def_balance_value.ToString("#"));
					GetComponent<SWP_SlotMachine>().StartStopReels();
					spining = true;
					PlayerPrefs.SetInt ("balance", def_balance_value);
					RewriteWinValue("0");
					level_counter = level_counter + def_bet_value;
					PlayerPrefs.SetInt ("levelCounter", level_counter);
					levelSystem.CheckLevelAchievement();
					levelSystem.MoveLevelProgressBar();
					//DeactivateSelectedButtons();
					if(showAd1)
					{
						if(_ShowInterstitial != null)
						{
							_ShowInterstitial();
						}
						else Debug.LogWarning ("NOTHING IS ASSIGN TO _ShowInterstitial DELEGATE");

						showAd1 = false;
					}

//					if(showAd2)
//					{
//						if(ShowIAD != null)
//						{
//							ShowIAD();
//						}
//						else Debug.LogWarning ("NOTHING IS ASSIGN TO ShowIAD DELEGATE");
//
//						showAd2 = false;
//					}
				}
				else if (def_balance_value < def_bet_value)
				{
					if(def_balance_value >= 5 && def_balance_value < 10)
					{
						def_bet_value = 5;
					}
					else if(def_balance_value >= 10 && def_balance_value < 25)
					{
						def_bet_value = 10;
					}
					else if(def_balance_value >= 25 && def_balance_value < 50)
					{
						def_bet_value = 25;
					}
					else if(def_balance_value >= 50 && def_balance_value < 100)
					{
						def_bet_value = 50;
					}
					else if(def_balance_value >= 100 && def_balance_value < 250)
					{
						def_bet_value = 100;
					}
					else if(def_balance_value >= 250 && def_balance_value < 500)
					{
						def_bet_value = 250;
					}
					else if(def_balance_value >= 500 && def_balance_value < 1000)
					{
						def_bet_value = 500;
					}

					blockCollider1.SetActive (true);

					if(NewSpin != null)
					{
						NewSpin();
					}
					else Debug.LogWarning ("NOTHING IS ASSIGN TO NewSpin DELEGATE");

					def_balance_value = def_balance_value - def_bet_value;
					RewriteBalance("" + def_balance_value.ToString("#"));
					RewriteBet("" + def_bet_value.ToString("#"));
					GetComponent<SWP_SlotMachine>().StartStopReels();
					spining = true;
					PlayerPrefs.SetInt ("balance", def_balance_value);
					RewriteWinValue("0");
					level_counter++;
					PlayerPrefs.SetInt ("levelCounter", level_counter);
					levelSystem.CheckLevelAchievement();
					levelSystem.MoveLevelProgressBar();
					//DeactivateSelectedButtons();

					if(showAd1)
					{
						if(_ShowInterstitial != null)
						{
							_ShowInterstitial();
						}
						else Debug.LogWarning ("NOTHING IS ASSIGN TO _ShowInterstitial DELEGATE");

						showAd1 = false;
					}
					
//					if(showAd2)
//					{
//						if(ShowIAD != null)
//						{
//							ShowIAD();
//						}
//						else Debug.LogWarning ("NOTHING IS ASSIGN TO ShowIAD DELEGATE");
//
//						showAd2 = false;
//					}
				}
				else
				{
					Debug.Log ("Not enough money");
					//RewriteWinMessage("Not enough money");
					RewriteWinValue("0");
				}
			}
			else
			{
				more_coins.SetActive (true);
				more_coins_background.SetActive (true);
				Debug.Log ("buy some package of coins");
			}
		}
	}
	
	public void StopAutospin()
	{
		lastAutoSpin = true;
		autospin = false;
		stop_autospin.SetActive (false);
		start_autospin.SetActive(true);
		autospinNO = 0;
		DeactivateSpinCounter();
		if(!spining)
		{
			blockCollider1.SetActive(false);
		}
	}

	public void AutoSpin_Up()
	{
		Debug.Log("autospin up is running");
		if(!spining && !bonusGame)
		{
			if (def_balance_value > 0)
			{
				if(default_autospinNO == 5)
				{
					default_autospinNO = 10;
					autospin_option_no.text = "10";
				}
				else if(default_autospinNO == 10)
				{
					default_autospinNO = 25;
					autospin_option_no.text = "25";
				}
				else if(default_autospinNO == 25)
				{
					default_autospinNO = 50;
					autospin_option_no.text = "50";
				}
				else if(default_autospinNO == 50)
				{
					default_autospinNO = 50;
					autospin_option_no.text = "50";
				}
			}
			else
			{
				//RewriteWinMessage("Not enough money");
			}
		}
	}

	public void Autospin_Down()
	{
		Debug.Log("autospin down is running");
		if(!spining && !bonusGame)
		{
			if (def_balance_value > 0)
			{	
				if(default_autospinNO == 50)
				{
					default_autospinNO = 25;
					autospin_option_no.text = "25";
				}
				else if(default_autospinNO == 25)
				{
					default_autospinNO = 10;
					autospin_option_no.text = "10";
				}
				else if(default_autospinNO == 10)
				{
					default_autospinNO = 5;
					autospin_option_no.text = "5";
				}
				else if(default_autospinNO == 5)
				{
					default_autospinNO = 5;
					autospin_option_no.text = "5";
				}
			}
			else
			{
				//RewriteWinMessage("Not enough money");
			}
		}
	}

	public void AutospinStart()
	{
		if(!spining && !bonusGame)
		{
			if (def_balance_value > 0)
			{
				firstspin = true;
				autospin = true;
				autospinNO = default_autospinNO;
				StartCoroutine("SpinAutomatically");
				stop_autospin.SetActive (true);
				start_autospin.SetActive(false);
			}
			else
			{
				more_coins.SetActive (true);
				more_coins_background.SetActive (true);
			}
		}
	}

	void OnReelStart(GameObject go)
	{
		//Debug.Log("(REEL START)");
	}
	
	void OnEachReelFinished(GameObject go, int _ReelNumber)
	{
		//		SWP_SlotMachine thisSlotMachine = GetComponent<SWP_SlotMachine>();
		//		//Debug.Log("(REEL FINISHED - " + thisSlotMachine.AllReels[_ReelNumber].GetReelItemName() + " [" + thisSlotMachine.AllReels[_ReelNumber].GetReelItemValue() + "]" + ")");
		//
		//		if (thisSlotMachine.AllReels[_ReelNumber].GetMiddleReelItemValue() == 1)
		//			Debug.Log("You Win: " + thisSlotMachine.AllReels[_ReelNumber].GetMiddleReelItemName());
		//		else if (thisSlotMachine.AllReels[_ReelNumber].GetMiddleReelItemValue() > 0)
		//			Debug.Log("You Win: " + thisSlotMachine.AllReels[_ReelNumber].GetMiddleReelItemValue() + " " + thisSlotMachine.AllReels[_ReelNumber].GetMiddleReelItemName());
	}
	
	void OnReelsFinished(GameObject go)
	{
		spining = false;

		if(autospin && autospinNO == 0)
		{
			autospin = false;
			StopAutospin();
		}

		SWP_SlotMachine thisSlotMachine = GetComponent<SWP_SlotMachine>();
		
		//assigning the values from top row to string var
		//t_firstReel = thisSlotMachine.AllReels[0].GetTopReelItemName();
		//t_secondReel = thisSlotMachine.AllReels[1].GetTopReelItemName();
		//t_thirdReel = thisSlotMachine.AllReels[2].GetTopReelItemName();
		//t_fourthReel = thisSlotMachine.AllReels[3].GetTopReelItemName();
		//t_fifthReel = thisSlotMachine.AllReels[4].GetTopReelItemName();
		
		//assigning the values from middle raw to string var
		m_firstReel = thisSlotMachine.AllReels[0].GetMiddleReelItemName();
		m_secondReel = thisSlotMachine.AllReels[1].GetMiddleReelItemName();
		m_thirdReel = thisSlotMachine.AllReels[2].GetMiddleReelItemName();
		m_fourthReel = thisSlotMachine.AllReels[3].GetMiddleReelItemName();
		m_fifthReel = thisSlotMachine.AllReels[4].GetMiddleReelItemName();
		
		//assigning the values from bottom row to string var
		//b_firstReel = thisSlotMachine.AllReels[0].GetBottomReelItemName();
		//b_secondReel = thisSlotMachine.AllReels[1].GetBottomReelItemName();
		//b_thirdReel = thisSlotMachine.AllReels[2].GetBottomReelItemName();
		//b_fourthReel = thisSlotMachine.AllReels[3].GetBottomReelItemName();
		//b_fifthReel = thisSlotMachine.AllReels[4].GetBottomReelItemName();
		
		//comparing top values to see if player win
		
		//comparing middle values to see if player win
		
		// ***** all 5 matches *****
		if (m_firstReel == m_secondReel && m_secondReel == m_thirdReel && m_thirdReel == m_fourthReel && m_fourthReel == m_fifthReel)
		{
			//Jackpot
			Jackpot();
		}
		
		// ***** 4 matches *****
		else if (m_firstReel == m_secondReel && m_secondReel == m_thirdReel && m_thirdReel == m_fourthReel
		         || m_secondReel == m_thirdReel && m_thirdReel == m_fourthReel && m_fourthReel == m_fifthReel)
		{
			if (m_firstReel == m_secondReel && m_secondReel == m_thirdReel && m_thirdReel == m_fourthReel)
			{
				//left 4 match
				LeftFour();
			}
			else
			{
				//right 4 match
				RightFour();
			}
		}
		
		// ***** 3 + 2 marches ***** + 3 of a kind *****
		else if (m_firstReel == m_secondReel && m_secondReel == m_thirdReel
		         || m_secondReel == m_thirdReel && m_thirdReel == m_fourthReel
		         || m_thirdReel == m_fourthReel && m_fourthReel == m_fifthReel)
		{
			if (m_firstReel == m_secondReel && m_secondReel == m_thirdReel && m_fourthReel == m_fifthReel)
			{
				//Left full house
				LeftFullHouse();
			}
			else if(m_thirdReel == m_fourthReel && m_fourthReel == m_fifthReel && m_firstReel == m_secondReel)
			{
				//Right full house
				RightFullHouse();
			}
			else if (m_firstReel == m_secondReel && m_secondReel == m_thirdReel)
			{
				//Left three
				LeftThree();
			}
			else if (m_secondReel == m_thirdReel && m_thirdReel == m_fourthReel)
			{
				//Middle three
				MiddleThree();
			}
			else if (m_thirdReel == m_fourthReel && m_fourthReel == m_fifthReel)
			{
				//Right three
				RightThree();
			}
		}
		
		// ***** 2 + 2 matches ***** + two pairs *****
		else if(m_firstReel == m_secondReel || m_secondReel == m_thirdReel || m_thirdReel == m_fourthReel || m_fourthReel == m_fifthReel)
		{
			if (m_firstReel == m_secondReel && m_thirdReel == m_fourthReel)
			{
				//left two pairs
				LeftTwoPairs();
			}
			else if (m_secondReel == m_thirdReel && m_fourthReel == m_fifthReel)
			{
				//right two pairs
				RightTwoPairs();
			}
			else if (m_firstReel == m_secondReel && m_fourthReel == m_fifthReel)
			{
				//side two pairs
				SideTwoPairs();
			}
			else if (m_firstReel == m_secondReel)
			{
				//left pair
				LeftPair();
			}
			else if (m_secondReel == m_thirdReel)
			{
				//middle left pair
				MiddleLeftPair();
			}
			
			else if (m_thirdReel == m_fourthReel)
			{
				//middle right pair
				MiddleRightPair();
			}
			else if (m_fourthReel == m_fifthReel)
			{
				//right pair
				RightPair();
			}
			
		}
		else
		{
			NoWin();

			if(CoinOffer != null)
			{
				CoinOffer();
			}
		}	
	}

	void Jackpot ()
	{
		if (m_firstReel == symbol1)
		{
			Win_BG_2 (five_diamond_x, win_message_1);
			//gameCenter.Mega_Jackpot_achievement();
		}
		else if (m_firstReel == symbol2)
		{
			Win_BG_2 (five_seven_x, win_message_2);
			//gameCenter.LuckyJackpot_achievement();
		}
		else if (m_firstReel == symbol3)
		{
			Win_BG_2 (five_plum_x, win_message_3);
			//gameCenter.Jackpot_achievement();
		}
		else if (m_firstReel == symbol4)
		{
			Win_BG_2 (five_bell_x, win_message_3);
			//gameCenter.Jackpot_achievement();
		}
		else if (m_firstReel == symbol5)
		{
			Win_BG_2 (five_melon_x, win_message_3);
			//gameCenter.Jackpot_achievement();
		}
		else if (m_firstReel == symbol6)
		{
			Win_BG_2 (five_cherry_x, win_message_3);
			//gameCenter.Jackpot_achievement();
		}
		else if (m_firstReel == symbol7)
		{
			Win_BG_2 (five_lemon_x, win_message_3);
			//gameCenter.Jackpot_achievement();
		}
		else if (m_firstReel == symbol8)
		{
			Win_BG_2 (five_bar_x, win_message_3);
			//gameCenter.Jackpot_achievement();
		}

		PlayAnimationOnMatch(true,true,true,true,true);

		if(PlayBigWinAnimation != null)
		{
			PlayBigWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayBigWinAnimation DELEGATE");

		BonusGame_2();
		BigWinAdvertAllowance ();
	}
	
	void LeftFour ()
	{
		if (m_firstReel == symbol1)
		{
			Win_BG_2 (win_4_x, win_message_6);
			//gameCenter.Lucky_Jewel_achievement();
		}
		else if (m_firstReel == symbol2)
		{
			Win_BG_2 (win_5_x, win_message_5);
			//gameCenter.Lucky_Seven_achievement();
		}
		else if (m_firstReel == symbol3)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_firstReel == symbol4)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_firstReel == symbol5)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_firstReel == symbol6)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_firstReel == symbol7)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_firstReel == symbol8)
		{
			Win_BG_2 (win_6_x, win_message_4);
			//gameCenter.Four_of_a_Kind_achievement();
		}

		PlayAnimationOnMatch(true,true,true,true,false);

		if(PlayBigWinAnimation != null)
		{
			PlayBigWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayBigWinAnimation DELEGATE");

		BonusGame_2();
		BigWinAdvertAllowance ();
	}
	
	void RightFour ()
	{
		if (m_secondReel == symbol1)
		{
			Win_BG_2 (win_4_x, win_message_6);
			//gameCenter.Lucky_Jewel_achievement();
		}
		else if (m_secondReel == symbol2)
		{
			Win_BG_2 (win_5_x, win_message_5);
			//gameCenter.Lucky_Seven_achievement();
		}
		else if (m_secondReel == symbol3)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_secondReel == symbol4)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_secondReel == symbol5)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_secondReel == symbol6)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_secondReel == symbol7)
		{
			Win_BG_2 (win_6_x, win_message_6);
			//gameCenter.Four_of_a_Kind_achievement();
		}
		else if (m_secondReel == symbol8)
		{
			Win_BG_2 (win_6_x, win_message_4);
			//gameCenter.Four_of_a_Kind_achievement();
		}

		PlayAnimationOnMatch(false,true,true,true,true);

		if(PlayBigWinAnimation != null)
		{
			PlayBigWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayBigWinAnimation DELEGATE");

		BonusGame_2();
		BigWinAdvertAllowance ();
	}
	
	void LeftFullHouse()
	{
		if (m_firstReel == symbol1)
		{
			Win_BG_2(win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol2)
		{
			Win_BG_2(win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol3)
		{
			Win_BG_2(win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol4)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol5)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol6)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol7)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_firstReel == symbol8)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}

		PlayAnimationOnMatch(true,true,true,true,true);

		if(PlayBigWinAnimation != null)
		{
			PlayBigWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayBigWinAnimation DELEGATE");

		//gameCenter.Full_House_achievement();
		BonusGame_2();
		BigWinAdvertAllowance ();
	}
	
	void RightFullHouse ()
	{
		if (m_thirdReel == symbol1)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol2)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol3)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol4)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol5)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol6)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol7)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}
		else if (m_thirdReel == symbol8)
		{
			Win_BG_2 (win_7_x, win_message_7);
		}

		PlayAnimationOnMatch(true,true,true,true,true);

		if(PlayBigWinAnimation != null)
		{
			PlayBigWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayBigWinAnimation DELEGATE");

		//gameCenter.Full_House_achievement();
		BonusGame_2();
		BigWinAdvertAllowance ();
	}
	
	void LeftThree ()
	{
		if (m_firstReel == symbol1)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol2)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol3)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol4)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol5)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol6)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol7)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_firstReel == symbol8)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}

		PlayAnimationOnMatch(true,true,true,false,false);

		if(PlayWinAnimation != null)
		{
			PlayWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayWinAnimation DELEGATE");

		//gameCenter.Three_of_a_Kind_achievement();
		BonusGame_2();
		WinAdvertAllowance ();
	}
	
	void MiddleThree ()
	{
		if (m_thirdReel == symbol1)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol2)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol3)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol4)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol5)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol6)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol7)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_thirdReel == symbol8)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}

		PlayAnimationOnMatch(false,true,true,true,false);

		if(PlayWinAnimation != null)
		{
			PlayWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayWinAnimation DELEGATE");

		//gameCenter.Three_of_a_Kind_achievement();
		BonusGame_2();
		WinAdvertAllowance ();
	}
	
	void RightThree()
	{
		if (m_fifthReel == symbol1)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol2)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol3)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol4)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol5)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol6)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol7)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}
		else if (m_fifthReel == symbol8)
		{
			Win_BG_2 (win_8_x, win_message_8);
		}	

		PlayAnimationOnMatch(false,false,true,true,true);

		if(PlayWinAnimation != null)
		{
			PlayWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayWinAnimation DELEGATE");

		//gameCenter.Three_of_a_Kind_achievement();
		BonusGame_2();
		WinAdvertAllowance ();
	}
	
	void LeftTwoPairs ()
	{
		if (m_firstReel == symbol1)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol2)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol3)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol4)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol5)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol6)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol7)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol8)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}

		PlayAnimationOnMatch(true,true,true,true,false);

		if(PlayWinAnimation != null)
		{
			PlayWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayWinAnimation DELEGATE");

		//gameCenter.Two_Pairs_achievement();
		BonusGame_2();
		WinAdvertAllowance ();
	}
	
	void RightTwoPairs ()
	{
		if (m_secondReel == symbol1)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol2)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol3)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol4)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol5)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol6)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol7)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_secondReel == symbol8)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}

		PlayAnimationOnMatch(false,true,true,true,true);

		if(PlayWinAnimation != null)
		{
			PlayWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayWinAnimation DELEGATE");

		//gameCenter.Two_Pairs_achievement();
		BonusGame_2();
		WinAdvertAllowance ();
	}
	
	void SideTwoPairs ()
	{
		if (m_firstReel == symbol1)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol2)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol3)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol4)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol5)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol6)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol7)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}
		else if (m_firstReel == symbol8)
		{
			Win_BG_2 (win_9_x, win_message_9);
		}

		PlayAnimationOnMatch(true,true,false,true,true);

		if(PlayWinAnimation != null)
		{
			PlayWinAnimation();
		}
		else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayWinAnimation DELEGATE");

		//gameCenter.Two_Pairs_achievement();
		BonusGame_2();
		WinAdvertAllowance ();
	}
	
	void LeftPair ()
	{
		if (m_firstReel == symbol1)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol2)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol3)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol4)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol5)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol6)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol7)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_firstReel == symbol8)
		{
			Win (win_10_x, win_message_10);
		}

		PlayAnimationOnMatch(true,true,false,false,false);
		//gameCenter.Pair_achievement();
		WinAdvertAllowance ();
	}
	
	void MiddleLeftPair ()
	{
		if (m_secondReel == symbol1)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol2)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol3)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol4)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol5)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol6)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol7)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_secondReel == symbol8)
		{
			Win (win_10_x, win_message_10);
		}

		PlayAnimationOnMatch(false,true,true,false,false);
		//gameCenter.Pair_achievement();
		WinAdvertAllowance ();
	}
	
	void MiddleRightPair ()
	{
		if (m_thirdReel == symbol1)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol2)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol3)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol4)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol5)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol6)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol7)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_thirdReel == symbol8)
		{
			Win (win_10_x, win_message_10);
		}

		PlayAnimationOnMatch(false,false,true,true,false);
		//gameCenter.Pair_achievement();
		WinAdvertAllowance ();
	}
	
	void RightPair ()
	{
		if (m_fifthReel == symbol1)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol2)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol3)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol4)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol5)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol6)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol7)
		{
			Win (win_10_x, win_message_10);
		}
		else if (m_fifthReel == symbol8)
		{
			Win (win_10_x, win_message_10);
		}	

		PlayAnimationOnMatch(false,false,false,true,true);
		//gameCenter.Pair_achievement();
		WinAdvertAllowance ();
	}

	void NoWin()
	{
		winAmount = 0;
		PlayerPrefs.SetInt("balance", def_balance_value);

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}

		RewriteWinValue("0"); 
	}

	public void Add_Win_BG_2()
	{
		def_balance_value = def_balance_value + winAmount;

		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			gameCenter.ReportScore(def_balance_value);
		}

		PlayerPrefs.SetInt("balance", def_balance_value);

		RewriteBalance ("" + def_balance_value.ToString("#"));

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}
	}

	void Win_BG_2 (int amount, GameObject winMessage)
	{
		winAmount = def_bet_value * amount;
		def_balance_value = def_balance_value + winAmount;
		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			gameCenter.ReportScore(def_balance_value);
		}
		PlayerPrefs.SetInt("balance", def_balance_value);

		RewriteBalance ("" + def_balance_value.ToString("#"));
		RewriteWinValue("" + winAmount.ToString("#"));
		ActivateWinMessage(winMessage);
		isWinMessageOn = true;

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}
	}

	void Win(int amount, GameObject winMessage)
	{
		winAmount = def_bet_value * amount;
		def_balance_value = def_balance_value + winAmount;
		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			gameCenter.ReportScore(def_balance_value);
		}
		PlayerPrefs.SetInt("balance", def_balance_value);

		RewriteWinValue("" + winAmount.ToString("#"));
		RewriteBalance ("" + def_balance_value.ToString("#"));
		ActivateWinMessage(winMessage);
		isWinMessageOn = true;
		
		//winningGame = true;

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}
	}

	void BonusGame ()
	{
		//run_bonus_game.SetActive(true);
	}

	void BonusGame_2()
	{
		run_bonus_game_2.SetActive(true);
		bg_2.CurrentWinValue(winAmount);
	}

	public void BonusGameWin (int value)
	{
		def_balance_value = def_balance_value + value;

		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			gameCenter.ReportScore(def_balance_value);
		}
		 
		PlayerPrefs.SetInt("balance", def_balance_value);
		RewriteBalance ("" + def_balance_value.ToString("#"));
		bonusGame = false;
		Debug.Log (bonusGame);

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}
	}

	public void BonusGame_2_Win (int value)
	{
		def_balance_value = def_balance_value + value;

		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			gameCenter.ReportScore(def_balance_value);
		}

		PlayerPrefs.SetInt("balance", def_balance_value);
		RewriteBalance ("" + def_balance_value.ToString("#"));
		RewriteWinValue("" + value.ToString("#"));
		bonusGame = false;
		Debug.Log (bonusGame);

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}
	}

	public void BonusGame_2_GameOver()
	{
		bonusGame = false;
		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			gameCenter.ReportScore(def_balance_value);
		}
		
		PlayerPrefs.SetInt("balance", def_balance_value);
		RewriteWinValue("0");

		if(autospin)
		{
			StartCoroutine("SpinAutomatically");
		}
		else
		{
			StartCoroutine("ActivateButtons");
		}
	}

	public void BetValue()
	{
		if(!spining)
		{
			if(def_bet_value == 5 && def_balance_value >= 10)
			{
				def_bet_value = 10;
			}
			else if(def_bet_value == 10 && def_balance_value >= 25)
			{
				def_bet_value = 25;
			}
			else if(def_bet_value == 25 && def_balance_value >= 50)
			{
				def_bet_value = 50;
			}
			else if(def_bet_value == 50 && def_balance_value >= 100)
			{
				def_bet_value = 100;
			}
			else if(def_bet_value == 100 && def_balance_value >= 250)
			{
				def_bet_value = 250;
			}
			else if(def_bet_value == 250 && def_balance_value >= 500)
			{
				def_bet_value = 500;
			}
			else if(def_bet_value == 500 && def_balance_value >= 1000)
			{
				def_bet_value = 1000;
			}
			else if(def_bet_value == 1000)
			{
				def_bet_value = 5;
			}
			else if (def_bet_value < def_balance_value)
			{
				def_bet_value = def_balance_value;
			}
			else if (def_bet_value >= def_balance_value)
			{
				def_bet_value = 5;
			}

			RewriteBet("" + def_bet_value.ToString("#"));
		}
	}
	
	void ActivateWinMessage(GameObject winMessage)
	{
		winMessage.SetActive(true);
		obj_winMessage.Add(winMessage);
	}

	void DeactivateWinMessage()
	{
		GameObject winMessage;
		winMessage = obj_winMessage[0];
		winMessage.SetActive(false);
		obj_winMessage.Clear();
	}

	public void RewriteWinValue(string winValue)
	{
		win_label_UIL.text = winValue;

	}

	public void RewriteBalance(string balanceValue)
	{
		if(balanceValue == ".00")
		{
			balance_label_UIL.text = "0";
			print ("equal to null");
		}
		else
		{
			balance_label_UIL.text = balanceValue;
			print ("not equal to null");
			print (balanceValue);
		}
	}

	void RewriteBet(string betValue)
	{
		bet_label_UIL.text = betValue;
	}

	void RewriteAutospinCounter()
	{
		spin_counter_label_UIL.text = "" + autospinNO;
	}

	public void PlayingBonusGame()
	{
		bonusGame = true;
	}

	private void PlayAnimationOnMatch(bool left, bool m_left, bool middle, bool m_right, bool right)
	{
		if(left)
		{
			left_animation.SetActive(true);
		}
		if(m_left)
		{
			m_left_animation.SetActive(true);
		}
		if(middle)
		{
			middle_animation.SetActive(true);
		}
		if(m_right)
		{
			m_right_animation.SetActive(true);
		}
		if(right)
		{
			right_animation.SetActive(true);
		}
	}

	public void CreditBought (int amount)
	{
		Debug.Log ("CREDIT BOUGHT IS CALLED AND RUNNING");
		def_balance_value = def_balance_value + amount;
		if(def_balance_value > PlayerPrefs.GetInt ("balance"))
		{
			Debug.Log ("INSIDE IF BALANCE STATEMENT");
			gameCenter.ReportScore(def_balance_value);
		}
		Debug.Log ("OUTSIDE OF BALANCE IF STATEMENT");
		PlayerPrefs.SetInt("balance", def_balance_value);
		Debug.Log ("PLAYERPREFS IS SET");
		RewriteBalance("" + def_balance_value.ToString("#"));
		Debug.Log ("BALANCE SHOULD BE REWRITTEN");
	}

	public void WinAdvertAllowance()
	{
		winCount++;

		//Debug.LogError ("winCount is + " + winCount.ToString());
		if(winCount >= 3)
		{
			showAd1 = true;
			winCount = 0;
			//Debug.LogError ("Should display add");
		}
	}

	public void BigWinAdvertAllowance()
	{
		bigWinCount++;
		
		if (bigWinCount >= 3) 
		{
			showAd1 = true;
			showAd2 = true;
			bigWinCount = 0;
		} 
		else 
		{
			WinAdvertAllowance();
		}
	}
}
