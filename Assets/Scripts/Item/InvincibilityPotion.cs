using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPotion : Item
{
    public float duration = 3f;

    protected override void ApplyEffect(PlayerAction player)
    {
        player.StartCoroutine(player.BecomeInvincible(duration));
        SoundManager.Instance.PlaySFX(6);
    }
    protected override void ApplyEffect(PlayerAction player, int hitMultiplier)
    {
        player.StartCoroutine(player.BecomeInvincible(duration*hitMultiplier));
        SoundManager.Instance.PlaySFX(6);
    }
}
