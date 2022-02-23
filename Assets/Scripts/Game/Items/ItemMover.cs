using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _leftBorder = -11;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x - _speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < _leftBorder)
            Destroy(gameObject);
    }
}
