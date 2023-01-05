using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoolManager : PoolManager
{
    public Dictionary<ItemType, GameObject> ItemDict { get; private set; }
    #region Singleton
    private static ItemPoolManager _instance;
    public static ItemPoolManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("@ItemPoolManager");
                _instance = go.AddComponent<ItemPoolManager>();
            }
            return _instance;
        }
    }
    #endregion
    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Init()
    {
        ItemDict = new Dictionary<ItemType, GameObject>();
        GameObject[] items = ResourceManager.instance.PoolDict[ResourceManager.PoolType.Item];
        foreach (GameObject go in items)
        {
            ItemType itemType = go.GetComponent<Item>().ItemType;
            ItemDict.Add(itemType, go);
        }
        ExpandPool(ItemDict[ItemType.Exp], 100);
    }
}
