using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField] protected int _exp; // 경험치
    public bool isDie;

    public int Exp
    {
        get
        {
            return _exp;
        }
        set
        {
            _exp = value;
        }
    }

    private void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attackPower = 10;
        _attackSpeed = 1;
        _moveSpeed = 5.0f;
        _defense = 5;
        isDie = false;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Debug.Log("Player Die");
        }


    }
    
    
}
