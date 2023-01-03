using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "UIData", menuName = "ScriptableObjects/UIData", order = 1)]
[Serializable] public class UIData : ScriptableObject
{
    public string uiName;
    public Text uiText;
    public UnityEvent buttonEvent;
}
