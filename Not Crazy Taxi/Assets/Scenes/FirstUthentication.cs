using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class FirstUthentication : MonoBehaviour
{

        public static PlayGamesPlatform platform;

    // Start is called before the first frame update
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void SHOWldb()
    {
        PlayGames.ShowLeaderboard();
    }
    public void SHOWAchi()
    {
        PlayGames.ShowAchievements();
    }
}
