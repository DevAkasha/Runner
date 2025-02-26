using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public GameObject itemEffectPrefab; // ¿ŒΩ∫≈œΩ∫∑Œ πŸ≤„¡‡æﬂ «ÿ!!
    public float destroyDelay = 0.1f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            PlayerAction player = collision.GetComponentInParent<PlayerAction>();
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
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
}
