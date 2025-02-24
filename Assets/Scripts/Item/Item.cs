using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public float destroyDelay = 0.1f;

    protected abstract void ApplyEffect();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyEffect();
            Destroy(gameObject,destroyDelay);
        }
    }

}
