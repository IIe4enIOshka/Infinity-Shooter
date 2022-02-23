using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Clock _template;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private float _lastTimeSpawn;

    private void Start()
    {
        _lastTimeSpawn = _delay;
    }

    private void Update()
    {
        if (_lastTimeSpawn <= 0)
        {
            var clock = Instantiate(_template, new Vector3(_spawnPoint.position.x, Random.Range(_minHeight, _maxHeight)), Quaternion.identity);
            clock.Init(_player);
            _lastTimeSpawn = _delay;
        }

        _lastTimeSpawn -= Time.deltaTime;
    }
}
