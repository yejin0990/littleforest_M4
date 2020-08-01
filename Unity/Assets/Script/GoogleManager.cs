using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
//for encoding
using System.Text;
//for extra save ui
using UnityEngine.SocialPlatforms;
//for text, remove
using UnityEngine.UI;
using System;

public class GoogleManager : MonoBehaviour
{
    private static GoogleManager instance;

    //구글매니저 인스턴스화
    public static GoogleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GoogleManager>();

                if (instance == null)
                {
                    instance = new GameObject("PlayGameCloudData").AddComponent<GoogleManager>();
                }
            }

            return instance;
        }
    }

    public bool isProcessing
    {
        get;
        private set;
    }
    public string loadedData
    {
        get;
        private set;
    }
    
    //authenticate 권한받기
    public bool isAuthenticated
    {
        get
        {
            return Social.localUser.authenticated;
        }
    }

    //초기화
    private void InitiatePlayGames()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = false;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }

    private void Awake()
    {
        InitiatePlayGames();
    }

    //구글로그인 함수
    public void Login()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (!success)
            {
                Debug.Log("Fail Login");
            }
        });
    }

    }
   
    private byte[] StringToBytes(string stringToConvert)
    {
        return Encoding.UTF8.GetBytes(stringToConvert);
    }

    private string BytesToString(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }


