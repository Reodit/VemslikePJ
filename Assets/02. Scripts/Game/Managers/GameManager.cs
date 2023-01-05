using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("@GameManger");
                _instance = go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    #endregion

    public GameState gameState { get; private set; }
    
    public enum GameState
    {
        Lobby,
        Playing,
        End,
    }
    
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void SetGameState(GameState state)
    {
        gameState = state;
    }

    public void StartGame()
    {
        if (gameState != GameState.Playing)
        {
            return;
        }
        LevelManager.instance.LoadLevel(SceneType.InGameScene);
    }
}
