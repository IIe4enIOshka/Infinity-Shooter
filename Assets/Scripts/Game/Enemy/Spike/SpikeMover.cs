using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Enemy))]
public class SpikeMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Enemy _enemy;
    private float _leftBorder = -11;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();

        Sequence sequence = DOTween.Sequence(); 

        sequence.Append(transform.DOMoveX(5, 2));
        sequence.Append(transform.DOMove(_enemy.Player.transform.position, 0.5f).SetDelay(2));
        sequence.Append(transform.DOMoveX(-15, 0.5f));
    }

    private void Update()
    {
        //transform.position = new Vector3(transform.position.x - _speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < _leftBorder)
            Destroy(gameObject);
    }
}
