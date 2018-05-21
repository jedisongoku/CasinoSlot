using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bonus_game_2 : MonoBehaviour 
{	
	public GameObject guess_card;
	private UISprite guess_card_ui_sprite;
	private UITweener guess_card_tween_rotation;
	private UITweener guess_card_tween_position;
	private UITweener guess_card_tween_scale;
	public UISprite slot_1;
	public UISprite slot_2;
	public UISprite slot_3;
	public UISprite slot_4;
	public UISprite slot_5;
	
	public GameObject all_reels;
	
	private string[] red_diamonds_cards = new string[13] { "d_2", "d_3", "d_4", "d_5", "d_6", "d_7", "d_8", "d_9", "d_10", "d_J", "d_Q", "d_K", "d_A"};
	private string[] red_hearts_cards = new string[13] { "h_2", "h_3", "h_4", "h_5", "h_6", "h_7", "h_8", "h_9", "h_10", "h_J", "h_Q", "h_K", "h_A"};
	private string[] black_spades_cards = new string[13] { "s_2", "s_3", "s_4", "s_5", "s_6", "s_7", "s_8", "s_9", "s_10", "s_J", "s_Q", "s_K", "s_A"};
	private string[] black_clubs_cards = new string[13] { "c_2", "c_3", "c_4", "c_5", "c_6", "c_7", "c_8", "c_9", "c_10", "c_J", "c_Q", "c_K", "c_A"};
	
	public int color_multiplier;
	public int signs_multiplier;
	public UILabel cash_out_win;
	public UILabel color_win;
	public UILabel sign_win;
	//public GameObject collectWinButton;
	public GameObject gameOverObj;
	
	private bool event_receiver;
	private bool collect_win = false;
	private int touch_No = 0;
	private int temp_int = 0;
	private int current_win;
	private int win_added_to_balance;
	private int color_win_value;
	private int sign_win_value;
	private string button_pressed;
	private string first_place;
	private string second_place;
	private string third_place;
	private string fourth_place;
	private string fifth_place;
	public string[] temp_obj = new string[5];
	private string[] begining_card_clones = new string[5];
	
	private bool game_over = false;
	public List<string> all_cards = new List<string>();
	private Slot_Machine_System slot_system;
	
	private int one;
	private int two;
	private int three;
	private int four;
	private int five;

	public delegate void DoubleUpBonusWinAnimation();
	public static event DoubleUpBonusWinAnimation PlayDoubleUpBonusWinAnimation;
	
	void Awake()
	{
		slot_system = all_reels.GetComponent<Slot_Machine_System>();
		guess_card_ui_sprite = guess_card.GetComponent<UISprite>();
		guess_card_tween_position = guess_card.GetComponent<TweenPosition>();
		guess_card_tween_rotation = guess_card.GetComponent<TweenRotation>();
		guess_card_tween_scale = guess_card.GetComponent<TweenScale>();
		
		//AddCardsToAList();
		//RandomizeTempObj();
	}
	
	public void CurrentWinValue (int value)
	{
		current_win = value;
		win_added_to_balance = value;
	}
	
	public void RunBonusGame()
	{
		AddCardsToAList();
		SetVisibleCards ();
		RandomizeTempObj();
		collect_win = false;
		RewriteWinningLabels();
	}
	
	public void DontRunBonusGame()
	{
		slot_system.bonusGame = false;
		slot_system.Add_Win_BG_2();
	}
	
	public void CollectWinningsCashOut()
	{
		if(!collect_win)
		{
			slot_system.BonusGame_2_Win(current_win - win_added_to_balance);
			collect_win = true;
			//collectWinButton.SetActive(false);

			if(PlayDoubleUpBonusWinAnimation != null)
			{
				PlayDoubleUpBonusWinAnimation();
			}
			else Debug.LogWarning ("NOTHING IS ASSIGN TO PlayDoubleUpBonusWinAnimation DELEGATE");

			if(slot_system.autospin)
			{
				slot_system.StartCoroutine("SpinAutomatically");
			}
			
			ResetValues();
			DestroyCardClones();
			
			//slot_system.bonusGame = false;
		}
		else
		{
			Debug.Log ("you have collect your winnings already");
		}
	}
	
	public void CollectWinningsGameOver()
	{
		if(!collect_win)
		{
			slot_system.BonusGame_2_Win(current_win);
			collect_win = true;
			//collectWinButton.SetActive(false);
			
			if(slot_system.autospin)
			{
				slot_system.StartCoroutine("SpinAutomatically");
			}
			
			ResetValues();
			DestroyCardClones();
			
			//slot_system.bonusGame = false;
		}
		else
		{
			Debug.Log ("you have collect your winnings already");
		}
	}
	
	public void RedButton()
	{
		if(!game_over)
		{
			guess_card.SetActive(true);
			guess_card_tween_position.PlayForward();
			guess_card_tween_scale.PlayForward();
			button_pressed = "red";
			Debug.Log("RED BUTTON IS RUNNING AND TWEEN SHOULD PLAY");
		}
		else
		{
			Debug.Log ("game is over");
		}
	}
	
	public void BlackButton()
	{
		if(!game_over)
		{
			guess_card.SetActive(true);
			guess_card_tween_position.PlayForward();
			guess_card_tween_scale.PlayForward();
			button_pressed = "black";
			Debug.Log("BLACK BUTTON IS RUNNING AND TWEEN SHOULD PLAY");
		}
		else
		{
			Debug.Log ("game is over");
		}
	}
	
	public void RedDiamondButton()
	{
		if(!game_over)
		{
			guess_card.SetActive(true);
			guess_card_tween_position.PlayForward();
			guess_card_tween_scale.PlayForward();
			button_pressed = "diamond";
		}
		else
		{
			Debug.Log ("game is over");
		}
	}
	
	public void RedHeartButton()
	{
		if(!game_over)
		{
			guess_card.SetActive(true);
			guess_card_tween_position.PlayForward();
			guess_card_tween_scale.PlayForward();
			button_pressed = "heart";
		}
		else
		{
			Debug.Log ("game is over");
		}
	}
	
	public void BlackSpadeButton()
	{
		if(!game_over)
		{
			guess_card.SetActive(true);
			guess_card_tween_position.PlayForward();
			guess_card_tween_scale.PlayForward();
			button_pressed = "spade";
		}
		else
		{
			Debug.Log ("game is over");
		}
	}
	
	public void BlackClubButton()
	{
		if(!game_over)
		{
			guess_card.SetActive(true);
			guess_card_tween_position.PlayForward();
			guess_card_tween_scale.PlayForward();
			button_pressed = "club";
		}
		else
		{
			Debug.Log ("game is over");
		}
	}
	
	public void GameOver()
	{
		if(!game_over)
		{
			current_win = 0;
			color_win_value = 0;
			sign_win_value = 0;
			RewriteWinningLabels();
			current_win = - win_added_to_balance;
			slot_system.RewriteWinValue("0.00");
			game_over = true;
			temp_int = touch_No;
			RemoveCardsFromList();
			gameOverObj.SetActive (true);
			//GA.API.Design.NewEvent("BonusGame_2:GameOver");
		}
	}
	
	public void ResetTweensAfterGameOver()
	{
		SaveCardSlots();
		guess_card_ui_sprite.spriteName = "empty";
		guess_card_tween_position.ResetToBeginning();
		guess_card_tween_scale.ResetToBeginning();
		guess_card.SetActive(false);
	}
	
	public void ResetTweensAfterCashOut()
	{
		SaveCardSlots();
	}
	
	void RewriteWinningLabels()
	{
		color_win_value = current_win * color_multiplier;
		sign_win_value = current_win * signs_multiplier;
		
		Debug.Log ("current win " + current_win.ToString()); 
		Debug.Log ("color win " + color_win_value.ToString()); 
		Debug.Log ("sign win " + sign_win_value.ToString()); 
		
		if(current_win > 0)
		{
			cash_out_win.text = current_win.ToString("#.00");
		}
		else if (current_win == 0)
		{
			cash_out_win.text = "0.00";
		}
		
		if(color_win_value > 0)
		{
			color_win.text = color_win_value.ToString("#.00");
		}
		else if (color_win_value == 0)
		{
			color_win.text = "0.00";
		}
		
		if(sign_win_value > 0)
		{
			sign_win.text = sign_win_value.ToString("#.00");
		}
		else if (sign_win_value == 0)
		{
			sign_win.text = "0.00";
		}
		
		slot_system.RewriteWinValue(current_win.ToString("#.00"));
	}
	
	void Win()
	{
		slot_system.RewriteWinValue(current_win.ToString("#.00"));
		SaveCardSlots();
		temp_int = touch_No;
		RemoveCardsFromList();
		//GA.API.Design.NewEvent("BonusGame_2:Win");
	}
	
	void DoubleThePrice()
	{
		guess_card_ui_sprite.spriteName = "empty";
		guess_card_tween_position.ResetToBeginning();
		guess_card_tween_scale.ResetToBeginning();
		guess_card.SetActive(false);
		current_win = current_win * color_multiplier;
		RewriteWinningLabels();
	}
	
	void QuadrupleThePrice()
	{
		guess_card_ui_sprite.spriteName = "empty";
		guess_card_tween_position.ResetToBeginning();
		guess_card_tween_scale.ResetToBeginning();
		guess_card.SetActive(false);
		current_win = current_win * signs_multiplier;
		RewriteWinningLabels();
	}
	
	void AddCardsToAList()
	{
		int arraySize = red_diamonds_cards.Length;
		
		for(int i = 0; i < arraySize; i++)
		{
			all_cards.Add (red_diamonds_cards[i]);
			all_cards.Add (red_hearts_cards[i]);
			all_cards.Add (black_spades_cards[i]);
			all_cards.Add (black_clubs_cards[i]);
		}
	}
	
	void RemoveCardsFromList()
	{
		all_cards.Clear();
	}
	
	void RandomizeTempObj()
	{
		int random_No;
		int randomm_max = (red_diamonds_cards.Length + red_hearts_cards.Length + black_clubs_cards.Length + black_spades_cards.Length) - 5;
		
		for(int i = 0; i < 47; i++)
		{
			random_No = Random.Range (0, randomm_max);
			randomm_max--;
			temp_obj[i] = all_cards[random_No];
			all_cards.RemoveAt(random_No);
		}
	}
	
	void OrganizeVisibleCards()
	{
		slot_5.spriteName =  slot_4.spriteName;
		slot_4.spriteName =  slot_3.spriteName;
		slot_3.spriteName =  slot_2.spriteName;
		slot_2.spriteName =  slot_1.spriteName;
		slot_1.spriteName = guess_card_ui_sprite.spriteName;
	}
	
	void SetVisibleCards()
	{
		first_place = PlayerPrefs.GetString("1st place", "d_2");
		second_place = PlayerPrefs.GetString("2nd place", "d_3");
		third_place = PlayerPrefs.GetString ("3rd place", "d_4");
		fourth_place = PlayerPrefs.GetString ("4th place", "d_5");
		fifth_place = PlayerPrefs.GetString ("5th place","d_6");
		
		all_cards.Remove(first_place);
		all_cards.Remove(second_place);
		all_cards.Remove(third_place);
		all_cards.Remove(fourth_place);
		all_cards.Remove(fifth_place);
		
		slot_5.spriteName = fifth_place;
		slot_4.spriteName = fourth_place;
		slot_3.spriteName = third_place;
		slot_2.spriteName = second_place;
		slot_1.spriteName = first_place;
	}
	
	void CheckDoubleMatch(bool red, bool black, int No)
	{
		if(red)
		{
			
			if(temp_obj[No] == "d_2" || temp_obj[No] == "d_3" || temp_obj[No] == "d_4" || temp_obj[No] == "d_5" || temp_obj[No] == "d_6" || 
			   temp_obj[No] == "d_7" || temp_obj[No] == "d_8" || temp_obj[No] == "d_9" || temp_obj[No] == "d_10" || temp_obj[No] == "d_J" || 
			   temp_obj[No] == "d_Q" || temp_obj[No] == "d_K" || temp_obj[No] == "d_A" || 
			   temp_obj[No] == "h_2" || temp_obj[No] == "h_3" || temp_obj[No] == "h_4" || temp_obj[No] == "h_5" || temp_obj[No] == "h_6" || 
			   temp_obj[No] == "h_7" || temp_obj[No] == "h_8" || temp_obj[No] == "h_9" || temp_obj[No] == "h_10" || temp_obj[No] == "h_J" || 
			   temp_obj[No] == "h_Q" || temp_obj[No] == "h_K" || temp_obj[No] == "h_A")
			{
				Debug.Log ("you won, red card match the button");
				OrganizeVisibleCards();
				DoubleThePrice ();
				
				if(touch_No == 46)
				{
					Win ();
				}
			}
			else
			{
				Debug.Log ("you lost, red card doesnt match the button");
				GameOver ();
				OrganizeVisibleCards();
			}
		}
		else if(black)
		{
			if(temp_obj[No] == "s_2" || temp_obj[No] == "s_3" || temp_obj[No] == "s_4" || temp_obj[No] == "s_5" || temp_obj[No] == "s_6" || 
			   temp_obj[No] == "s_7" || temp_obj[No] == "s_8" || temp_obj[No] == "s_9" || temp_obj[No] == "s_10" || temp_obj[No] == "s_J" || 
			   temp_obj[No] == "s_Q" || temp_obj[No] == "s_K" || temp_obj[No] == "s_A" || 
			   temp_obj[No] == "c_2" || temp_obj[No] == "c_3" || temp_obj[No] == "c_4" || temp_obj[No] == "c_5" || temp_obj[No] == "c_6" || 
			   temp_obj[No] == "c_7" || temp_obj[No] == "c_8" || temp_obj[No] == "c_9" || temp_obj[No] == "c_10" || temp_obj[No] == "c_J" || 
			   temp_obj[No] == "c_Q" || temp_obj[No] == "c_K" || temp_obj[No] == "c_A")
			{
				Debug.Log ("you won, black card match the button");
				OrganizeVisibleCards();
				DoubleThePrice ();
				
				if(touch_No == 46)
				{
					Win ();
				}
			}
			else
			{
				Debug.Log ("you lost, black card doesnt match the button");
				GameOver ();
				OrganizeVisibleCards();
			}
		}
	}
	
	void CheckQuadrupleMatch(bool red_diamond, bool red_heart, bool black_spade, bool black_club, int No)
	{
		if(red_diamond)
		{
			if(temp_obj[No] == "d_2" || temp_obj[No] == "d_3" || temp_obj[No] == "d_4" || temp_obj[No] == "d_5" || temp_obj[No] == "d_6" || 
			   temp_obj[No] == "d_7" || temp_obj[No] == "d_8" || temp_obj[No] == "d_9" || temp_obj[No] == "d_10" || temp_obj[No] == "d_J" || 
			   temp_obj[No] == "d_Q" || temp_obj[No] == "d_K" || temp_obj[No] == "d_A")
			{
				Debug.Log ("you won, red diamond card match the button");
				OrganizeVisibleCards();
				QuadrupleThePrice();
				
				if(touch_No == 46)
				{
					Win ();
				}
			}
			else
			{
				Debug.Log ("you lost, red diamond card doesnt match the button");
				GameOver ();
				OrganizeVisibleCards();
			}
		}
		else if(red_heart)
		{
			if(temp_obj[No] == "h_2" || temp_obj[No] == "h_3" || temp_obj[No] == "h_4" || temp_obj[No] == "h_5" || temp_obj[No] == "h_6" || 
			   temp_obj[No] == "h_7" || temp_obj[No] == "h_8" || temp_obj[No] == "h_9" || temp_obj[No] == "h_10" || temp_obj[No] == "h_J" || 
			   temp_obj[No] == "h_Q" || temp_obj[No] == "h_K" || temp_obj[No] == "h_A")
			{
				Debug.Log ("you won, red heart card match the button");
				OrganizeVisibleCards();
				QuadrupleThePrice();
				
				if(touch_No == 46)
				{
					Win ();
				}
			}
			else
			{
				Debug.Log ("you lost, red heart card doesnt match the button");
				GameOver ();
				OrganizeVisibleCards();
			}
		}
		else if(black_spade)
		{
			if(temp_obj[No] == "s_2" || temp_obj[No] == "s_3" || temp_obj[No] == "s_4" || temp_obj[No] == "s_5" || temp_obj[No] == "s_6" || 
			   temp_obj[No] == "s_7" || temp_obj[No] == "s_8" || temp_obj[No] == "s_9" || temp_obj[No] == "s_10" || temp_obj[No] == "s_J" || 
			   temp_obj[No] == "s_Q" || temp_obj[No] == "s_K" || temp_obj[No] == "s_A")
			{
				Debug.Log ("you won, black spade card match the button");
				OrganizeVisibleCards();
				QuadrupleThePrice();
				
				if(touch_No == 46)
				{
					Win ();
				}
			}
			else
			{
				Debug.Log ("you lost, black spade card doesnt match the button");
				GameOver ();
				OrganizeVisibleCards();
			}
		}
		else if(black_club)
		{
			if(temp_obj[No] == "c_2" || temp_obj[No] == "c_3" || temp_obj[No] == "c_4" || temp_obj[No] == "c_5" || temp_obj[No] == "c_6" || 
			   temp_obj[No] == "c_7" || temp_obj[No] == "c_8" || temp_obj[No] == "c_9" || temp_obj[No] == "c_10" || temp_obj[No] == "c_J" || 
			   temp_obj[No] == "c_Q" || temp_obj[No] == "c_K" || temp_obj[No] == "c_A")
			{
				Debug.Log ("you won, black club card match the button");
				OrganizeVisibleCards();
				QuadrupleThePrice();
				
				if(touch_No == 46)
				{
					Win ();
				}
			}
			else
			{
				Debug.Log ("you lost, black club card doesnt match the button");
				GameOver ();
				OrganizeVisibleCards();
			}
		}
	}
	
	public void ResetValues()
	{
		touch_No = 0;
		
		DestroyCardClones();
		all_cards.Clear();
		game_over = false;
	}
	
	void DestroyCardClones()
	{
		
	}
	
	public void ChangeGuessCardSprite()
	{
		if(!event_receiver)
		{
			guess_card_ui_sprite.spriteName = temp_obj[touch_No];
			guess_card_tween_rotation.PlayReverse();
			event_receiver = true;
		}
		else
		{
			switch (button_pressed)
			{
			case "red":
				CheckDoubleMatch(true,false,touch_No);
				touch_No++;
				break;
			case "black":
				CheckDoubleMatch(false,true,touch_No);
				touch_No++;
				break;
			case "diamond":
				CheckQuadrupleMatch(true,false,false,false,touch_No);
				touch_No++;
				break;
			case "heart":
				CheckQuadrupleMatch(false,true,false,false,touch_No);
				touch_No++;
				break;
			case "spade":
				CheckQuadrupleMatch(false,false,true,false,touch_No);
				touch_No++;
				break;
			case "club":
				CheckQuadrupleMatch(false,false,false,true,touch_No);
				touch_No++;
				break;
			}
			
			event_receiver = false;
		}
	}
	
	void SaveCardSlots()
	{
		Debug.Log (slot_1.spriteName + " CARD SLOT ONE NAME");
		Debug.Log (slot_2.spriteName + " CARD SLOT TWO NAME");
		Debug.Log (slot_3.spriteName + " CARD SLOT THREE NAME");
		Debug.Log (slot_4.spriteName + " CARD SLOT FOUR NAME");
		Debug.Log (slot_5.spriteName + " CARD SLOT FIVE NAME");
		
		PlayerPrefs.SetString("1st place", slot_1.spriteName);
		PlayerPrefs.SetString("2nd place", slot_2.spriteName);
		PlayerPrefs.SetString("3rd place", slot_3.spriteName);
		PlayerPrefs.SetString("4th place", slot_4.spriteName);
		PlayerPrefs.SetString("5th place", slot_5.spriteName);
	}
}
