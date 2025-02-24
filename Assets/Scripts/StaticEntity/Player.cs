using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [Header("Status")]
    float jumpForce = 10f;
    float slideDuration = 1f;
    float moveSpeed = 5f;
    int maxHealth = 10;

    int currentHealth;
    bool isInvincible;

    Rigidbody2D PlayerRB;
    float groundCheckRadius = 0.2f;
    [SerializeField]Transform groundCheck;
    [SerializeField]LayerMask groundMask;

    CapsuleCollider2D PlayerCC;
    Vector2 originColliderSize;
    Vector2 originColliderOffset;

    int maxJumpCount = 2;
    int jumpCount = 0;

    bool isGrounded = false;
    bool isSliding = false;

    PlayerInput input;

    void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerCC = GetComponent<CapsuleCollider2D>();

        originColliderSize = PlayerCC.size;
        originColliderOffset = PlayerCC.offset;

        input = new PlayerInput();
        input.Player.Jump.performed += ctx => Jump();
        input.Player.Slide.performed += ctx => StartCoroutine(Slide());
    }

    void OnEnable() => input.Enable();
    void OnDisable() => input.Disable();

    //점프,슬라이드,
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (isGrounded)
        {
            jumpCount = 0;
        }
        
    }
    void FixedUpdate()
    {
        PlayerRB.velocity = new Vector2(moveSpeed, PlayerRB.velocity.y);
    }
    void Jump()
    {
        if (jumpCount >= maxJumpCount) return;
        PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpForce);
        jumpCount++;
    }

    IEnumerator Slide()
    {
        if (isSliding || !isGrounded) yield break;
        isSliding =true;

        PlayerCC.size = new Vector2(originColliderSize.x, originColliderSize.y*0.5f);
        PlayerCC.offset = new Vector2(originColliderOffset.x, originColliderOffset.y-(originColliderSize.y*0.25f));

        Debug.Log("슬라이딩 하고있어요!!");
        yield return new WaitForSeconds(slideDuration);

        PlayerCC.size = originColliderSize;
        PlayerCC.offset = originColliderOffset;
        isSliding = false;
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    public IEnumerator BecomeInvincible(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }
    public IEnumerator IncreaseSpeed (float addSpeed, float duration)
    {
        moveSpeed += addSpeed;
        yield return new WaitForSeconds(duration);
        moveSpeed -= addSpeed;
    }
    //감지 확인용
    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

}
