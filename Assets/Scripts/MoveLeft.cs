using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!_playerController.gameOver)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
}
