using System;
using UnityEngine;



public class UIBase : MonoBehaviour
{
    [SerializeField] private string _uiName;
    [SerializeField] private UIType _uiType;
    [SerializeField] private UIData _uiData;
    
    public UIBase(string uiName, UIType uiType, UIData uiData)
    {
        this._uiName = uiName;
        this._uiType = uiType;
        this._uiData = uiData;
    }
}
