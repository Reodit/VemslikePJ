using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Vector3 vec;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0f, vertical);
        Vector3 normalVec = vec.normalized;
        transform.Translate(normalVec * (speed * Time.deltaTime));
    }
}
