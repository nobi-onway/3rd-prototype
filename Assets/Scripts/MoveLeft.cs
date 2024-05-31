using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
