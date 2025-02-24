using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 조건 변경 필요
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
        }
    }

    // Cannon_Shoot 애니메이션에 연결 되어있음
    public void CreateCannonBall()
    {
        if(cannonBall == null)
        {
            Debug.Log("CannonBall is Null");
            return;
        }
        // 대포알 생성
        GameObject newCannonBall = Instantiate(cannonBall, transform.parent.position, Quaternion.identity);
    }
}
