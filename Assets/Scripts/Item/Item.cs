using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float destroyDelay = 0.1f;

    protected abstract void ApplyEffect(Player player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                ApplyEffect(player);
                Destroy(gameObject, destroyDelay);
            }
        }
    }
}
