using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy[] _template;
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
        int number = Random.Range(0, 100);

        if (number < 70)
            number = 0;

        else
            number = 1;

        if (_lastTimeSpawn <= 0)
        {
            var enemy = Instantiate(_template[number], new Vector3(_spawnPoint.position.x, Random.Range(_minHeight, _maxHeight)), Quaternion.identity);
            enemy.Init(_player);
            _lastTimeSpawn = _delay;
        }

        _lastTimeSpawn -= Time.deltaTime;
    }
}
