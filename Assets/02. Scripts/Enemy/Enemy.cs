using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent _nav;
    private Rigidbody _rigid;

    private void Awake()
    {
        _nav = GetComponent<NavMeshAgent>();
        _rigid = GetComponent<Rigidbody>();
        
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.GetComponent<Transform>();
        }
    }
    // Update is called once per frame
    private void Update()
    {
        _nav.SetDestination(target.position);
    }

    private void FixedUpdate()
    {
        FreezeVelocity();
    }

    private void FreezeVelocity()
    {
        _rigid.velocity = Vector3.zero;
        _rigid.angularVelocity = Vector3.zero;
    }
}
