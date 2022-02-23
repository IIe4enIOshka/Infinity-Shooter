using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            GiveLife(player);
        }
    }

    private void GiveLife(Player player)
    {
        player.TakeLife(_health);
        Destroy(gameObject);
    }
}
