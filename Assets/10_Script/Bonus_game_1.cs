//--------------COPYRIGHT----------------------
// Copyright © 2014 SSC Production Entertainment
// 			Design by Mikey      
//			info@slovack.com
//********************************************** 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bonus_game_1 : MonoBehaviour 
{
	public GameObject all_reels;
	public GameObject cellect_winnings;
	public int value_1;
	public int value_2;
	public int value_3;
	public int value_4;
	public int value_5;
	public int value_6;
	public string value_x_1;
	public string value_x_2;
	public string value_x_3;

	public UILabel win_label_value;
	public UILabel button_1_label;
	public UILabel button_2_label;
	public UILabel button_3_label;
	public UILabel button_4_label;
	public UILabel button_5_label;
	public UILabel button_6_label;
	public UILabel button_7_label;
	public UILabel button_8_label;
	public UILabel button_9_label;

	private bool button_1_pressed = false;
	private bool button_2_pressed = false;
	private bool button_3_pressed = false;
	private bool button_4_pressed = false;
	private bool button_5_pressed = false;
	private bool button_6_pressed = false;
	private bool button_7_pressed = false;
	private bool button_8_pressed = false;
	private bool button_9_pressed = false;
	private bool bg_firstTime = true;
	private bool bg_is_running = false;
	private bool collect_win = false;
	private bool game_over = false;

	private List<string> bg_values = new List<string>();
	public string[] temp_var = new string[9];
	private int x_counter = 0;
	private int bg_win = 0;
	private Slot_Machine_System slot_system;

	void Awake()
	{
		slot_system = all_reels.GetComponent<Slot_Machine_System>();
		//AddValues ();
	}

	public void RunBonusGame()
	{
		if(!bg_is_running)
		{
			bg_is_running = true;
			Debug.Log ("bonus game is running");
			AddValues();
		}
		else
		{
			Debug.Log ("bonus game is already running");
		}
	}

	public void DontRunBonusGame()
	{
		slot_system.bonusGame = false;
		if(slot_system.autospin)
		{
			slot_system.StartCoroutine("SpinAutomatically");
		}
	}

	public void CollectWinnings()
	{
		if(!collect_win)
		{
			slot_system.BonusGameWin(bg_win);

			button_1_pressed = false;
			button_2_pressed = false;
			button_3_pressed = false;
			button_4_pressed = false;
			button_5_pressed = false;
			button_6_pressed = false;
			button_7_pressed = false;
			button_8_pressed = false;
			button_9_pressed = false;

			button_1_label.text = "";
			button_2_label.text = "";
			button_3_label.text = "";
			button_4_label.text = "";
			button_5_label.text = "";
			button_6_label.text = "";
			button_7_label.text = "";
			button_8_label.text = "";
			button_9_label.text = "";
			win_label_value.text = "0";

			bg_win = 0;

			bg_is_running = false;
			bg_firstTime = true;
			collect_win = true;
			game_over = false;
			if(slot_system.autospin)
			{
				slot_system.StartCoroutine("SpinAutomatically");
			}
		}
		else
		{
			Debug.Log ("you have collect your winnings already");
		}
	}

	public void Button_1()
	{
		if(!button_1_pressed && !game_over)
		{
			button_1_pressed = true;
			button_1_label.text = temp_var[0];
			
			if(temp_var[0] == value_x_1 || temp_var[0] == value_x_2 || temp_var[0] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[0] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[0] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[0] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[0] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[0] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[0] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_2()
	{
		if(!button_2_pressed && !game_over)
		{
			button_2_pressed = true;
			button_2_label.text = temp_var[1];
			
			if(temp_var[1] == value_x_1 || temp_var[1] == value_x_2 || temp_var[1] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[1] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[1] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[1] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[1] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[1] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[1] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_3()
	{
		if(!button_3_pressed && !game_over)
		{
			button_3_pressed = true;
			button_3_label.text = temp_var[2];
			
			if(temp_var[2] == value_x_1 || temp_var[2] == value_x_2 || temp_var[2] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[2] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[2] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[2] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[2] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[2] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[2] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_4()
	{
		if(!button_4_pressed && !game_over)
		{
			button_4_pressed = true;
			button_4_label.text = temp_var[3];
			
			if(temp_var[3] == value_x_1 || temp_var[3] == value_x_2 || temp_var[3] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[3] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[3] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[3] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[3] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[3] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[3] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_5()
	{
		if(!button_5_pressed && !game_over)
		{
			button_5_pressed = true;
			button_5_label.text = temp_var[4];
			
			if(temp_var[4] == value_x_1 || temp_var[4] == value_x_2 || temp_var[4] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[4] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[4] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[4] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[4] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[4] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[4] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_6()
	{
		if(!button_6_pressed && !game_over)
		{
			button_6_pressed = true;
			button_6_label.text = temp_var[5];
			
			if(temp_var[5] == value_x_1 || temp_var[5] == value_x_2 || temp_var[5] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[5] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[5] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[5] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[5] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[5] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[5] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_7()
	{
		if(!button_7_pressed && !game_over)
		{
			button_7_pressed = true;
			button_7_label.text = temp_var[6];
			
			if(temp_var[6] == value_x_1 || temp_var[6] == value_x_2 || temp_var[6] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[6] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[6] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[6] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[6] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[6] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[6] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_8()
	{
		if(!button_8_pressed && !game_over)
		{
			button_8_pressed = true;
			button_8_label.text = temp_var[7];
			
			if(temp_var[7] == value_x_1 || temp_var[7] == value_x_2 || temp_var[7] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[7] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[7] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[7] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[7] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[7] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[7] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}
	
	public void Button_9()
	{
		if(!button_9_pressed && !game_over)
		{
			button_9_pressed = true;
			button_9_label.text = temp_var[8];
			
			if(temp_var[8] == value_x_1 || temp_var[8] == value_x_2 || temp_var[8] == value_x_3)
			{
				Check_X_counter();
			}
			else if(temp_var[8] == value_1.ToString())
			{
				AddWinnings(value_1);
			}
			else if(temp_var[8] == value_2.ToString())
			{
				AddWinnings(value_2);
			}
			else if(temp_var[8] == value_3.ToString())
			{
				AddWinnings(value_3);
			}
			else if(temp_var[8] == value_4.ToString())
			{
				AddWinnings(value_4);
			}
			else if(temp_var[8] == value_5.ToString())
			{
				AddWinnings(value_5);
			}
			else if(temp_var[8] == value_6.ToString())
			{
				AddWinnings(value_6);
			}
		}
		else
		{
			Debug.Log ("Button was already pressed or bonus game is over");
		}
	}

	void AddValues()
	{
		Debug.Log ("all values will be assign");

		if (bg_firstTime)
		{
			bg_firstTime = false;
			bg_values.Add(value_1.ToString());
			bg_values.Add(value_2.ToString());
			bg_values.Add(value_3.ToString());
			bg_values.Add(value_4.ToString());
			bg_values.Add(value_5.ToString());
			bg_values.Add(value_6.ToString());
			bg_values.Add(value_x_1);
			bg_values.Add(value_x_2);
			bg_values.Add(value_x_3);
//			foreach(string values in bg_values)
//			{
//				Debug.Log (values);
//			}
			RandomizeValues();
		}
		else
		{
			Debug.Log ("values and colliders have been assigned");
		}
	}

	void RandomizeValues()
	{
		int randMax = 9;
		int tempNO = 8;
		int arraySize = 8;
		int randomNO;

		for(int i = 0; i <= arraySize; i++ )
		{
			randomNO = Random.Range(0,randMax);
			temp_var[tempNO] = bg_values[randomNO].ToString();
			bg_values.RemoveAt(randomNO);
			//Debug.Log (temp_var[tempNO]);
			tempNO --;
			randMax --;
		}
	}

	void RemoveValues()
	{
		Debug.Log ("all values will be removed");
	}

	void Check_X_counter()
	{
		x_counter++;

		if (x_counter == 3)
		{
			BG_GameOver();
			x_counter = 0;
		}
	}

	void AddWinnings(int value)
	{
		bg_win = bg_win + value;
		win_label_value.text = bg_win.ToString();
		Debug.Log (bg_win);
	}

	void BG_GameOver()
	{
		game_over = true;
		collect_win = false;
		cellect_winnings.SetActive(true);
		button_1_pressed = true;
		button_2_pressed = true;
		button_3_pressed = true;
		button_4_pressed = true;
		button_5_pressed = true;
		button_6_pressed = true;
		button_7_pressed = true;
		button_8_pressed = true;
		button_9_pressed = true;
	}
}
