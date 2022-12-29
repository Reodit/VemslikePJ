using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DM
{
    public class Player : MonoBehaviour
    {

        private float _smoothTime = 0.05f;
        private float _currentVelocity;
        private Vector2 _inputVec; // 입력 벡터 (x, y)
        private Vector3 _moveVec; // 이동 벡터


        private PlayerStat _playerStat;
        private Animator _animator;
        private CharacterController _cc;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _cc = GetComponent<CharacterController>();
            _playerStat = GetComponent<PlayerStat>();
        }

        private void Update()
        {
            //PlayerMove();
            //PlayerRotate();
        }

        private void OnMove(InputValue value) // "Move" Actions에 해당하는 키 입력 시 호출
        {
            _inputVec = value.Get<Vector2>(); // Get<T> : 프로필에서 설정한 컨트롤 타입 T 값을 가져오는 함수
        }

        public void PlayerMove(Vector3 vec)
        {

            _moveVec = new Vector3(vec.x, 0.0f, vec.y);

            if (_moveVec == Vector3.zero)
            {
                _animator.SetBool("isMove", false);
            }
            else
            {
                _animator.SetBool("isMove", true);
            }

            Debug.Log(_moveVec);
            // CharacterController의 SimpleMove로 캐릭터 이동
            // 방향 x 속도
            _cc.SimpleMove(_moveVec * _playerStat.MoveSpeed);
        }

        public void PlayerRotate(Vector3 vec)
        {
            if (vec.sqrMagnitude == 0)
            {
                return;
            }

            float targetAngle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }
    }
}

