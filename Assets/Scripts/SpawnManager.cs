using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(25, 0, 0);
    private const float START_DETAY = 1.5f;
    private const float SPAWN_INTERVAL = 2.0f;

    private PlayerController _playerController;
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), START_DETAY, SPAWN_INTERVAL);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if(_playerController.gameOver)
        {
            CancelInvoke(nameof(SpawnObstacle));
        }

        Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
    }
}
