using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerAction player = collision.GetComponent<PlayerAction>();
            if(player != null)
            {
                player.Damage(damage);
            }
        }
    }
}
