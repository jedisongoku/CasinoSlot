using UnityEngine;
using System.Collections;

public class Level_System : MonoBehaviour 
{
	public GameObject all_reels;
	public GameObject buyCoinsOffer;
	public GameObject darkbackground;
	private bool canDisplayOffer = false;

	public UILabel level_badge;
	public UILabel level_rank;
	public UISlider level_slider;

	public string levels_1_to_9;
	public string levels_10_to_19;
	public string levels_20_to_29;
	public string levels_30_to_39;
	public string levels_40_to_49;
	public string levels_50_to_59;
	public string levels_60_to_69;
	public string level_70_etc;

	private int levelPlaying;
	private int currentLevelCounter;
	private int nextAchievementCompare;
	private int lastAchievementCompare;
	private int level_achievement_2 = 500;
	private int level_achievement_3 = 1000;
	private int level_achievement_4 = 2000;
	private int level_achievement_5 = 3000;
	private int level_achievement_6 = 4000;
	private int level_achievement_7 = 5000;
	private int level_achievement_8 = 6500;
	private int level_achievement_9 = 8000;
	private int level_achievement_10 = 10000;
	private int level_achievement_11 = 12500;
	private int level_achievement_12 = 15000;
	private int level_achievement_13 = 17500;
	private int level_achievement_14 = 20000;
	private int level_achievement_15 = 25000;
	private int level_achievement_16 = 30000;
	private int level_achievement_17 = 35000;
	private int level_achievement_18 = 40000;
	private int level_achievement_19 = 45000;
	private int level_achievement_20 = 50000;
	private int level_achievement_21 = 55000;
	private int level_achievement_22 = 60000;
	private int level_achievement_23 = 65000;
	private int level_achievement_24 = 70000;
	private int level_achievement_25 = 75000;
	private int level_achievement_26 = 80000;
	private int level_achievement_27 = 85000;
	private int level_achievement_28 = 90000;
	private int level_achievement_29 = 95000;
	private int level_achievement_30 = 100000;
	private int level_achievement_31 = 110000;
	private int level_achievement_32 = 120000;
	private int level_achievement_33 = 130000;
	private int level_achievement_34 = 140000;
	private int level_achievement_35 = 150000;
	private int level_achievement_36 = 160000;
	private int level_achievement_37 = 180000;
	private int level_achievement_38 = 200000;
	private int level_achievement_39 = 225000;
	private int level_achievement_40 = 250000;
	private int level_achievement_41 = 260000;
	private int level_achievement_42 = 275000;
	private int level_achievement_43 = 300000;
	private int level_achievement_44 = 325000;
	private int level_achievement_45 = 350000;
	private int level_achievement_46 = 375000;
	private int level_achievement_47 = 400000;
	private int level_achievement_48 = 425000;
	private int level_achievement_49 = 450000;
	private int level_achievement_50 = 500000;
	private int level_achievement_51 = 525000;
	private int level_achievement_52 = 550000;
	private int level_achievement_53 = 575000;
	private int level_achievement_54 = 600000;
	private int level_achievement_55 = 625000;
	private int level_achievement_56 = 650000;
	private int level_achievement_57 = 675000;
	private int level_achievement_58 = 700000;
	private int level_achievement_59 = 725000;
	private int level_achievement_60 = 750000;
	private int level_achievement_61 = 775000;
	private int level_achievement_62 = 800000;
	private int level_achievement_63 = 825000;
	private int level_achievement_64 = 850000;
	private int level_achievement_65 = 875000;
	private int level_achievement_66 = 900000;
	private int level_achievement_67 = 925000;
	private int level_achievement_68 = 950000;
	private int level_achievement_69 = 975000;
	private int level_achievement_70 = 1000000;

	private bool level_2;
	private bool level_3;
	private bool level_4;
	private bool level_5;
	private bool level_6;
	private bool level_7;
	private bool level_8;
	private bool level_9;
	private bool level_10;
	private bool level_11;
	private bool level_12;
	private bool level_13;
	private bool level_14;
	private bool level_15;
	private bool level_16;
	private bool level_17;
	private bool level_18;
	private bool level_19;
	private bool level_20;
	private bool level_21;
	private bool level_22;
	private bool level_23;
	private bool level_24;
	private bool level_25;
	private bool level_26;
	private bool level_27;
	private bool level_28;
	private bool level_29;
	private bool level_30;
	private bool level_31;
	private bool level_32;
	private bool level_33;
	private bool level_34;
	private bool level_35;
	private bool level_36;
	private bool level_37;
	private bool level_38;
	private bool level_39;
	private bool level_40;
	private bool level_41;
	private bool level_42;
	private bool level_43;
	private bool level_44;
	private bool level_45;
	private bool level_46;
	private bool level_47;
	private bool level_48;
	private bool level_49;
	private bool level_50;
	private bool level_51;
	private bool level_52;
	private bool level_53;
	private bool level_54;
	private bool level_55;
	private bool level_56;
	private bool level_57;
	private bool level_58;
	private bool level_59;
	private bool level_60;
	private bool level_61;
	private bool level_62;
	private bool level_63;
	private bool level_64;
	private bool level_65;
	private bool level_66;
	private bool level_67;
	private bool level_68;
	private bool level_69;
	private bool level_70;

