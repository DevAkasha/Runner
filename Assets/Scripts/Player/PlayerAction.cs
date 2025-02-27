using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    private SpriteRenderer playerSprite;

    private PlayerAfterImage playerAfterImage;


    public bool isFeverMods = false;                //피버모드인지 아닌지
    public bool isInvincible = false;               //무적인지 아닌지
    public bool makeGhost = false;
    [SerializeField] private float jumpHeight;      // 점프 높이
    [SerializeField] private float rayLength;       // Ray 길이

    [SerializeField] private bool isGround;         // 땅에 닿아있는지 확인
    [SerializeField] private bool isGroundChage;    // isGround가 체인지됐는지 확인
    [SerializeField] private bool isWall = false;

    [SerializeField] private bool isSlide;          // 슬라이드 중인지 확인
    [SerializeField] private bool isSlideChage;     // isSlide가 체인지됐는지 확인
    [SerializeField] private int extraJumpCount;    // 현재 남은 추가점프 수

    [SerializeField] private bool isHit = false;
    [SerializeField] private bool isFreeze = false;
    [SerializeField] private bool isDie = false;    // 플레이어가 죽었는지 확인

    // 초기 Collider 설정 값
    private Vector2 colliderOffset;
    private Vector2 colliderSize;

    public InvincibilityEffect invincibilityEffect;

    public KeyCode jumpKey;
    public KeyCode slideKey;
    public KeyCode attackKey;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        playerStat = GetComponent<PlayerStat>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        playerAfterImage = GetComponent<PlayerAfterImage>();

        colliderOffset = collider.offset;
        colliderSize = collider.size;

        extraJumpCount = playerStat.ExtraJumpCount;

        isDie = false;

        InitKey();
    }

    void InitKey()
    {        
        jumpKey = GameManager.Instance.jumpKey;
        slideKey = GameManager.Instance.slideKey;
        attackKey = GameManager.Instance.attackKey;
    }

    void Update()
    {
        CheckGround();

        if (isFreeze) return;

        Move();

        Jump();

        Slide();

        Attack();

    }


    private void CheckGround()
    {
        bool temp = isGround;

        RaycastHit2D hitData;

        hitData = Physics2D.Raycast(transform.position, Vector3.down, rayLength, LayerMask.GetMask("Ground"));

        isGround = hitData.collider != null;
        isGroundChage = (temp != isGround) ? temp : false;

        if (isGround == true)
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsDown", false);
            extraJumpCount = playerStat.ExtraJumpCount;
        }

        RaycastHit2D wallHit;
        wallHit = Physics2D.Raycast(transform.position, Vector3.right, 0.4f, LayerMask.GetMask("Wall"));
        isWall = wallHit.collider != null;
        if (isWall) rigid.velocity = new Vector2(0f, rigid.velocity.y);
    }

    private void Move()
    {
        if (isWall) return;
        rigid.velocity = new Vector2(playerStat.Speed, rigid.velocity.y);  // 플레이어 이동
        if (!isGround && rigid.velocity.y < 0)
        {
            animator.SetBool("IsDown", true);
            animator.SetBool("IsJump", false);
        }
    }

    private void Jump()
    {
        // 바닥에 닿아있고 스페이스키를 눌렀을 때 점프
        if (isGround && Input.GetKeyDown(jumpKey))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("IsJump", true);
            SoundManager.Instance.PlaySFX(1);
        }
        // 바닥에 닿아있지 않다면 더블 점프 체크 변수를 확인하고 점프
        else if (!isGround && Input.GetKeyDown(jumpKey))
        {
            if (extraJumpCount <= 0) return;

            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            extraJumpCount--;
            animator.SetBool("IsJump", true);
        }
    }

    private void Slide()
    {
        bool temp = isSlide;
        // 땅에 있고 Shitf키를 누르면 슬라이드
        if (isGround && Input.GetKey(slideKey))
        {
            isSlide = true;

            collider.direction = CapsuleDirection2D.Horizontal;
            collider.size = new Vector2(colliderSize.y, colliderSize.x);
            collider.offset = new Vector2(colliderOffset.x, -0.2f);
        }
        else
        {
            isSlide = false;

            collider.direction = CapsuleDirection2D.Vertical;
            collider.size = new Vector2(colliderSize.x, colliderSize.y);
            collider.offset = new Vector2(colliderOffset.x, colliderOffset.y);
        }
        isSlideChage = (temp != isGround) ? true : false;
        if (isSlideChage) animator.SetBool("IsSlide", isSlide);
    }

    private void Attack()
    {
        if (!isSlide && !isHit && Input.GetKeyDown(attackKey))
        {
            SoundManager.Instance.PlaySFX(10);
            if (playerAttack.isCoolTime) return;
            //클래스명.인스턴스.메서드(playerAttack.cooltime);
            animator.SetTrigger("IsAttack");
            playerAttack.ActiveAttack();
        }
    }
    public void Heal(int amount)
    {
        playerStat.HP += amount;
    }
    public void Die()
    {
        if (isDie) return;

        isDie = true;
        SoundManager.Instance.PlaySFX(9);
        isFreeze = true;
        rigid.velocity = new Vector2(0f, rigid.velocity.y);
        animator.SetBool("IsDie", true);
    }

    // 피격 당했을 때
    public void Damage(int amount)
    {
        if (isHit || isDie)
            return;

        SoundManager.Instance.PlaySFX(11);

        playerStat.HP -= amount;

        StartCoroutine(HitCo());
    }

    private IEnumerator HitCo()
    {
        animator.SetTrigger("IsHit");
        isHit = true;

        // hit가 유지되는 시간
        float hitTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(hitTime);

        isHit = false;
    }

    public IEnumerator BecomeInvincible(float duration)
    {
        isInvincible = true;
        invincibilityEffect.gameObject.SetActive(true);
        playerAfterImage.makeGhost = true;
        playerSprite.color = new Color32(199, 255, 216, 255);

        yield return new WaitForSeconds(duration);

        playerSprite.color = Color.white;
        playerAfterImage.makeGhost = false;
        invincibilityEffect.gameObject.SetActive(false);
        isInvincible = false;
    }

    public IEnumerator IncreaseSpeed(float addSpeed, float duration)
    {
        playerStat.Speed += addSpeed;
        yield return new WaitForSeconds(duration);
        playerStat.Speed -= addSpeed;
    }

    public IEnumerator SetFever(float duration)
    {
        SoundManager.Instance.PlaySFX(7);
        GameManager.Instance.feverMultiplier = 2;
        StartCoroutine(BecomeInvincible(duration));
        StartCoroutine(IncreaseSpeed(2f, duration));
        isFeverMods = true;
        yield return new WaitForSeconds(duration);
        GameManager.Instance.feverMultiplier = 1;
        isFeverMods = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
        Gizmos.DrawRay(transform.position, Vector3.right * 0.4f);
    }
}
