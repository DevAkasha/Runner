using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStoneEffect : MonoBehaviour
{
    public GameObject gemStoneEffectPrefab;
    public float destroyDelay = 0.1f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                GameObject effectInstance = GemAttackEffect();
                if (effectInstance != null)
                {
                    Destroy(effectInstance, destroyDelay);
                }
            }
        }
    }

    public GameObject GemAttackEffect()
    {
        if (gemStoneEffectPrefab != null)
        {
            GameObject attackEffectIstance = Instantiate(gemStoneEffectPrefab, transform.position, Quaternion.identity);
            return attackEffectIstance;
        }
        return null;
    }
}
