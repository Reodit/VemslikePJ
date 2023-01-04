using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 3f; // 공격 딜레이
    [SerializeField] private int slashDamage;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private GameObject slashObject;
    [SerializeField] private ParticleSystem slashEffect;
        
    private PlayerStat _playerStat;
    private void Awake()
    {
        _playerStat = GetComponentInParent<PlayerStat>();
        slashObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(CoAttack());
    }

    private void Update()
    {
        slashDamage = _playerStat.AttackPower;
    }

    private IEnumerator CoAttack()
    {
        while (!_playerStat.isDie)
        {
            if (_playerStat.isDie)
            {
                yield break;
            }
            
            Debug.Log("Attack");
            slashEffect.Play();

            Collider[] colliders = Physics.OverlapSphere(slashObject.transform.position,attackRange);
            DealDamage(colliders);
            yield return new WaitForSeconds(timeToAttack);
        }
    }

    private void DealDamage(Collider[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyStat enemyStat = colliders[i].GetComponent<EnemyStat>();
            if (enemyStat != null)
            {
                enemyStat.TakeDamage(slashDamage);
            }
        }
    }
}