	private Slot_Machine_System slot_system;

	#region Enable/Disable
	
	void OnEnable ()
	{
		Slot_Machine_System.CoinOffer += ActivateCoinOfferCheck;
	}
	
	void OnDisable ()
	{
		Slot_Machine_System.CoinOffer -= ActivateCoinOfferCheck;
	}
	
	#endregion

	void Start()
	{
		slot_system = all_reels.GetComponent<Slot_Machine_System>();

		currentLevelCounter = PlayerPrefs.GetInt ("levelCounter");
		lastAchievementCompare = PlayerPrefs.GetInt ("LastAchievementCompare", 0);
		nextAchievementCompare = PlayerPrefs.GetInt ("NextAchievementCompare", level_achievement_2);
		levelPlaying = PlayerPrefs.GetInt("level playing", 1);

		level_badge.text = levelPlaying.ToString();
		level_slider.value = ((float)currentLevelCounter - (float)lastAchievementCompare) / ((float)nextAchievementCompare  - (float)lastAchievementCompare);

		string currentPrefs = PlayerPrefs.GetString("Level Rank", "not saved yet");

		if(currentPrefs == "70-etc")
		{
			level_rank.text = level_70_etc;
		}
		else if(currentPrefs == "60-69")
		{
			level_rank.text = levels_60_to_69;
		}
		else if(currentPrefs == "50-59")
		{
			level_rank.text = levels_50_to_59;
		}
		else if(currentPrefs == "40-49")
		{
			level_rank.text = levels_40_to_49;
		}
		else if(currentPrefs == "30-39")
		{
			level_rank.text = levels_30_to_39;
		}
		else if(currentPrefs == "20-29")
		{
			level_rank.text = levels_20_to_29;
		}
		else if(currentPrefs == "10-19")
		{
			level_rank.text = levels_10_to_19;
		}
		else if(currentPrefs == "not saved yet")
		{
			level_rank.text = levels_1_to_9;
		}
	}
	
