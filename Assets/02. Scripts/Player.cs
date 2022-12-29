using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private float _smoothTime = 0.05f;
    private float _currentVelocity;
    private Vector2 _inputVec;      // 입력 벡터 (x, y)
    private Vector3 _moveVec;       // 이동 벡터
    
    private PlayerStat _playerStat;
    
    private CharacterController _cc;
    
    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _playerStat = GetComponent<PlayerStat>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerRotate();
    }
    
    private void OnMove(InputValue value) // "Move" Actions에 해당하는 키 입력 시 호출
    {
        _inputVec = value.Get<Vector2>(); // Get<T> : 프로필에서 설정한 컨트롤 타입 T 값을 가져오는 함수

    }
    private void PlayerMove()
    {
        _moveVec = new Vector3(_inputVec.x, 0.0f, _inputVec.y);
        
        // CharacterController의 SimpleMove로 캐릭터 이동
        // 방향 x 속도
        _cc.SimpleMove(_moveVec * _playerStat.MoveSpeed);
    }

    private void PlayerRotate()
    {
        if (_inputVec.sqrMagnitude == 0)
        {
            return;
        }

        float targetAngle = Mathf.Atan2(_moveVec.x, _moveVec.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }
}


