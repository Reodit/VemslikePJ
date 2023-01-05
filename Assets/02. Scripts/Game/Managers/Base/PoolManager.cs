using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public abstract class PoolManager : MonoBehaviour
{
    [SerializeField] protected int amount = 4;
    [SerializeField] protected int maxPoolCount = 100000;
    
    protected List<GameObject> activeObjects = new List<GameObject>(); 
    protected Game game;
    
    private int _capacity;
    
    private Queue<GameObject> _poolQueue = new Queue<GameObject>();
    
    

    private void Awake()
    {
        game = FindObjectOfType<Game>();
        DontDestroyOnLoad(this);
    }

   

    void Start()
    {
    }

    

    void Update()
    {
        
    }
    
    
    
    public GameObject InstantitateObject(GameObject go)
    {
        return GetObject(go).gameObject;
    }

    // 풀링 객체 반환
    public void ReturnObject(GameObject go)
    {
        go.transform.position = Vector3.zero;
        go.gameObject.SetActive(false);
        activeObjects.Remove(go);
        _poolQueue.Enqueue(go);
    }

    protected void ExpandPool(GameObject go ,int count)
    {
        _capacity += count;
        if (maxPoolCount > _poolQueue.Count)
        {
            ManagePoolMax();
        }
        for (int i = 0; i < count; i++)
        {
            _poolQueue.Enqueue(CreateNewObject(go, transform));
        }
    }
    
    protected GameObject GetObject(GameObject go)
    {
        bool needToExpand = _poolQueue.Count < _capacity / 2;
        if (needToExpand)
        {
            ExpandPool(go, _capacity);
        }

        GameObject tempGameObject = _poolQueue.Dequeue();
        tempGameObject.gameObject.SetActive(true);
        activeObjects.Add(go);    
        tempGameObject.transform.position = CalculateSpawnPos();
        return tempGameObject;
    }
    
    protected int ActiveObjectCount()
    {
        return activeObjects.Count;
    }
    
    protected int InActiveObjectCount()
    {
        return _poolQueue.Count;
    }

    protected int AllObjectCount()
    {
        return _capacity;
    }
    
    private GameObject CreateNewObject(GameObject go, Transform parent)
    {
        GameObject tempGameObject = Instantiate(go, parent);
        tempGameObject.gameObject.SetActive(false);
        return tempGameObject;
    }
    
    private Vector3 CalculateSpawnPos()
    {
        float randomX = Random.Range(-game.Size.x, game.Size.x);
        float randomZ = randomX > 0 ? game.Size.x - randomX : game.Size.x + randomX;
        int reverseRan = Random.Range(0, 2) > 0 ? 1 : -1;
        randomZ *= reverseRan;
        Vector3 randomVec = new Vector3(randomX, 0f, randomZ); 
        return game.Player.transform.position + randomVec;
    }

    private void ManagePoolMax()
    {
        while (_poolQueue.Count > _capacity / 2)
        {
            GameObject go = _poolQueue.Dequeue();
            Destroy(go);
        }
    }

    public abstract void Init();

}
