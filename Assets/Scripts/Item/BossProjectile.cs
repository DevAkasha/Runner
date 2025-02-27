using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class BossProjectile : Item
{
    public int power= 20;
    public float startDelay = 0.5f;
    private float time;
    private bool isCreate;
    public float speed = -50f;

    private void Update()
    {
        if(time < startDelay)
        {
            time += Time.deltaTime;
            if (time >= startDelay)
            {
                isCreate = true;
            }
        }
       
    }
    private void FixedUpdate()
    {
        if(isCreate)
            transform.position = transform.position + new Vector3(speed, 0, 0);
    }

    protected override void ApplyEffect(PlayerAction player)
    {
        player.Damage(power);
    }
    protected override void ApplyEffect(PlayerAction player, int hitMultiplier)
    {
        //player 가 null일 경우 보스피격
        if (player == null)
        {
            FindAnyObjectByType<Boss>().GetComponent<Boss>().TakeDamage(power);
        }
        //속도가 -0.25f보다 큰 것(느린 것)만 반사가능
        else if (speed>-0.25f) speed = -speed;
    }
    protected override void ApplyEffectBoss(Boss boss)
    {
        boss.TakeDamage(power);
    }
}
