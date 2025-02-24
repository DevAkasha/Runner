using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField] private float speed;         // 플레이어 스피드
    [SerializeField] private float jumpHeight;     // 점프 높이

    [SerializeField] private float rayLength;     // Ray 길이


    [SerializeField] private bool isGround;       // 땅에 닿아있는지 확인 
    [SerializeField] private bool isSlide;        // 슬라이드 중인지 확인
    [SerializeField] bool checkDoubleJump = false;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        CheckGround();

        Jump();

        Slide();

        animator.SetFloat("VelocityY", rigid.velocity.y);
        animator.SetBool("IsGround", isGround);
        animator.SetBool("IsSlide", isSlide);
    }
    
    private void Move()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);  // 플레이어 이동
    }

    private void CheckGround()
    {
        RaycastHit2D hitData;
        hitData = Physics2D.Raycast(transform.position, Vector3.down, rayLength, LayerMask.GetMask("Ground"));

        isGround = hitData.collider != null;

        if (isGround == true) checkDoubleJump = true;
    }

    private void Jump()
    {
        // 바닥에 닿아있고 스페이스키를 눌렀을 때 점프
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        // 바닥에 닿아있지 않다면 더블 점프 체크 변수를 확인하고 점프
        else if(!isGround && Input.GetKeyDown(KeyCode.Space))
        {
            if (!checkDoubleJump) return;

            checkDoubleJump = false;
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void Slide()
    {
        if (isGround && Input.GetKey(KeyCode.LeftShift))
        {
            isSlide = true;
        }
        else
        {
            isSlide = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
    }
}
