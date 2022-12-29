using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region SingletonInstance
    private UIManager() { }
    public static UIManager Instance;
    #endregion

    #region SceneState
    public UIState currentUIState;
    public SceneState currentSceneState;
    
    public UIState nextUIState;
    public SceneState nextSceneState;
    #endregion

    #region UIAndPopupElements
    private List<GameObject> _currentActiveUIList;
    private List<GameObject> _currentActivePopupList;
    #endregion
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        CheckCurrentUIAndPopupElemants();
    }

    private void CheckCurrentUIAndPopupElemants()
    {
        _currentActiveUIList = GameObject.FindGameObjectsWithTag("UI").ToList();
        _currentActivePopupList = GameObject.FindGameObjectsWithTag("Popup").ToList();
    }
    

}
