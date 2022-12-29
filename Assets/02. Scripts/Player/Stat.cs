using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField] protected int _level;          // 레벨
    [SerializeField] protected int _hp;             // 현재 HP
    [SerializeField] protected int _maxHp;          // 최대 HP
    [SerializeField] protected int _attackPower;    // 공격력
    [SerializeField] protected int _attackSpeed;    // 공격 속도
    [SerializeField] protected float _moveSpeed;    // 이동 속도
    [SerializeField] protected int _defense;        // 방어력

    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return _maxHp;
        }
        set
        {
            _maxHp = value;
        }
    }

    public int AttackPower
    {
        get
        {
            return _attackPower;
        }
        set
        {
            _attackPower = value;
        }
    }

    public int AttackSpeed
    {
        get
        {
            return _attackSpeed;
        }
        set
        {
            _attackSpeed = value;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }
        set
        {
            _moveSpeed = value;
        }
    }

    public int Defense
    {
        get
        {
            return _defense;
        }
        set
        {
            _defense = value;
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
    }

}
