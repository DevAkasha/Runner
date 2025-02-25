using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int scoreValue;

    protected override void ApplyEffect(PlayerAction player)
    {
        GameManager.Instance.AddScore(scoreValue);
    }
    protected override void ApplyEffect(PlayerAttack playerAttack,int hitMultiplier)
    {
        GameManager.Instance.AddScore(scoreValue* hitMultiplier);
    }
}
