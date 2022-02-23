using UnityEngine;
using DG.Tweening;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed = 7;
    [SerializeField] private float _maxHeight = 4;
    [SerializeField] private float _minHeight;

    [SerializeField] Transform _targetPointEnd;

    private int _direction;
    private bool _onDied = false;

    public void Start()
    {
        transform.position = _startPosition;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied()
    {
        _onDied = true;
    }

    public void Update()
    {
        CheckBorder();

        if (_onDied == false)
            transform.position = new Vector3(transform.position.x, transform.position.y + _direction * _speed * Time.deltaTime);
    }

    public void DoMove()
    {
        transform.DOMove(_targetPointEnd.position, 2).SetLoops(2, LoopType.Yoyo);
    }

    public void DoScale()
    {
        transform.DOScale(transform.localScale * 2, 2).SetLoops(2, LoopType.Yoyo);
    }

    //название поменять
    private void CheckBorder()
    {
        if (transform.position.y < _minHeight && _direction == -1)
            _direction = 0;

        if (transform.position.y > _maxHeight && _direction == 1)
            _direction = 0;
    }

    public void MoveUp()
    {
        _direction = 1;
    }

    public void MoveDown()
    {
        _direction = -1;
    }

    public void StopMove()
    {
        _direction = 0;
    }
}