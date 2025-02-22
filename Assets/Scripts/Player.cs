using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float jumpForce = 10f;
    float slideDuration = 1f;
    float moveSpeed = 5f;

    float groundCheckRadius = 0.2f;
    [SerializeField]Transform groundCheck;
    [SerializeField]LayerMask groundMask;

    Rigidbody2D rb;
    CapsuleCollider2D cl;
    Vector2 originColliderSize;
    Vector2 originColliderOffset;

    int maxJumpCount = 2;
    int jumpCount = 0;

    bool isGrounded = false;
    bool isSliding = false;

    PlayerInput input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<CapsuleCollider2D>();

        originColliderSize = cl.size;
        originColliderOffset = cl.offset;

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
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    void Jump()
    {
        if (jumpCount >= maxJumpCount) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;
    }

    IEnumerator Slide()
    {
        if (isSliding || !isGrounded) yield break;
        isSliding =true;

        cl.size = new Vector2(originColliderSize.x, originColliderSize.y*0.5f);
        cl.offset = new Vector2(originColliderOffset.x, originColliderOffset.y-(originColliderSize.y*0.25f));

        Debug.Log("슬라이딩 하고있어요!!");
        yield return new WaitForSeconds(slideDuration);

        cl.size = originColliderSize;
        cl.offset = originColliderOffset;
        isSliding = false;
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
