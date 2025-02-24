using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public int healAmount = 2;

    protected override void ApplyEffect(Player player)
    {
        player.Heal(healAmount);
    }
}
