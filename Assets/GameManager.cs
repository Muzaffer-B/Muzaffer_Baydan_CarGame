using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Move,
    LevelComplete
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AnimationClip[] animation;
    public World world;
    int playersCount;
    int levelstatus;
    GameData gameData;
    public GameState currentState = GameState.Move;


    public static Action<GameState> onGameStateChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (world != null)
        {
             levelstatus = PlayerPrefs.GetInt("Current Level", 0);
            Debug.Log("Level Status" + levelstatus);
            if (world.levels.Length > levelstatus)
            {
                Instantiate(world.levels[levelstatus].Obstacles);

            }
            else
            {
                PlayerPrefs.SetInt("Current Level", 0);
                levelstatus = PlayerPrefs.GetInt("Current Level", 0);
                Instantiate(world.levels[levelstatus].Obstacles);

            }
        }
    }
    private void Start()
    {
        gameData = FindObjectOfType<GameData>();

        playersCount = FindObjectsOfType<PlayerContoller>().Length - 1;
        PlayerLayer.onCountReached += CheckGameStatus;
        GameManager.onGameStateChanged += GameStatus;
    }

    private void OnDestroy()
    {
        PlayerLayer.onCountReached -= CheckGameStatus;
        GameManager.onGameStateChanged -= GameStatus;

    }

    public AnimationClip GetAnimation()
    {

        return animation[playersCount];



    }

    public void SetPlayerCount(int playerscount)
    {
        playersCount = playerscount - 1;
    }

    private void CheckGameStatus()
    {
        if (playersCount == world.levels[levelstatus].obstacleCount-1 /*animation.Length - 1*/)
        {
            SetGameState(GameState.LevelComplete);
        }
    }

    public void SetGameState(GameState gameState)
    {
        currentState = gameState;
        onGameStateChanged?.Invoke(currentState);
    }

    private void GameStatus(GameState gameState)
    {
        if (gameState == GameState.LevelComplete)
        {
            Debug.Log("Level  Finished");
            int level = PlayerPrefs.GetInt("Current Level", 0);
            PlayerPrefs.SetInt("Current Level", level + 1);
            PlayerPrefs.SetString("LevelStatus", "LevelComplete");
            if(world.levels.Length -1 > levelstatus)
            {
                if (gameData.saveData.isActive[levelstatus + 1])
                {

                    PlayerPrefs.DeleteKey("Opened Level");
                }
                else
                {
                    if (gameData != null)
                    {
                        gameData.saveData.isActive[levelstatus + 1] = true;
                        gameData.Save();
                    }
                    PlayerPrefs.SetInt("Opened Level", levelstatus + 1);
                }
            }
            else
            {
                

             PlayerPrefs.DeleteKey("Opened Level");
                   
            }
            
           


            SceneManager.LoadScene(0);
        }
    }

    public bool IsGameState()
    {
        return currentState == GameState.Move;
    }
}
