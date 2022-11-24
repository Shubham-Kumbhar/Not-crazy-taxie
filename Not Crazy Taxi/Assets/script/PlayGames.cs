using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayGames : MonoBehaviour
{
    public int playerScore;
    string leaderboardID = "CgkIq4y12sgFEAIQBQ";
    string achievementID1 = "CgkIq4y12sgFEAIQAA";
    string achievementID2 = "CgkIq4y12sgFEAIQAQ";
    string achievementID3 = "CgkIq4y12sgFEAIQAg";
    string achievementID4 = "CgkIq4y12sgFEAIQAw";
    string achievementID5 = "CgkIq4y12sgFEAIQBA";
    public static PlayGamesPlatform platform;

    void Start()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });

        // UnlockAchievement();
    }

    void Update()
    {
        playerScore = PlayerPrefs.GetInt("highscore",0);
    }

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public static void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public static void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

   

    public  void UnlockAchievement1()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID1, 100f, success => { });
        }
    }

    public  void UnlockAchievement2()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID2, 100f, success => { });
        }
    }

    public  void UnlockAchievement3()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID3, 100f, success => { });
        }
    }


    public  void UnlockAchievement4()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID4, 100f, success => { });
        }
    }

    public void UnlockAchievement5()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID5, 100f, success => { });
        }
    }
}