	public void CheckLevelAchievement()
	{
		currentLevelCounter = PlayerPrefs.GetInt ("levelCounter");
		Debug.Log (currentLevelCounter + " value of level counter");

		if(!level_2 && currentLevelCounter >= level_achievement_2 && currentLevelCounter < level_achievement_3)
		{
				//canDisplayOffer = false;
				level_badge.text = "2";
				//GA.API.Design.NewEvent("Level_Achievement:Level_2");
				level_2 = true;
				levelPlaying = 2;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_2);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_3); 
		}
		else if(!level_3 && currentLevelCounter >= level_achievement_3 && currentLevelCounter < level_achievement_4)
		{	
				level_badge.text = "3";
				//GA.API.Design.NewEvent("Level_Achievement:Level_3");
				level_3 = true;
				levelPlaying = 3;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_3);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_4);
		}
		else if(!level_4 && currentLevelCounter >= level_achievement_4 && currentLevelCounter < level_achievement_5)
		{
				//canDisplayOffer = false;
				level_badge.text = "4";
				//GA.API.Design.NewEvent("Level_Achievement:Level_4");
				level_4 = true;
				levelPlaying = 4;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_4);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_5);
		}
		else if(!level_5 && currentLevelCounter >= level_achievement_5 && currentLevelCounter < level_achievement_6)
		{
				level_badge.text = "5";
				//GA.API.Design.NewEvent("Level_Achievement:Level_5");
				level_5 = true;
				levelPlaying = 5;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_5);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_6); 
		}
		else if(!level_6 && currentLevelCounter >= level_achievement_6 && currentLevelCounter < level_achievement_7)
		{
				//canDisplayOffer = false;
				level_badge.text = "6";
				//GA.API.Design.NewEvent("Level_Achievement:Level_6");
				level_6 = true;
				levelPlaying = 6;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_6);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_7);
		}
		else if(!level_7 && currentLevelCounter >= level_achievement_7 && currentLevelCounter < level_achievement_8)
		{
				level_badge.text = "7";
				//GA.API.Design.NewEvent("Level_Achievement:Level_7");
				level_7 = true;
				levelPlaying = 7;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_7);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_8);
		}
		else if(!level_8 && currentLevelCounter >= level_achievement_8 && currentLevelCounter < level_achievement_9)
		{
				//canDisplayOffer = false;
				level_badge.text = "8";
				//GA.API.Design.NewEvent("Level_Achievement:Level_8");
				level_8 = true;
				levelPlaying = 8;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_8);
		}
		else if(!level_9 && currentLevelCounter >= level_achievement_9 && currentLevelCounter < level_achievement_10)
		{
				level_badge.text = "9";
				//GA.API.Design.NewEvent("Level_Achievement:Level_9");
				level_9 = true;
				levelPlaying = 9;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_9);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_10); 
		}
		else if(!level_10 && currentLevelCounter >= level_achievement_10 && currentLevelCounter < level_achievement_11)
		{
				//canDisplayOffer = false;
				level_badge.text = "10";
				level_rank.text = levels_10_to_19;
				PlayerPrefs.SetString ("Level Rank", "10-19");
				//GA.API.Design.NewEvent("Level_Achievement:Level_10");
				level_10 = true;
				levelPlaying = 10;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_10);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_11);
		}
		else if(!level_11 && currentLevelCounter >= level_achievement_11 && currentLevelCounter < level_achievement_12)
		{
				level_badge.text = "11";
				//GA.API.Design.NewEvent("Level_Achievement:Level_11");
				level_11 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_11);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_12); 
		}
		else if(!level_12 && currentLevelCounter >= level_achievement_12 && currentLevelCounter < level_achievement_13)
		{
				//canDisplayOffer = false;
				level_badge.text = "12";
				//GA.API.Design.NewEvent("Level_Achievement:Level_12");
				level_12 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_12);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_13); 
		}
		else if(!level_13 && currentLevelCounter >= level_achievement_13 && currentLevelCounter < level_achievement_14)
		{
				//canDisplayOffer = false;
				level_badge.text = "13";
				//GA.API.Design.NewEvent("Level_Achievement:Level_13");
				level_13 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_13);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_14);  
		}
		else if(!level_14 && currentLevelCounter >= level_achievement_14 && currentLevelCounter < level_achievement_15)
		{
				//canDisplayOffer = false;
				level_badge.text = "14";
				//GA.API.Design.NewEvent("Level_Achievement:Level_14");
				level_14 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_14);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_15);
		}
		else if(!level_15 && currentLevelCounter >= level_achievement_15 && currentLevelCounter < level_achievement_16)
		{
				//canDisplayOffer = false;
				level_badge.text = "15";
				//GA.API.Design.NewEvent("Level_Achievement:Level_15");
				level_15 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_15);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_16);
		}
		else if(!level_16 && currentLevelCounter >= level_achievement_16 && currentLevelCounter < level_achievement_17)
		{
				//canDisplayOffer = false;
				level_badge.text = "16";
				//GA.API.Design.NewEvent("Level_Achievement:Level_16");
				level_16 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_16);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_17);
		}
		else if(!level_17 && currentLevelCounter >= level_achievement_17 && currentLevelCounter < level_achievement_18)
		{
				//canDisplayOffer = false;
				level_badge.text = "17";
				//GA.API.Design.NewEvent("Level_Achievement:Level_17");
				level_17 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_17);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_18);
		}
		else if(!level_18 && currentLevelCounter >= level_achievement_18 && currentLevelCounter < level_achievement_19)
		{
				//canDisplayOffer = false;
				level_badge.text = "18";
				//GA.API.Design.NewEvent("Level_Achievement:Level_18");
				level_18 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_18);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_19);
		}
		else if(!level_19 && currentLevelCounter >= level_achievement_19 && currentLevelCounter < level_achievement_20)
		{
				//canDisplayOffer = false;
				level_badge.text = "19";
				//GA.API.Design.NewEvent("Level_Achievement:Level_19");
				level_19 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_19);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_20);
		}
		else if(!level_20 && currentLevelCounter >= level_achievement_20 && currentLevelCounter < level_achievement_21)
		{
				//canDisplayOffer = false;
				level_badge.text = "20";
				level_rank.text = levels_20_to_29;
				PlayerPrefs.SetString ("Level Rank", "20-29");
				//GA.API.Design.NewEvent("Level_Achievement:Level_20");
				level_20 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_20);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_21);
		}
		else if(!level_21 && currentLevelCounter >= level_achievement_21 && currentLevelCounter < level_achievement_22)
		{
			canDisplayOffer = false;
				level_badge.text = "21";
				//GA.API.Design.NewEvent("Level_Achievement:Level_21");
				level_21 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_21);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_22);  
		}
		else if(!level_22 && currentLevelCounter >= level_achievement_22 && currentLevelCounter < level_achievement_23)
		{
			canDisplayOffer = false;
				level_badge.text = "22";
				//GA.API.Design.NewEvent("Level_Achievement:Level_22");
				level_22 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_22);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_23);
		}
		else if(!level_23 &&currentLevelCounter >= level_achievement_23 && currentLevelCounter < level_achievement_24)
		{
			canDisplayOffer = false;
				level_badge.text = "23";
				//GA.API.Design.NewEvent("Level_Achievement:Level_23");
				level_23 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_23);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_24);  
		}
		else if(!level_24 && currentLevelCounter >= level_achievement_24 && currentLevelCounter < level_achievement_25)
		{
			canDisplayOffer = false;
				level_badge.text = "24";
				//GA.API.Design.NewEvent("Level_Achievement:Level_24");
				level_24 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_24);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_25);
		}
		else if(!level_25 && currentLevelCounter >= level_achievement_25 && currentLevelCounter < level_achievement_26)
		{
			canDisplayOffer = false;
				level_badge.text = "25";
				//GA.API.Design.NewEvent("Level_Achievement:Level_25");
				level_25 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_25);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_26);
		}
		else if(!level_26 && currentLevelCounter >= level_achievement_26 && currentLevelCounter < level_achievement_27)
		{
			canDisplayOffer = false;
				level_badge.text = "26";
				//GA.API.Design.NewEvent("Level_Achievement:Level_26");
				level_26 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_26);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_27);
		}
		else if(!level_27 && currentLevelCounter >= level_achievement_27 && currentLevelCounter < level_achievement_28)
		{
			canDisplayOffer = false;
				level_badge.text = "27";
				//GA.API.Design.NewEvent("Level_Achievement:Level_27");
				level_27 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_27);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_28); 
		}
		else if(!level_28 && currentLevelCounter >= level_achievement_28 && currentLevelCounter < level_achievement_29)
		{
			canDisplayOffer = false;
				level_badge.text = "28";
				//GA.API.Design.NewEvent("Level_Achievement:Level_28");
				level_28 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_28);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_29);
		}
		else if(!level_29 && currentLevelCounter >= level_achievement_29 && currentLevelCounter < level_achievement_30)
		{
			canDisplayOffer = false;
				level_badge.text = "29";
				//GA.API.Design.NewEvent("Level_Achievement:Level_29");
				level_29 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_29);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_30); 
		}
		else if(!level_30 && currentLevelCounter >= level_achievement_30 && currentLevelCounter < level_achievement_31)
		{
			canDisplayOffer = false;
				level_badge.text = "30";
				level_rank.text = levels_30_to_39;
				PlayerPrefs.SetString ("Level Rank", "30-39");
				//GA.API.Design.NewEvent("Level_Achievement:Level_30");
				level_30 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_30);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_31); 
		}
		else if(!level_31 && currentLevelCounter >= level_achievement_31 && currentLevelCounter < level_achievement_32)
		{
			canDisplayOffer = false;
				level_badge.text = "31";
				//GA.API.Design.NewEvent("Level_Achievement:Level_31");
				level_31 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_31);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_32);
		}
		else if(!level_32 && currentLevelCounter >= level_achievement_32 && currentLevelCounter < level_achievement_33)
		{
			canDisplayOffer = false;
				level_badge.text = "32";
				//GA.API.Design.NewEvent("Level_Achievement:Level_32");
				level_32 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_32);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_33); 
		}
		else if(!level_33 && currentLevelCounter >= level_achievement_33 && currentLevelCounter < level_achievement_34)
		{
			canDisplayOffer = false;
				level_badge.text = "33";
				//GA.API.Design.NewEvent("Level_Achievement:Level_33");
				level_33 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_33);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_34);
		}
		else if(!level_34 && currentLevelCounter >= level_achievement_34 && currentLevelCounter < level_achievement_35)
		{
			canDisplayOffer = false;
				level_badge.text = "34";
				//GA.API.Design.NewEvent("Level_Achievement:Level_34");
				level_34 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_34);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_35); 
		}
		else if(!level_35 && currentLevelCounter >= level_achievement_35 && currentLevelCounter < level_achievement_36)
		{
			canDisplayOffer = false;
				level_badge.text = "35";
				//GA.API.Design.NewEvent("Level_Achievement:Level_35");
				level_35 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_35);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_36); 
		}
		else if(!level_36 && currentLevelCounter >= level_achievement_36 && currentLevelCounter < level_achievement_37)
		{
			canDisplayOffer = false;
				level_badge.text = "36";
				//GA.API.Design.NewEvent("Level_Achievement:Level_36");
				level_36 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_36);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_37); 
		}
		else if(!level_37 && currentLevelCounter >= level_achievement_37 && currentLevelCounter < level_achievement_38)
		{
			canDisplayOffer = false;
				level_badge.text = "37";
				//GA.API.Design.NewEvent("Level_Achievement:Level_37");
				level_37 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_37);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_38); 
		}
		else if(!level_38 && currentLevelCounter >= level_achievement_38 && currentLevelCounter < level_achievement_39)
		{
			canDisplayOffer = false;
				level_badge.text = "38";
				//GA.API.Design.NewEvent("Level_Achievement:Level_38");
				level_38 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_38);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_39);  
		}
		else if(!level_39 && currentLevelCounter >= level_achievement_39 && currentLevelCounter < level_achievement_40)
		{
			canDisplayOffer = false;
				level_badge.text = "39";
				//GA.API.Design.NewEvent("Level_Achievement:Level_39");
				level_39 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_39);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_40);  
		}
		else if(!level_40 && currentLevelCounter >= level_achievement_40 && currentLevelCounter < level_achievement_41)
		{
			canDisplayOffer = false;
				level_badge.text = "40";
				level_rank.text = levels_40_to_49;
				PlayerPrefs.SetString ("Level Rank", "40-49");
				//GA.API.Design.NewEvent("Level_Achievement:Level_40");
				level_40 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_40);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_41); 
		}
		else if(!level_41 && currentLevelCounter >= level_achievement_41 && currentLevelCounter < level_achievement_42)
		{
			canDisplayOffer = false;
				level_badge.text = "41";
				//GA.API.Design.NewEvent("Level_Achievement:Level_41");
				level_41 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_41);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_42);
		}
		else if(!level_42 && currentLevelCounter >= level_achievement_42 && currentLevelCounter < level_achievement_43)
		{
			canDisplayOffer = false;
				level_badge.text = "42";
				//GA.API.Design.NewEvent("Level_Achievement:Level_42");
				level_42 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_42);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_43);  
		}
		else if(!level_43 && currentLevelCounter >= level_achievement_43 && currentLevelCounter < level_achievement_44)
		{
				level_badge.text = "43";
				//GA.API.Design.NewEvent("Level_Achievement:Level_43");
				level_43 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_43);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_44); 
		}
		else if(!level_44 && currentLevelCounter >= level_achievement_44 && currentLevelCounter < level_achievement_45)
		{
			canDisplayOffer = false;
				level_badge.text = "44";
				//GA.API.Design.NewEvent("Level_Achievement:Level_44");
				level_44 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_44);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_45);  
		}
		else if(!level_45 && currentLevelCounter >= level_achievement_45 && currentLevelCounter < level_achievement_46)
		{
			canDisplayOffer = false;
				level_badge.text = "45";
				//GA.API.Design.NewEvent("Level_Achievement:Level_45");
				level_45 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_45);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_46);  
		}
		else if(!level_46 && currentLevelCounter >= level_achievement_46 && currentLevelCounter < level_achievement_47)
		{
			canDisplayOffer = false;
				level_badge.text = "46";
				//GA.API.Design.NewEvent("Level_Achievement:Level_46");
				level_46 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_46);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_47); 
		}
		else if(!level_47 && currentLevelCounter >= level_achievement_47 && currentLevelCounter < level_achievement_48)
		{
			canDisplayOffer = false;
				level_badge.text = "47";
				//GA.API.Design.NewEvent("Level_Achievement:Level_47");
				level_47 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_47);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_48);  
		}
		else if(!level_48 && currentLevelCounter >= level_achievement_48 && currentLevelCounter < level_achievement_49)
		{
			canDisplayOffer = false;
				level_badge.text = "48";
				//GA.API.Design.NewEvent("Level_Achievement:Level_48");
				level_48 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_48);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_49);  
		}
		else if(!level_49 && currentLevelCounter >= level_achievement_49 && currentLevelCounter < level_achievement_50)
		{
			canDisplayOffer = false;
				level_badge.text = "49";
				//GA.API.Design.NewEvent("Level_Achievement:Level_49");
				level_49 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_49);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_50);  
		}
		else if(!level_50 && currentLevelCounter >= level_achievement_50 && currentLevelCounter < level_achievement_51)
		{
			canDisplayOffer = false;
				level_badge.text = "50";
				level_rank.text = levels_50_to_59;
				PlayerPrefs.SetString ("Level Rank", "50-59");
				//GA.API.Design.NewEvent("Level_Achievement:Level_50");
				level_50 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_50);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_51); 
		}
		else if(!level_51 && currentLevelCounter >= level_achievement_51 && currentLevelCounter < level_achievement_52)
		{
			canDisplayOffer = false;
				level_badge.text = "51";
				//GA.API.Design.NewEvent("Level_Achievement:Level_51");
				level_51 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_51);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_52); 
		}
		else if(!level_52 && currentLevelCounter >= level_achievement_52 && currentLevelCounter < level_achievement_53)
		{
			canDisplayOffer = false;
				level_badge.text = "52";
				//GA.API.Design.NewEvent("Level_Achievement:Level_52");
				level_52 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_52);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_53); 
		}
		else if(!level_53 && currentLevelCounter >= level_achievement_53 && currentLevelCounter < level_achievement_54)
		{
			canDisplayOffer = false;
				level_badge.text = "53";
				//GA.API.Design.NewEvent("Level_Achievement:Level_53");
				level_53 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_53);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_54); 
		}
		else if(!level_54 && currentLevelCounter >= level_achievement_54 && currentLevelCounter < level_achievement_55)
		{
			canDisplayOffer = false;
				level_badge.text = "54";
				//GA.API.Design.NewEvent("Level_Achievement:Level_54");
				level_54 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_54);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_55); 
		}
		else if(!level_55 && currentLevelCounter >= level_achievement_55 && currentLevelCounter < level_achievement_56)
		{
			canDisplayOffer = false;
				level_badge.text = "55";
				//GA.API.Design.NewEvent("Level_Achievement:Level_55");
				level_55 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_55);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_56);  
		}
		else if(!level_56 && currentLevelCounter >= level_achievement_56 && currentLevelCounter < level_achievement_57)
		{
			canDisplayOffer = false;
				level_badge.text = "56";
				//GA.API.Design.NewEvent("Level_Achievement:Level_56");
				level_56 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_56);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_57);  
		}
		else if(!level_57 && currentLevelCounter >= level_achievement_57 && currentLevelCounter < level_achievement_58)
		{
			canDisplayOffer = false;
				level_badge.text = "57";
				//GA.API.Design.NewEvent("Level_Achievement:Level_57");
				level_57 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_57);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_58); 
		}
		else if(!level_58 && currentLevelCounter >= level_achievement_58 && currentLevelCounter < level_achievement_59)
		{
			canDisplayOffer = false;
				level_badge.text = "58";
				//GA.API.Design.NewEvent("Level_Achievement:Level_58");
				level_58 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_58);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_59);  
		}
		else if(!level_59 && currentLevelCounter >= level_achievement_59 && currentLevelCounter < level_achievement_60)
		{
			canDisplayOffer = false;
				level_badge.text = "59";
				//GA.API.Design.NewEvent("Level_Achievement:Level_59");
				level_59 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_59);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_60);  
		}
		else if(!level_60 && currentLevelCounter >= level_achievement_60 && currentLevelCounter < level_achievement_61)
		{
			canDisplayOffer = false;
				level_badge.text = "60";
				level_rank.text = levels_60_to_69;
				PlayerPrefs.SetString ("Level Rank", "60-69");
				//GA.API.Design.NewEvent("Level_Achievement:Level_60");
				level_60 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_60);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_61); 
		}
		else if(!level_61 && currentLevelCounter >= level_achievement_61 && currentLevelCounter < level_achievement_62)
		{
			canDisplayOffer = false;
				level_badge.text = "61";
				//GA.API.Design.NewEvent("Level_Achievement:Level_61");
				level_61 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_61);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_62); 
		}
		else if(!level_62 && currentLevelCounter >= level_achievement_62 && currentLevelCounter < level_achievement_63)
		{
			canDisplayOffer = false;
				level_badge.text = "62";
				//GA.API.Design.NewEvent("Level_Achievement:Level_62");
				level_62 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_62);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_63);  
		}
		else if(!level_63 && currentLevelCounter >= level_achievement_63 && currentLevelCounter < level_achievement_64)
		{
			canDisplayOffer = false;
				level_badge.text = "63";
				//GA.API.Design.NewEvent("Level_Achievement:Level_63");
				level_63 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_63);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_64);  
		}
		else if(!level_64 && currentLevelCounter >= level_achievement_64 && currentLevelCounter < level_achievement_65)
		{
			canDisplayOffer = false;
				level_badge.text = "64";
				//GA.API.Design.NewEvent("Level_Achievement:Level_64");
				level_64 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_64);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_65);  
		}
		else if(!level_65 && currentLevelCounter >= level_achievement_65 && currentLevelCounter < level_achievement_66)
		{
			canDisplayOffer = false;
				level_badge.text = "65";
				//GA.API.Design.NewEvent("Level_Achievement:Level_65");
				level_65 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_65);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_66);
		}
		else if(!level_66 && currentLevelCounter >= level_achievement_66 && currentLevelCounter < level_achievement_67)
		{
			canDisplayOffer = false;
				level_badge.text = "66";
				//GA.API.Design.NewEvent("Level_Achievement:Level_66");
				level_66 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_66);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_67); 
		}
		else if(!level_67 && currentLevelCounter >= level_achievement_67 && currentLevelCounter < level_achievement_68)
		{
			canDisplayOffer = false;
				level_badge.text = "67";
				//GA.API.Design.NewEvent("Level_Achievement:Level_67");
				level_67 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_67);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_68); 
		}
		else if(!level_68 && currentLevelCounter >= level_achievement_68 && currentLevelCounter < level_achievement_69)
		{
			canDisplayOffer = false;
				level_badge.text = "68";
				//GA.API.Design.NewEvent("Level_Achievement:Level_68");
				level_68 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_68);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_69);  
		}
		else if(!level_69 && currentLevelCounter >= level_achievement_69 && currentLevelCounter < level_achievement_70)
		{
			canDisplayOffer = false;
				level_badge.text = "69";
				//GA.API.Design.NewEvent("Level_Achievement:Level_69");
				level_69 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_69);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_70);  
		}
		else if(!level_70 && currentLevelCounter >= level_achievement_70)
		{
			canDisplayOffer = false;
				level_badge.text = "70";
				level_rank.text = level_70_etc;
				PlayerPrefs.SetString ("Level Rank", "70-etc");
				//GA.API.Design.NewEvent("Level_Achievement:Level_70");
				level_70 = true;
				levelPlaying++;
				PlayerPrefs.SetInt("level playing", levelPlaying);
				PlayerPrefs.SetInt ("LastAchievementCompare", level_achievement_70);
				PlayerPrefs.SetInt ("NextAchievementCompare", level_achievement_70);  
		}
	}

	public void MoveLevelProgressBar()
	{
		switch(levelPlaying)
		{
		case 1:
			level_slider.value = (float)currentLevelCounter / (float)level_achievement_2;
			Debug.Log ("CASE 1 + " + level_slider.value);
			break;
		case 2:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_2) / ((float)level_achievement_3 - (float)level_achievement_2);
			Debug.Log ("CASE 2 + " + level_slider.value);
			break;
		case 3:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_3) / ((float)level_achievement_4 - (float)level_achievement_3);
			Debug.Log ("CASE 3 + " + level_slider.value);
			break;
		case 4:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_4) / ((float)level_achievement_5 - (float)level_achievement_4);
			Debug.Log ("CASE 4 + " + level_slider.value);
			break;
		case 5:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_5) / ((float)level_achievement_6 - (float)level_achievement_5);
			Debug.Log ("CASE 5 + " + level_slider.value);
			break;
		case 6:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_6) / ((float)level_achievement_7 - (float)level_achievement_6);
			Debug.Log ("CASE 6 + " + level_slider.value);
			break;
		case 7:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_7) / ((float)level_achievement_8 - (float)level_achievement_7);
			Debug.Log ("CASE 7 + " + level_slider.value);
			break;
		case 8:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_8) / ((float)level_achievement_9 - (float)level_achievement_8);
			Debug.Log ("CASE 8 + " + level_slider.value);
			break;
		case 9:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_9) / ((float)level_achievement_10 - (float)level_achievement_9);
			Debug.Log ("CASE 9 + " + level_slider.value);
			break;
		case 10:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_10) / ((float)level_achievement_11 - (float)level_achievement_10);
			Debug.Log ("CASE 10 + " + level_slider.value);
			break;
		case 11:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_11) / ((float)level_achievement_12 - (float)level_achievement_11);
			Debug.Log ("CASE 11 + " + level_slider.value);
			break;
		case 12:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_12) / ((float)level_achievement_13 - (float)level_achievement_12);
			Debug.Log ("CASE 12 + " + level_slider.value);
			break;
		case 13:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_13) / ((float)level_achievement_14 - (float)level_achievement_13);
			Debug.Log ("CASE 13 + " + level_slider.value);
			break;
		case 14:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_14) / ((float)level_achievement_15 - (float)level_achievement_14);
			Debug.Log ("CASE 14 + " + level_slider.value);
			break;
		case 15:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_15) / ((float)level_achievement_16 - (float)level_achievement_15);
			Debug.Log ("CASE 15 + " + level_slider.value);
			break;
		case 16:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_16) / ((float)level_achievement_17 - (float)level_achievement_16);
			Debug.Log ("CASE 16 + " + level_slider.value);
			break;
		case 17:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_17) / ((float)level_achievement_18 - (float)level_achievement_17);
			Debug.Log ("CASE 17 + " + level_slider.value);
			break;
		case 18:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_18) / ((float)level_achievement_19 - (float)level_achievement_18);
			Debug.Log ("CASE 18 + " + level_slider.value);
			break;
		case 19:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_19) / ((float)level_achievement_20 - (float)level_achievement_19);
			Debug.Log ("CASE 19 + " + level_slider.value);
			break;
		case 20:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_20) / ((float)level_achievement_21 - (float)level_achievement_20);
			Debug.Log ("CASE 20 + " + level_slider.value);
			break;
		case 21:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_21) / ((float)level_achievement_22 - (float)level_achievement_21);
			Debug.Log ("CASE 21 + " + level_slider.value);
			break;
		case 22:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_22) / ((float)level_achievement_23 - (float)level_achievement_22);
			Debug.Log ("CASE 22 + " + level_slider.value);
			break;
		case 23:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_23) / ((float)level_achievement_24 - (float)level_achievement_23);
			Debug.Log ("CASE 23 + " + level_slider.value);
			break;
		case 24:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_24) / ((float)level_achievement_25 - (float)level_achievement_24);
			Debug.Log ("CASE 24 + " + level_slider.value);
			break;
		case 25:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_25) / ((float)level_achievement_26 - (float)level_achievement_25);
			Debug.Log ("CASE 25 + " + level_slider.value);
			break;
		case 26:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_26) / ((float)level_achievement_27 - (float)level_achievement_26);
			Debug.Log ("CASE 26 + " + level_slider.value);
			break;
		case 27:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_27) / ((float)level_achievement_28 - (float)level_achievement_27);
			Debug.Log ("CASE 27 + " + level_slider.value);
			break;
		case 28:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_28) / ((float)level_achievement_29 - (float)level_achievement_28);
			Debug.Log ("CASE 28 + " + level_slider.value);
			break;
		case 29:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_29) / ((float)level_achievement_30 - (float)level_achievement_29);
			Debug.Log ("CASE 29 + " + level_slider.value);
			break;
		case 30:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_30) / ((float)level_achievement_31 - (float)level_achievement_30);
			Debug.Log ("CASE 30 + " + level_slider.value);
			break;
		case 31:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_31) / ((float)level_achievement_32 - (float)level_achievement_31);
			Debug.Log ("CASE 31 + " + level_slider.value);
			break;
		case 32:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_32) / ((float)level_achievement_33 - (float)level_achievement_32);
			Debug.Log ("CASE 32 + " + level_slider.value);
			break;
		case 33:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_33) / ((float)level_achievement_34 - (float)level_achievement_33);
			Debug.Log ("CASE 33 + " + level_slider.value);
			break;
		case 34:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_34) / ((float)level_achievement_35 - (float)level_achievement_34);
			Debug.Log ("CASE 34 + " + level_slider.value);
			break;
		case 35:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_35) / ((float)level_achievement_36 - (float)level_achievement_35);
			Debug.Log ("CASE 35 + " + level_slider.value);
			break;
		case 36:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_36) / ((float)level_achievement_37 - (float)level_achievement_36);
			Debug.Log ("CASE 36 + " + level_slider.value);
			break;
		case 37:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_37) / ((float)level_achievement_38 - (float)level_achievement_37);
			Debug.Log ("CASE 37 + " + level_slider.value);
			break;
		case 38:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_38) / ((float)level_achievement_39 - (float)level_achievement_38);
			Debug.Log ("CASE 38 + " + level_slider.value);
			break;
		case 39:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_39) / ((float)level_achievement_40 - (float)level_achievement_39);
			Debug.Log ("CASE 39 + " + level_slider.value);
			break;
		case 40:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_40) / ((float)level_achievement_41 - (float)level_achievement_40);
			Debug.Log ("CASE 40 + " + level_slider.value);
			break;
		case 41:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_41) / ((float)level_achievement_42 - (float)level_achievement_41);
			Debug.Log ("CASE 41 + " + level_slider.value);
			break;
		case 42:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_42) / ((float)level_achievement_43 - (float)level_achievement_42);
			Debug.Log ("CASE 42 + " + level_slider.value);
			break;
		case 43:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_43) / ((float)level_achievement_44 - (float)level_achievement_43);
			Debug.Log ("CASE 43 + " + level_slider.value);
			break;
		case 44:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_44) / ((float)level_achievement_45 - (float)level_achievement_44);
			Debug.Log ("CASE 44 + " + level_slider.value);
			break;
		case 45:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_45) / ((float)level_achievement_46 - (float)level_achievement_45);
			Debug.Log ("CASE 45 + " + level_slider.value);
			break;
		case 46:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_46) / ((float)level_achievement_47 - (float)level_achievement_46);
			Debug.Log ("CASE 46 + " + level_slider.value);
			break;
		case 47:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_47) / ((float)level_achievement_48 - (float)level_achievement_47);
			Debug.Log ("CASE 47 + " + level_slider.value);
			break;
		case 48:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_48) / ((float)level_achievement_49 - (float)level_achievement_48);
			Debug.Log ("CASE 48 + " + level_slider.value);
			break;
		case 49:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_49) / ((float)level_achievement_50 - (float)level_achievement_49);
			Debug.Log ("CASE 49 + " + level_slider.value);
			break;
		case 50:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_50) / ((float)level_achievement_51 - (float)level_achievement_50);
			Debug.Log ("CASE 50 + " + level_slider.value);
			break;
		case 51:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_51) / ((float)level_achievement_52 - (float)level_achievement_51);
			Debug.Log ("CASE 51 + " + level_slider.value);
			break;
		case 52:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_52) / ((float)level_achievement_53 - (float)level_achievement_52);
			Debug.Log ("CASE 52 + " + level_slider.value);
			break;
		case 53:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_53) / ((float)level_achievement_54 - (float)level_achievement_53);
			Debug.Log ("CASE 53 + " + level_slider.value);
			break;
		case 54:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_54) / ((float)level_achievement_55 - (float)level_achievement_54);
			Debug.Log ("CASE 54 + " + level_slider.value);
			break;
		case 55:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_55) / ((float)level_achievement_56 - (float)level_achievement_55);
			Debug.Log ("CASE 55 + " + level_slider.value);
			break;
		case 56:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_56) / ((float)level_achievement_57 - (float)level_achievement_56);
			Debug.Log ("CASE 56 + " + level_slider.value);
			break;
		case 57:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_57) / ((float)level_achievement_58 - (float)level_achievement_57);
			Debug.Log ("CASE 57 + " + level_slider.value);
			break;
		case 58:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_58) / ((float)level_achievement_59 - (float)level_achievement_58);
			Debug.Log ("CASE 58 + " + level_slider.value);
			break;
		case 59:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_59) / ((float)level_achievement_60 - (float)level_achievement_59);
			Debug.Log ("CASE 59 + " + level_slider.value);
			break;
		case 60:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_60) / ((float)level_achievement_61 - (float)level_achievement_60);
			Debug.Log ("CASE 60 + " + level_slider.value);
			break;
		case 61:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_61) / ((float)level_achievement_62 - (float)level_achievement_61);
			Debug.Log ("CASE 61 + " + level_slider.value);
			break;
		case 62:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_62) / ((float)level_achievement_63 - (float)level_achievement_62);
			Debug.Log ("CASE 62 + " + level_slider.value);
			break;
		case 63:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_63) / ((float)level_achievement_64 - (float)level_achievement_63);
			Debug.Log ("CASE 63 + " + level_slider.value);
			break;
		case 64:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_64) / ((float)level_achievement_65 - (float)level_achievement_64);
			Debug.Log ("CASE 64 + " + level_slider.value);
			break;
		case 65:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_65) / ((float)level_achievement_66 - (float)level_achievement_65);
			Debug.Log ("CASE 65 + " + level_slider.value);
			break;
		case 66:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_66) / ((float)level_achievement_67 - (float)level_achievement_66);
			Debug.Log ("CASE 66 + " + level_slider.value);
			break;
		case 67:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_67) / ((float)level_achievement_68 - (float)level_achievement_67);
			Debug.Log ("CASE 67 + " + level_slider.value);
			break;
		case 68:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_68) / ((float)level_achievement_69 - (float)level_achievement_68);
			Debug.Log ("CASE 68 + " + level_slider.value);
			break;
		case 69:
			level_slider.value = ((float)currentLevelCounter - (float)level_achievement_69) / ((float)level_achievement_70 - (float)level_achievement_69);
			Debug.Log ("CASE 69 + " + level_slider.value);
			break;
		case 70:
			Debug.Log ("all levels achieved");
			Debug.Log ("CASE 70 + " + level_slider.value);
			level_slider.alpha = 0f;
			break;
		}
	}

	void ActivateCoinOfferCheck()
	{
		if(canDisplayOffer)
		{
			buyCoinsOffer.SetActive(true);
			darkbackground.SetActive(true);
			canDisplayOffer = false;
		}
	}
}
