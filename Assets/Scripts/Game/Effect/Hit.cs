using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private float _duration;
    private float _currentTime;

    private void Update()
    {
        if (_currentTime >= _duration)
        {
            Destroy(gameObject);
        }

        _currentTime += Time.deltaTime;
    }
}
