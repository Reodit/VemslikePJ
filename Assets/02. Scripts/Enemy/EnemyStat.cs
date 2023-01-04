using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : Stat
{
    public bool isDie;

    private void Start()
    {
        _hp = 30;
        _moveSpeed = 3f;
        _attackPower = 10;
    }
    
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        Debug.Log("Enemy HP : " + _hp);
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStat playerStat = collision.gameObject.GetComponent<PlayerStat>();
            playerStat.TakeDamage(_attackPower);
        }
    }
}
