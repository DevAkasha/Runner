using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cannon : TriggerObstacle
{
    [SerializeField] private GameObject cannonBall;     // 총알 프리펩
    [SerializeField] private Transform shootPos;        // 총알이 나갈 위치

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckTrigger();

        CheckPlayerInTrigger();
    }

    protected override void Action(Collider2D playerCollider)
    {
        base.Action(playerCollider);

        animator.SetTrigger("Shoot");
    }

    // Cannon_Shoot 애니메이션에 연결 되어있음
    public void CreateCannonBall()
    {
        if(cannonBall == null)
        {
            Debug.Log("CannonBall is Null");
            return;
        }

        if(shootPos == null)
        {
            Debug.Log("ShootPos is Null");
            shootPos = transform.parent;
        }

        // 대포알 생성
        GameObject newCannonBall = Instantiate(cannonBall, shootPos.position, Quaternion.identity, transform.parent);
    }
}
