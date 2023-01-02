using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private int _amount = 4;
    [SerializeField] private int _increasement = 1;
    private int _capacity;
    
    private Dictionary<Pool, Transform> _poolDict = new Dictionary<Pool, Transform>();
    private List<Material> _materialList = new List<Material>();
    private Queue<Pool> _poolQueue = new Queue<Pool>();
    private Game _game;
    
    #region Singleton
    private static PoolManager _instance;
    public static PoolManager instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("@PoolManager");
                _instance = go.AddComponent<PoolManager>();
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
        _game = FindObjectOfType<Game>();
    }

   

    void Start()
    {
    }

    

    void Update()
    {
        
    }
    
    private IEnumerator CoSpawn(Pool pool)
    {
        for (int i = 0; i < _amount; i++)
        {
            Instantitate(pool);
        }
        _amount += _increasement;

        yield return new WaitForSeconds(1f);
        StartCoroutine(CoSpawn(pool));
    }
    
    public GameObject Instantitate(Pool pool)
    {
        return GetObject(pool).gameObject;
    }
    
    private Pool CreateNewObject(Pool pool, Transform parent)
    {
        Pool tempPool = Instantiate(pool, parent);
        tempPool.gameObject.SetActive(false);
        return tempPool;
    }

    private Pool GetObject(Pool pool)
    {
        bool needToExpand = _poolQueue.Count < _capacity / 2;
        if (needToExpand)
        {
            ExpandPool(pool, _capacity);
        }

        Pool tempPool = _poolQueue.Dequeue();
        tempPool.gameObject.SetActive(true);
        tempPool.transform.position = CalculateSpawnPos();
        return tempPool;
    }

    private Vector3 CalculateSpawnPos()
    {
        float randomX = Random.Range(-_game.Size.x, _game.Size.x);
        float randomZ = randomX > 0 ? _game.Size.x - randomX : _game.Size.x + randomX;
        int reverseRan = Random.Range(0, 2) > 0 ? 1 : -1;
        randomZ *= reverseRan;
        Vector3 randomVec = new Vector3(randomX, 0f, randomZ); 
        return Game.player.transform.position + randomVec;
    }

    // 풀링 객체 반환
    public void ReturnObject(Pool pool)
    {
        pool.transform.position = Vector3.zero;
        pool.gameObject.SetActive(false);
        _poolQueue.Enqueue(pool);
    }

    private void ExpandPool(Pool pool ,int amount)
    {
        _capacity += amount;
        for (int i = 0; i < amount; i++)
        {
            _poolQueue.Enqueue(CreateNewObject(pool, _poolDict[pool]));
        }
    }
    
    public void Init()
    {
        Pool[] pools = Resources.LoadAll<Pool>("Game/Prefabs/Pool");
        foreach (Pool pool in pools)
        {
            Transform trans = new GameObject($"{pool.name}").transform;
            _poolDict.Add(pool, trans);
            trans.SetParent(transform);
            ExpandPool(pool, 100);
            StartCoroutine(CoSpawn(pool));
        }
        _materialList.AddRange(Resources.LoadAll<Material>("Game/Materials"));
    }

    

    

    
    
}
