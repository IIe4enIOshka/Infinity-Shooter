using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Energy _template;
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
            Instantiate(_template, new Vector3(_spawnPoint.position.x, Random.Range(_minHeight, _maxHeight)), Quaternion.identity);
            _lastTimeSpawn = _delay;
        }

        _lastTimeSpawn -= Time.deltaTime;
    }
}
