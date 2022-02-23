using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clock))]
public class ClockMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _leftBorder = -11;
    private Clock _clock;

    private bool _isDead;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _clock = GetComponent<Clock>();
        _clock.DeadChanged += OnDeadChanged;
    }

   
    private void OnDisable()
    {
        _clock.DeadChanged -= OnDeadChanged;
    }

    private void OnDeadChanged(bool isDead)
    {
        _isDead = isDead;
    }


    private void Update()
    {
        if(_isDead == false)
            transform.position = new Vector3(transform.position.x - _speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < _leftBorder)
            Destroy(gameObject);
    }
}
