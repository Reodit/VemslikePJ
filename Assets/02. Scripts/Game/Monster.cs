using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{
    public MonsterType MonsterType { get; private set; }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        // 몬스터 초기화
    }

    private void OnDisable()
    {
        
    }

    // 피가 0이하일 때 호출
    // 스페셜 몬스터일 시 상자나 특별 아이템 드롭
    public virtual void Dead()
    {
        MonsterPoolManager.instance.ReturnObject(gameObject);
        ItemPoolManager.instance.InstantitateObject(ItemPoolManager.instance.ItemDict[ItemType.Exp]);
    }
    
        
}
