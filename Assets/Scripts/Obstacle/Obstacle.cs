using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float flyPower; // 날아가는 힘
    private bool isFly = false;              // 날아간 적이 있는지 확인

    private void Start()
    {
        if(damage <= 0)
            damage = 10;

        if(flyPower <= 0)
            flyPower = 10f;
    }

    // 장애물이 날아가는 함수
    public void FlyObatacle()
    {
        if (isFly) return;

        isFly = true;
        Rigidbody2D rigid = transform.AddComponent<Rigidbody2D>();

        // 날아갈 방향
        Vector2 direction = new Vector2(1, Random.Range(-0.5f, 0.5f));

        rigid.AddForce(direction * flyPower, ForceMode2D.Impulse);
        rigid.AddTorque(flyPower, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerAction player = collision.GetComponent<PlayerAction>();
            if(player != null)
            {
                if (!player.isInvincible)
                    player.Damage(damage);
                else
                    FlyObatacle();
            }
        }
    }
}
