using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoolManager : PoolManager
{
    [SerializeField] private int _increasement = 1;
    private Dictionary<MonsterType, GameObject> _monsterDict = new Dictionary<MonsterType, GameObject>();

    #region Singleton
    private static MonsterPoolManager _instance;
    public static MonsterPoolManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("@MonsterPoolManager");
                _instance = go.AddComponent<MonsterPoolManager>();
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
        GameObject[] monsters = ResourceManager.instance.PoolDict[ResourceManager.PoolType.Monster];
        foreach (GameObject go in monsters)
        {
            MonsterType monsterType = go.GetComponent<Monster>().MonsterType;
            _monsterDict.Add(monsterType, go);
        }
        ExpandPool(_monsterDict[MonsterType.Normal], 100);
        StartCoroutine(CoSpawn(_monsterDict[MonsterType.Normal]));
    }

    // 새롭게 생성되는 노멀 몬스터들의 스탯을 올리고 Material 변환
    public void OnWaveChange()
    {
        
    }
    
    private IEnumerator CoSpawn(GameObject go)
    {
        // Time.time
        for (int i = 0; i < amount; i++)
        {
            InstantitateObject(go);
        }

        amount += _increasement;

        yield return new WaitForSeconds(3f);
        StartCoroutine(CoSpawn(go));
    }
}
