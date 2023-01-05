using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public enum PoolType
    {
        Monster,
        Item
    }
    
    #region Singleton

    private static ResourceManager _instance;
    public static ResourceManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ResourceManager();
            }
            return _instance;
        }
    }

    #endregion
    
    
    
    private List<Material> _materialList = new List<Material>();
    public List<Material> Materials { get => _materialList; }
    private Dictionary<PoolType, GameObject[]> poolDict = new Dictionary<PoolType, GameObject[]>();
    public Dictionary<PoolType, GameObject[]> PoolDict { get => poolDict; }


    public void Init()
    {
        poolDict.Clear();
        GameObject[] monsters = Resources.LoadAll<GameObject>("Game/Prefabs/Pool/Monsters");
        poolDict.Add(PoolType.Monster, monsters);
        GameObject[] items = Resources.LoadAll<GameObject>("Game/Prefabs/Pool/Items");
        poolDict.Add(PoolType.Item, items);
        _materialList.AddRange(Resources.LoadAll<Material>("Game/Materials"));
    }

}
