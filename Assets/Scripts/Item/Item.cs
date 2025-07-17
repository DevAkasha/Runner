using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float destroyDelay = 0.1f;
    public bool isdestroyed = false;
    [SerializeField] bool OnlyPlayer;
    [SerializeField] bool OnlyPlayerAttack;

    protected abstract void ApplyEffect(PlayerAction player);
    protected virtual void ApplyEffect(PlayerAction player, int hitMultiplier){ }
    protected virtual void ApplyEffectBoss(Boss boss) { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack")&& !OnlyPlayer)
        {
            PlayerAction player = collision.GetComponentInParent<PlayerAction>();
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                ApplyEffect(player, playerAttack.hitMultiplier);
                isdestroyed = true;
                Destroy(gameObject, destroyDelay);
            }
            else
            {
                Boss boss = collision.GetComponent<Boss>();
                ApplyEffectBoss(boss);
            }
        }
        else if (collision.CompareTag("Player")&&!isdestroyed&&!OnlyPlayerAttack)
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
