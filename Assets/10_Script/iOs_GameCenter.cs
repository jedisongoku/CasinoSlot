using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class iOs_GameCenter : MonoBehaviour 
{
	private bool player_authenticated = false;
	
	//write below your leaderboard id - each leaderboard has its own id
	public string leaderBoardId =  "best_players.Slots11";
	
	private static bool IsInitialized = false;
	
	//private string TEST_ACHIEVEMENT_1_ID = "com.bocean.game.casinoslots2.mega_jackpot_win";
	//private string TEST_ACHIEVEMENT_2_ID = "com.bocean.game.casinoslots2.lucky_jackpot_win";
	//private string TEST_ACHIEVEMENT_3_ID = "com.bocean.game.casinoslots2.jackpot_win";
	//private string TEST_ACHIEVEMENT_4_ID = "com.bocean.game.casinoslots2.lucky_jewel_win";
	//private string TEST_ACHIEVEMENT_5_ID = "com.bocean.game.casinoslots2.lucky_seven_win";
	//private string TEST_ACHIEVEMENT_6_ID = "com.bocean.game.casinoslots2.4_of_a_kind";
	//private string TEST_ACHIEVEMENT_7_ID = "com.bocean.game.casinoslots2.full_house";
	//private string TEST_ACHIEVEMENT_8_ID = "com.bocean.game.casinoslots2.two_pairs";
	//private string TEST_ACHIEVEMENT_9_ID = "com.bocean.game.casinoslots2.3_of_a_kind";
	//private string TEST_ACHIEVEMENT_10_ID = "com.bocean.game.casinoslots2.pair_win";
	
	void Start() 
	{
		if(!IsInitialized) 
		{	
			//Achievement registration. If you skip this step GameCenterManager.achievements array will contain only achievements with reported progress 
			//GameCenterManager.RegisterAchievement (TEST_ACHIEVEMENT_1_ID);
			//GameCenterManager.RegisterAchievement (TEST_ACHIEVEMENT_2_ID);


			//Listen for the Game Center events
			//GameCenterManager.OnAchievementsProgress += HandleOnAchievementsProgress;
			//GameCenterManager.OnAchievementsReset += HandleOnAchievementsReset;
			//.OnAchievementsLoaded += OnAchievementsLoaded;


			GameCenterManager.OnScoreSubmitted += OnScoreSubmitted;
			GameCenterManager.OnLeadrboardInfoLoaded += OnLeadrboardInfoLoaded;

			GameCenterManager.OnAuthFinished += OnAuthFinished;

			//Initializing Game Center class. This action will trigger authentication flow
			GameCenterManager.Init();
			IsInitialized = true;
		}
	}
	
	public void ReportScore(int score)
	{
		if(player_authenticated)
		{
			GameCenterManager.ReportScore(score, leaderBoardId);
		}
	}
	
	public void ShowLeaderboard()
	{
		if (player_authenticated) 
		{
			GameCenterManager.ShowLeaderboard(leaderBoardId);
		} 
		else 
		{
			if(!IsInitialized)
			{
				GameCenterManager.init();
			}
		}
	}
	
	//	public void ShowAchievements()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.showAchievements();
	//		}
	//	}
	//
	//	public void Mega_Jackpot_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_1_ID) + 2.432f, TEST_ACHIEVEMENT_1_ID);
	//		}
	//	}
	//
	//	public void LuckyJackpot_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_2_ID) + 2.432f, TEST_ACHIEVEMENT_2_ID);
	//		}
	//	}
	//
	//	public void Jackpot_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_3_ID) + 2.432f, TEST_ACHIEVEMENT_3_ID);
	//		}
	//	}
	//
	//	public void Lucky_Jewel_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_4_ID) + 2.432f, TEST_ACHIEVEMENT_4_ID);
	//		}
	//	}
	//
	//	public void Lucky_Seven_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_5_ID) + 2.432f, TEST_ACHIEVEMENT_5_ID);
	//		}
	//	}
	//
	//	public void Four_of_a_Kind_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_6_ID) + 2.432f, TEST_ACHIEVEMENT_6_ID);
	//		}
	//	}
	//
	//	public void Full_House_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_7_ID) + 2.432f, TEST_ACHIEVEMENT_7_ID);
	//		}
	//	}
	//
	//	public void Two_Pairs_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_8_ID) + 2.432f, TEST_ACHIEVEMENT_8_ID);
	//		}
	//	}
	//
	//	public void Three_of_a_Kind_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_9_ID) + 2.432f, TEST_ACHIEVEMENT_9_ID);
	//		}
	//	}
	//
	//	public void Pair_achievement()
	//	{
	//		if(player_authenticated)
	//		{
	//			GameCenterManager.submitAchievement(GameCenterManager.getAchievementProgress(TEST_ACHIEVEMENT_10_ID) + 2.432f, TEST_ACHIEVEMENT_10_ID);
	//		}
	//	}
	//
	//	private void OnAchievementsLoaded() 
	//	{
	//		Debug.Log ("Achievemnts was loaded from IOS Game Center");
	//		
	//		foreach(AchievementTemplate tpl in GameCenterManager.achievements) {
	//			Debug.Log (tpl.id + ":  " + tpl.progress);
	//		}
	//	}
	//	
	//	private void OnAchievementsReset() 
	//	{
	//		Debug.Log ("All  Achievemnts was reseted");
	//	}
	//	
	//	private void OnAchievementProgress(CEvent e) {
	//		Debug.Log ("OnAchievementProgress");
	//		
	//		AchievementTemplate tpl = e.data as AchievementTemplate;
	//		Debug.Log (tpl.id + ":  " + tpl.progress.ToString());
	//	}

	void OnScoreSubmitted (GK_LeaderboardResult result) 
	{
		if(result.IsSucceeded) 
		{
			GK_Score score = result.Leaderboard.GetCurrentPlayerScore(GK_TimeSpan.ALL_TIME, GK_CollectionType.GLOBAL);
			//IOSNativePopUpManager.showMessage("Leaderboard " + score.LongScore, "Score: " + score.LongScore + "\n" + "Rank:" + score.Rank);
		}
	}

	private void OnLeadrboardInfoLoaded (GK_LeaderboardResult result) 
	{
		if(result.IsSucceeded) 
		{
			GK_Score score = result.Leaderboard.GetCurrentPlayerScore(GK_TimeSpan.ALL_TIME, GK_CollectionType.GLOBAL);
			//IOSNativePopUpManager.showMessage("Leaderboard " + score.LeaderboardId, "Score: " + score.LongScore + "\n" + "Rank:" + score.Rank);

			Debug.Log("double score representation: " + score.DecimalFloat_2);
			Debug.Log("long score representation: " + score.LongScore);
		}
	}

	private void OnScoreSubmitted (ISN_Result result) {
		GameCenterManager.OnScoreSubmitted -= OnScoreSubmitted;

		if(result.IsSucceeded)  {
			Debug.Log("Score Submitted");
		} else {
			Debug.Log("Score Submit Failed");
		}
	}
	
	void OnPlayerSignatureRetrieveResult (GK_PlayerSignatureResult result) 
	{
		Debug.Log("OnPlayerSignatureRetrieveResult");

		if(result.IsSucceeded) 
		{
			Debug.Log("PublicKeyUrl: " + result.PublicKeyUrl);
			Debug.Log("Signature: " + result.Signature);
			Debug.Log("Salt: " + result.Salt);
			Debug.Log("Timestamp: " + result.Timestamp);
		} 
		else 
		{
			Debug.Log("Error code: " + result.Error.Code);
			Debug.Log("Error description: " + result.Error.Description);
		}

		GameCenterManager.OnPlayerSignatureRetrieveResult -= OnPlayerSignatureRetrieveResult;
	}


	void OnAuthFinished (ISN_Result res) 
	{
		if (res.IsSucceeded) 
		{
			player_authenticated = true;
			IOSNativePopUpManager.showMessage("Player Authed ", "ID: " + GameCenterManager.Player.Id + "\n" + "Alias: " + GameCenterManager.Player.Alias);
			GameCenterManager.LoadLeaderboardInfo(leaderBoardId);
		} else {
			IOSNativePopUpManager.showMessage("Game Center ", "Player authentication failed");
		}
	}
}
