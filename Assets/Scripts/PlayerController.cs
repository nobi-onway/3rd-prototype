using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private const float FORCE = 10.0f;
    private bool _isOnGround = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rb.AddForce(Vector3.up * FORCE, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;
    }
}
