using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int scoreValue;

    protected override void ApplyEffect(PlayerAction player)
    {
        GameManager.Instance.AddScore(scoreValue);
        SoundManager.Instance.PlaySFX(0);
    }
    protected override void ApplyEffect(PlayerAction player,int hitMultiplier)
    {
        GameManager.Instance.AddScore(scoreValue* hitMultiplier);
        SoundManager.Instance.PlaySFX(0);
    }
}
