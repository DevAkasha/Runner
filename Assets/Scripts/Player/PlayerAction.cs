using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField] private float speed;         // �÷��̾� ���ǵ�
    [SerializeField] private float jumpHeight;     // ���� ����

    [SerializeField] private float rayLength;     // Ray ����


    [SerializeField] private bool isGround;       // ���� ����ִ��� Ȯ�� 
    [SerializeField] bool checkDoubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        CheckGround();

        Jump();
    }
    
    private void Move()
    {
        rigid.velocity = new Vector2(speed, rigid.velocity.y);  // �÷��̾� �̵�
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
        // �ٴڿ� ����ְ� �����̽�Ű�� ������ �� ����
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        // �ٴڿ� ������� �ʴٸ� ���� ���� üũ ������ Ȯ���ϰ� ����
        else if(!isGround && Input.GetKeyDown(KeyCode.Space))
        {
            if (!checkDoubleJump) return;

            checkDoubleJump = false;
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);
    }
}
