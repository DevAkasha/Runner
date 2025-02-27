using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : Item
{
    public float addSpeed = 3f;
    public float duration = 3f;

    protected override void ApplyEffect(PlayerAction player)
    {
        player.StartCoroutine(player.IncreaseSpeed(addSpeed, duration));
        SoundManager.Instance.PlaySFX(5);
    }
    protected override void ApplyEffect(PlayerAction player, int hitMultiplier)
    {
        player.StartCoroutine(player.IncreaseSpeed(addSpeed, duration* hitMultiplier));
        SoundManager.Instance.PlaySFX(5);
    }
}
