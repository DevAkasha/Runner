using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public GameObject itemEffectPrefab;
    public GameObject attackItemEffectPrefab;
    public float destroyDelay = 0.1f;
    private bool isDestroyed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                GameObject effectInstance = PlayAttackEffect();
                isDestroyed = true;
                if (effectInstance != null)
                {
                    Destroy(effectInstance, destroyDelay);
                }
            }
        }

        else if (collision.CompareTag("Player")&& !isDestroyed)
        {
            PlayerAction player = collision.GetComponent<PlayerAction>();

            if (player != null)
            {
                GameObject effectInstance = PlayEffect();

                if (effectInstance != null)
                {
                    Destroy(effectInstance, destroyDelay);
                }
            }
        }
    }

    public GameObject PlayEffect()
    {
        if (itemEffectPrefab != null)
        {
            GameObject effectInstance = Instantiate(itemEffectPrefab, transform.position, Quaternion.identity);
            return effectInstance;
        }
        return null;
    }

    public GameObject PlayAttackEffect()
    {
        if (attackItemEffectPrefab !=null)
        {
            GameObject attackEffectIstance = Instantiate(attackItemEffectPrefab, transform.position, Quaternion.identity);
            return attackEffectIstance;
        }
        return null;
    }
}
