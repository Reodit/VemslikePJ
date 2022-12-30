using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLocation : MonoBehaviour
{
    // -+ 0+ ++
    // -0 00 +0
    // -- 0- +-
    private Transform _myTransform;
    private int[,] firstLocations =
        { { -1, 1 }, { 0, 1 }, { 1, 1 }, { -1, 0 }, { 0, 0 }, { 1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } };

    private void Awake()
    {
        _myTransform = transform;
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void SetSize(Vector3 vec)
    {
        _myTransform.localScale = vec;
    }

    public void SetFirstLocation(Vector3 size)
    {
        int tempIndex = name.LastIndexOf('d');
        int tileIndex = int.Parse(name.Substring(tempIndex + 1)) - 1;
        _myTransform.Translate(new Vector3(firstLocations[tileIndex, 0] * size.x, 0f,
            firstLocations[tileIndex, 1] * size.z));
    }

    public Vector3 GetPosition()
    {
        return _myTransform.position;
    }
}
