using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DM;

public class Game : MonoBehaviour
{
    
    // TODO : 스크립트 수정하고 프리펩 동민님 걸로 바꿔야 됨
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] Vector3 _size = Vector3.one;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtual;

    private ReLocation[] _reLocations = new ReLocation[9];
    private Transform _playerTrans;
    private ReLocation _currentTile;
    private ReLocation _preTile;
    private float _maxDisPow;
    private PlayerDirection _playerDirection;
    private Player _player;


    public enum PlayerDirection
    {
        None,
        LeftUp,
        Up,
        RightUp,
        Left,
        Right,
        LeftDown,
        Down,
        RightDown,
    }
    
    private void Awake()
    {
        _player = Instantiate(_playerPrefab).GetComponent<Player>();
        _playerTrans = _player.transform;
        _cinemachineVirtual.Follow = _player.transform;
        _cinemachineVirtual.LookAt = _player.transform;
    }

    private void Start()
    {
        SetFirstTileSize();
        // 중앙 타일
        _currentTile = _reLocations[4];
        // 타일 중앙으로부터의 거리 (반지름)
        _maxDisPow = Mathf.Pow(_size.x / 2, 2);
        StartCoroutine(CoRelocateTiles());
    }

    private void SetFirstTileSize()
    {
        _reLocations = FindObjectsOfType<ReLocation>();
        Debug.Log(_reLocations.Length);
        foreach (ReLocation reLocation in _reLocations)
        {
            Debug.Log(reLocation);
            reLocation.SetSize(_size);
            reLocation.SetFirstLocation(_size);
        }
    }

    private IEnumerator CoRelocateTiles()
    {
        _playerDirection = PlayerDirection.None;
        int tempFrame = 0;
        Vector3 preVec = _playerTrans.position;
        while (tempFrame < 10)
        {
            yield return new WaitForEndOfFrame();
            tempFrame++;
        }
        Debug.Log($"_maxDisPow : {_maxDisPow}");

        // 어느 타일 위에 있는지
        Vector3 currentVec = _playerTrans.position;
        bool isChangedTile = false;
        float currentDisXPow;
        float currentDisZPow;
        for (int i = 0; i < _reLocations.Length; i++)
        {
            if (_currentTile == _reLocations[i])
            {
                continue;
            }
            
            // 타일의 가로 세로 길이 같음
            currentDisXPow = Mathf.Pow(_playerTrans.position.x - _reLocations[i].GetPosition().x, 2);
            currentDisZPow = Mathf.Pow(_playerTrans.position.z - _reLocations[i].GetPosition().z, 2);
            float currentDisPow = currentDisXPow + currentDisZPow;
            Debug.Log($"_reLocations[i] : {_reLocations[i].name} currentDisX : {currentDisXPow} currentDisZ : {currentDisZPow}");
            isChangedTile = currentDisPow < _maxDisPow;
            Debug.Log($"isChangedTile : {isChangedTile}");
            if (isChangedTile)
            {
                _preTile = _currentTile;
                _currentTile = _reLocations[i];
                break;
            }

            Debug.Log($"_preTile : {_preTile}"); 
        }
        
        
        if (isChangedTile)
        {
            // 이전타일 위치와 현재 타일 위치 비교
            float preDisX = Mathf.Abs(_currentTile.transform.position.x - _preTile.transform.position.x);
            float preDisZ = Mathf.Abs(_currentTile.transform.position.z - _preTile.transform.position.z);
            bool hasXVecMoved = preDisX >= _size.x;
            bool hasZVecMoved = preDisZ >= _size.z;

            // 대각선 타일
            if (hasXVecMoved && hasZVecMoved)
            {
                if (currentVec.x < preVec.x)
                {
                    if (currentVec.z > preVec.z)
                    {
                        _playerDirection = PlayerDirection.LeftUp;
                    }
                    else if (currentVec.z < preVec.z)
                    {
                        _playerDirection = PlayerDirection.LeftDown;
                    }
                }
                else if (currentVec.x > preVec.x)
                {
                    if (currentVec.z > preVec.z)
                    {
                        _playerDirection = PlayerDirection.RightUp;
                    }
                    else if (currentVec.z < preVec.z)
                    {
                        _playerDirection = PlayerDirection.RightDown;
                    }
                }
            }
            else if (hasXVecMoved)
            {
                // 현재 타일이 오른쪽에 있는 타일임
                if (currentVec.x > preVec.x)
                {
                    _playerDirection = PlayerDirection.Right;
                }
                // 현재 타일이 왼쪽에 있는 타일임
                else if (currentVec.x < preVec.x)
                {
                    _playerDirection = PlayerDirection.Left;
                }
            }
            else if (hasZVecMoved)
            {
                // 현재 타일이 위쪽에 있는 타일임
                if (currentVec.z > preVec.z)
                {
                    _playerDirection = PlayerDirection.Up;
                }
                // 현재 타일이 아랫쪽에 있는 타일임
                else if (currentVec.z < preVec.z)
                {
                    _playerDirection = PlayerDirection.Down;
                }
            }

            // 타일 옮기기

            Debug.Log($"_currentTile : {_currentTile.name}");
            Debug.Log($"_playerDirection : {_playerDirection}");
            switch (_playerDirection)
            {
                case PlayerDirection.LeftUp:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isRightTile = reLocation.transform.position.x > _preTile.transform.position.x;
                        bool isDownTile = reLocation.transform.position.z < _preTile.transform.position.z; 
                        if (isRightTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.x -= 3 * _size.x;
                            reLocation.transform.position = tempPos;
                        }

                        if (isDownTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.z += 3 * _size.z;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.Up:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isDownTile = reLocation.transform.position.z < _preTile.transform.position.z; 
                        if (isDownTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.z += 3 * _size.z;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.RightUp:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isLeftTile = reLocation.transform.position.x < _preTile.transform.position.x;
                        bool isDownTile = reLocation.transform.position.z < _preTile.transform.position.z; 
                        if (isLeftTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.x += 3 * _size.x;
                            reLocation.transform.position = tempPos;
                        }

                        if (isDownTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.z += 3 * _size.z;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.Left:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isRightTile = reLocation.transform.position.x > _preTile.transform.position.x;
                        if (isRightTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.x -= 3 * _size.x;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.Right:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isLeftTile = reLocation.transform.position.x < _preTile.transform.position.x;
                        if (isLeftTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.x += 3 * _size.x;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.LeftDown:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isRightTile = reLocation.transform.position.x > _preTile.transform.position.x;
                        bool isUpTile = reLocation.transform.position.z > _preTile.transform.position.z; 
                        if (isRightTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.x -= 3 * _size.x;
                            reLocation.transform.position = tempPos;
                        }

                        if (isUpTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.z -= 3 * _size.z;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.Down:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isUpTile = reLocation.transform.position.z > _preTile.transform.position.z; 
                        if (isUpTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.z -= 3 * _size.z;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
                case PlayerDirection.RightDown:
                    foreach (ReLocation reLocation in _reLocations)
                    {
                        bool isLeftTile = reLocation.transform.position.x < _preTile.transform.position.x;
                        bool isUpTile = reLocation.transform.position.z > _preTile.transform.position.z; 
                        if (isLeftTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.x += 3 * _size.x;
                            reLocation.transform.position = tempPos;
                        }

                        if (isUpTile)
                        {
                            Vector3 tempPos = reLocation.transform.position;
                            tempPos.z -= 3 * _size.z;
                            reLocation.transform.position = tempPos;
                        }
                    }
                    break;
            }
        }

        // 반복
        StartCoroutine(CoRelocateTiles());
    }
}
