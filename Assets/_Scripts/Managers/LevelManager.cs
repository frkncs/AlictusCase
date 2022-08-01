using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public struct GameEvents
{
    public static Action GameStartedEvent;
    public static Action WinEvent;
    public static Action LoseEvent;

    public static void DestroyEvents()
    {
        GameStartedEvent = null;
        WinEvent = null;
        LoseEvent = null;
    }
}

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public static LevelData levelData;
    
    [SerializeField] private LevelData[] game01Levels;
    [SerializeField] private LevelData[] game02Levels;
    
    private void Awake()
    {
        int gameIndex = PlayerPrefs.GetInt("PlayerLevel") % SceneManager.sceneCountInBuildSettings;
        
        int levelIndex;

        if (gameIndex != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene(gameIndex);
            return;
        }
        
        switch (gameIndex)
        {
            case 0:
                
                levelIndex = PlayerPrefs.GetInt("Game01_PlayerLevel") % game01Levels.Length;
                levelData = game01Levels[levelIndex];
                
                break;
            case 1:
                
                levelIndex = PlayerPrefs.GetInt("Game02_PlayerLevel") % game02Levels.Length;
                levelData = game02Levels[levelIndex];
                
                break;
        }

        Instantiate(levelData.levelObject);
    }

    private void OnDestroy()
    {
        GameEvents.DestroyEvents();
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);

        switch (levelData.gameIndex)
        {
            case LevelData.GameIndex.Game01:
                PlayerPrefs.SetInt("Game01_PlayerLevel", PlayerPrefs.GetInt("Game01_PlayerLevel") + 1);
                break;
            case LevelData.GameIndex.Game02:
                PlayerPrefs.SetInt("Game02_PlayerLevel", PlayerPrefs.GetInt("Game02_PlayerLevel") + 1);
                break;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
