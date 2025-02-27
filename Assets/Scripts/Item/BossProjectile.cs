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
    protected override void ApplyEffect(PlayerAction playerAttack, int hitMultiplier)
    {
        speed = -speed;
    }

}
