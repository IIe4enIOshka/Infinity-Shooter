using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Energy : MonoBehaviour
{
    [SerializeField] private int _energy = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            GiveEnergy(player);
        }
    }

    private void GiveEnergy(Player player)
    {
        player.TakeEnergy(_energy);
        Destroy(gameObject);
    }
}
