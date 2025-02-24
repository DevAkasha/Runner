using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPotion : Item
{
    public float duration = 3f;

    protected override void ApplyEffect(Player player)
    {
        player.StartCoroutine(player.BecomeInvincible(duration));
    }
}
