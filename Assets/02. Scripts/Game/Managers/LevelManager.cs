using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("@LevelManager");
                _instance = go.AddComponent<LevelManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(SceneType scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public IEnumerator LoadLevelAsync(SceneType scene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene.ToString());
        while (!async.isDone)
        {
            yield return null;
        }

        switch (scene)
        {
            case SceneType.MainScene:
                
                break;
            case SceneType.InGameScene:
                
                break;
        }
    }
}
