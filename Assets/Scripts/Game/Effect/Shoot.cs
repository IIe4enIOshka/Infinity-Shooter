using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float _currentTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("shooting");
    }

    private void Update()
    {
        if (_currentTime >= _duration)
        {
            Destroy(gameObject);
        }

        _currentTime += Time.deltaTime;
    }
}
