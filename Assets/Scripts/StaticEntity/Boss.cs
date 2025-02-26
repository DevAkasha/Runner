
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Settings")]
    public float maxHealth = 1000f;
    public float currentHealth;

    public float meleeDamage = 20f;
    public float fireRate = 0.1f;

    public float jumpForce = 5f;
    public Transform rangedAttackPoint;
    public GameObject RAProjectilePrefab;
    public GameObject SkillBProjectilePrefab;
    public GameObject SkillAProjectilePrefab;

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
        //currentHealth = maxHealth;
        playerTransform = FindAnyObjectByType<PlayerAction>().transform;
        bossAI = GetComponent<BossAI>();
    }

    // 2. 기본 공격 - 근접
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
        // 여기에 근접 공격 판정 로직 추가
        yield return null;
        yield return new WaitForSeconds(CalculateAnimationLength("Attack"));

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


    // 3. 기본 공격 - 원거리
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
            Instantiate(RAProjectilePrefab, rangedAttackPoint.position, Quaternion.identity);
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
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        animator.SetTrigger("IsHit");

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

