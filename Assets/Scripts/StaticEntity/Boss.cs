
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Settings")]
    public float maxHealth = 1000f;
    public float currentHealth;

    public float meleeDamage = 20f;
    public float rangedDamage = 15f;
    public float skillADamage = 40f;
    public float skillBDamage = 60f;

    public float jumpForce = 5f;
    public Transform rangedAttackPoint;
    public GameObject RAProjectilePrefab;
    public GameObject SkillBProjectilePrefab;

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

    // 2. �⺻ ���� - ����
    public void MeleeAttack()
    {
        if (isDead) return;
        // todo. �׼� Ÿ�̹� �Ұ� �����ؾ���
        Debug.Log("Boss�� �ٰŸ� ������ ��!");

        animator.SetTrigger("IsTeleportStart");
        StartCoroutine(WaitForAnimation("TeleportStart"));

        prePosition = transform.position;
        transform.position = playerTransform.position + new Vector3(3f, 1.6f, 0f);

        animator.SetTrigger("IsTeleportEnd");
        StartCoroutine(WaitForAnimation("TeleportEnd"));

        animator.SetTrigger("IsAttack");
        // ���⿡ ���� ���� ���� ���� �߰�
        StartCoroutine(WaitForAnimation("IsAttack"));

        StartCoroutine(WaitForAnimation("TeleportStart"));

        transform.position = prePosition;

        animator.SetTrigger("IsTeleportEnd");
        StartCoroutine(WaitForAnimation("TeleportEnd"));
        animator.SetTrigger("IsAttackEnd");
        
    }

    // 3. �⺻ ���� - ���Ÿ�
    public void RangedAttack()
    {
        if (isDead) return;
        animator.SetTrigger("IsRangeAttack");
        GameObject projectile = Instantiate(RAProjectilePrefab, rangedAttackPoint.position, Quaternion.identity);
        Debug.Log("Boss�� ���Ÿ� ������ ��!");
    }


    // 5. ��ų B
    public void SkillB()
    {
        if (isDead) return;
        animator.SetTrigger("IsSkillB");
        Debug.Log("Boss�� ��ų B�� �����!");
        GameObject projectile = Instantiate(SkillBProjectilePrefab, rangedAttackPoint.position, Quaternion.identity);
    }

    // 6. �ǰ� ó��
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        animator.SetTrigger("IsHit");

        Debug.Log($"Boss�� {damage} ��ŭ ���ظ� ����. ���� ü��: {currentHealth}");

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
        Debug.Log("Boss�� ������!");
    }

    // 8. ��� ó��
    private void Die()
    {
        isDead = true;
        animator.SetTrigger("IsDie");
        Debug.Log("Boss�� �����!");
        // ���� ���� ������Ʈ ���� �Ǵ� ��� ����
        Destroy(gameObject, 3f);
    }
    IEnumerator WaitForAnimation(string animationName)
    {
        yield return null;
        AnimatorStateInfo animState = animator.GetCurrentAnimatorStateInfo(0);
        while (!animState.IsName(animationName))
        {
            yield return null;
            animState = animator.GetCurrentAnimatorStateInfo(0);
        }
        yield return new WaitForSeconds(animState.length);
    }
}

