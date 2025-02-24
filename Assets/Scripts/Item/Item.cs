using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float destroyDelay = 0.1f;
    private bool isdestroyed = false;

    protected abstract void ApplyEffect(PlayerAction player);
    protected virtual void ApplyEffect(PlayerAttack playerAttack)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                ApplyEffect(playerAttack);
                isdestroyed = true;
                Destroy(gameObject, destroyDelay);
            }
        }
        else if (collision.CompareTag("Player")&&!isdestroyed)
        {
            PlayerAction player = collision.GetComponent<PlayerAction>();
            if (player != null)
            {
                ApplyEffect(player);
                Destroy(gameObject, destroyDelay);
            }
        }
    }
}
