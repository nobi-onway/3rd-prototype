using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private const float LEFT_BOUND = -5.0f;

    void Update()
    {
        if(transform.position.x < LEFT_BOUND)
        {
            Destroy(gameObject);
        }
    }
}
