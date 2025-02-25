using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int scoreValue;
    public GameObject itemEffect;

    protected override void ApplyEffect(PlayerAction player)
    {
        GameManager.Instance.AddScore(scoreValue);
        PlayEffect();
    }
    protected override void ApplyEffect(PlayerAction player,int hitMultiplier)
    {
        GameManager.Instance.AddScore(scoreValue* hitMultiplier);
        PlayEffect();
    }

    public GameObject PlayEffect()
    {
        if (itemEffect != null)
        {
            return Instantiate(itemEffect, transform.position, Quaternion.identity);
        }

        Destroy(itemEffect);

        return null;


    }
}
