
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Settings")]
    public int maxHealth = 1000;
    public int currentHealth;

    public int meleeDamage = 20;
    public float fireRate = 0.07f;

    public float jumpForce = 5f;
    public Transform rangedAttackPoint;
    public GameObject RAProjectilePrefab;
    public GameObject SkillBProjectilePrefab;
    public GameObject SkillAProjectilePrefab;
    public BoxCollider2D attackCollider;

    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;
    private Transform playerTransform;
    private Vector3 prePosition;
    private BossAI bossAI;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        playerTransform = FindAnyObjectByType<PlayerAction>().transform;
        bossAI = GetComponent<BossAI>();
    }

    // 근접 공격 행동
    public IEnumerator MeleeAttack()
    {
        if (isDead) yield break;     
        Debug.Log("Boss가 근거리 공격을 함!");

        animator.SetTrigger("IsTeleportStart");
        yield return null;
        yield return new WaitForSeconds(CalculateAnimationLength("TeleportStart"));

        prePosition = transform.position;
        transform.position = playerTransform.position + new Vector3(2f, 1.6f, 0f);

        animator.SetTrigger("IsTeleportEnd");
        yield return null;
        yield return new WaitForSeconds(CalculateAnimationLength("TeleportEnd"));

        animator.SetTrigger("IsAttack");
        yield return new WaitForSeconds(0.2f);
        attackCollider.enabled = true;
        yield return new WaitForSeconds(CalculateAnimationLength("Attack") - 0.4f);
        attackCollider.enabled = false;
        yield return new WaitForSeconds(0.2f);

        animator.SetTrigger("IsTeleportStart");
        yield return null;
        yield return new WaitForSeconds(CalculateAnimationLength("TeleportStartB"));

        transform.position = prePosition;

        animator.SetTrigger("IsTeleportEnd");
        yield return null;
        yield return new WaitForSeconds(CalculateAnimationLength("TeleportEndB"));

        animator.SetTrigger("IsAttackEnd");
        bossAI.StartBossBehavior();

        float CalculateAnimationLength(string animationName)
        {
            AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo(0);
            if (animState.IsName(animationName))
                return animState.length;
            else return 1f;
        }
    }

    // 근접 공격 적용
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAction>().Damage(meleeDamage);
        }
    }


    // 기본 공격 - 원거리
    public void RangedAttack(int count)
    {
        if (isDead) return;
        animator.SetTrigger("IsRangeAttack");
        StartCoroutine(ShootRoutine(count));
        Debug.Log("Boss가 원거리 공격을 함!");
    }

    IEnumerator ShootRoutine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(RAProjectilePrefab, rangedAttackPoint.position + new Vector3(0,i*0.3f,0), Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }
    }

    // 5. 스킬 B
    public void SkillB()
    {
        if (isDead) return;
        animator.SetTrigger("IsSkillB");
        Debug.Log("Boss가 스킬 B를 사용함!");
        Instantiate(SkillBProjectilePrefab, rangedAttackPoint.position, Quaternion.identity);
    }

    // 6. 피격 처리
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        animator.SetTrigger("IsHit");
        currentHealth -= damage;
       
        Debug.Log($"Boss가 {damage} 만큼 피해를 입음. 남은 체력: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Jump()
    {
        if (isDead) return;
        animator.SetTrigger("IsJump");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        Instantiate(SkillAProjectilePrefab, rangedAttackPoint.position, Quaternion.identity);
        Debug.Log("Boss가 점프함!");
    }

    // 8. 사망 처리
    private void Die()
    {
        isDead = true;
        animator.SetTrigger("IsDie");
        Debug.Log("Boss가 사망함!");
        // 이후 게임 오브젝트 삭제 또는 사망 연출
        Destroy(gameObject, 3f);
    }

}

