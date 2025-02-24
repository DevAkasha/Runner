using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rigid;

    private Animator animator;

    private CapsuleCollider2D collider;

    private PlayerStat playerStat;

    private PlayerAttack playerAttack;

    [SerializeField] private float jumpHeight;      // 점프 높이
    [SerializeField] private float rayLength;        // Ray 길이

    [SerializeField] private bool isGround;         // 땅에 닿아있는지 확인 
    [SerializeField] private bool isSlide;          // 슬라이드 중인지 확인
    [SerializeField] private bool isInvincible;     //무적인지 아닌지
    [SerializeField] private int jumpCount;         // 현재 남은 점프 수

    // 초기 Collider 설정 값
    private Vector2 colliderOffset;
    private Vector2 colliderSize;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        playerStat = GetComponent<PlayerStat>();
        playerAttack = GetComponentInChildren<PlayerAttack>();

        colliderOffset = collider.offset;
        colliderSize = collider.size;

        jumpCount = playerStat.AddJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        CheckGround();

        Jump();

        Slide();

        Attack();

        animator.SetFloat("VelocityY", rigid.velocity.y);
        animator.SetBool("IsGround", isGround);
        animator.SetBool("IsSlide", isSlide);
    }
    
    private void Move()
    {
        rigid.velocity = new Vector2(playerStat.Speed, rigid.velocity.y);  // 플레이어 이동
    }

    private void CheckGround()
    {
        RaycastHit2D hitData;
        hitData = Physics2D.Raycast(transform.position, Vector3.down, rayLength, LayerMask.GetMask("Ground"));

        isGround = hitData.collider != null;

        if (isGround == true) jumpCount = playerStat.AddJumpCount;
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
            if (jumpCount <= 0) return;

            //checkDoubleJump = false;
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    private void Slide()
    {
        // 땅에 있고 Shitf키를 누르면 슬라이드
        if (isGround && Input.GetKey(KeyCode.LeftShift))
        {
            isSlide = true;

            collider.direction = CapsuleDirection2D.Horizontal;
            collider.size = new Vector2(colliderSize.y, colliderSize.x);
            collider.offset = new Vector2(colliderOffset.x, - 0.2f);
        }
        else
        {
            isSlide = false;

            collider.direction = CapsuleDirection2D.Vertical;
            collider.size = new Vector2(colliderSize.x, colliderSize.y);
            collider.offset = new Vector2(colliderOffset.x, colliderOffset.y);
        }
    }

    private void Attack()
    {
        if(!isSlide&& Input.GetKey(KeyCode.Z))
        {
            animator.SetTrigger("IsAttack");
            playerAttack.gameObject.SetActive(false);
        }
            
    }
    public void Heal(int amount)
    {
        playerStat.HP += amount;
    }

    public IEnumerator BecomeInvincible(float duration)
    {
        //Todo. 무적효과 구현해야 함.
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }
    public IEnumerator IncreaseSpeed(float addSpeed, float duration)
    {
        playerStat.Speed += addSpeed;
        yield return new WaitForSeconds(duration);
        playerStat.Speed -= addSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
    }


}
