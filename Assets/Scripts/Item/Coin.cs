using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int ScoreValue = 500;
    public GameObject itemEffect;

    protected override void ApplyEffect(Player player)
    {
        GameManager.Instance.AddScore(ScoreValue);
        PlayEffect();
    }

    public GameObject PlayEffect()
    {
        if(itemEffect != null)
        {
            return Instantiate(itemEffect, transform.position, Quaternion.identity);
        }

        return null;
    }
}
