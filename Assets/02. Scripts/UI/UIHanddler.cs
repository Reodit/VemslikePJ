using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHanddler : MonoBehaviour
{
    public void UICreate(GameObject uiPrefab, Transform parentCanvas, List<GameObject> currentActiveUIList)
    {
        Instantiate(uiPrefab, parentCanvas);
        currentActiveUIList.Add(uiPrefab);
    }
    public void UIClear(GameObject uiPrefab, List<GameObject> currentActiveUIList)
    {
        uiPrefab.SetActive(false);
        currentActiveUIList.Remove(uiPrefab);
    }
    
    public void PopupCreate(GameObject popupPrefab, Transform parentCanvas, List<GameObject> currentActivePopupList)
    {
        Instantiate(popupPrefab, parentCanvas);
        currentActivePopupList.Add(popupPrefab);
    }

    public void PopupClear(GameObject popupPrefab, List<GameObject> currentActivePopupList)
    {
        popupPrefab.SetActive(false);
        currentActivePopupList.Remove(popupPrefab);
    }

}
