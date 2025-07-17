using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public int healAmount = 2;
    protected override void ApplyEffect(PlayerAction player)
    {
        player.Heal(healAmount);
        SoundManager.Instance.PlaySFX(4);
    }
   
    protected override void ApplyEffect(PlayerAction player, int hitMultiplier)
    {
        player.Heal(healAmount * hitMultiplier);
        SoundManager.Instance.PlaySFX(4);
    }
}
