using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    [SerializeField] private float swingTime = 3.0f;
    [SerializeField] private Transform trigger;     // trigger ������ �ϴ� ������Ʈ
    private Transform player;

    Coroutine swingAnchor;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == null)
        {
            Debug.Log("Trigger is Null");
            return; 
        }

        CheckPlayerInTrigger();
    }

    // Ʈ���� ���� �ȿ� �÷��̾ ���Դ��� üũ
    private void CheckPlayerInTrigger()
    {
        // trigger�� ��ġ�� ����� �°� overlapBox�� �����ϰ� �ȿ� collider�� �ִ��� �Ǵ�
        Vector2 size = trigger.GetComponent<BoxCollider2D>().size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(trigger.position, size, 0);

        for (int i = 0; i < colliders.Length; i++)
        {
            // �ڽ� ���� �ȿ� player collider�� �ִٸ� swingAnchor ����
            if (colliders[i].CompareTag("Player"))
            {
                player = colliders[i].transform;

                // swingAnchor�� null�̸� ���� (�ѹ��� �����ϱ� ����)
                if (swingAnchor == null)
                    swingAnchor = StartCoroutine(SwingAnchorCo());
            }
        }
    }

    private IEnumerator SwingAnchorCo()
    {
        // trigger�� anchor ������ x �� �Ÿ� ����
        float offsetX = transform.position.x - trigger.position.x;

        // z ������ euler ������ ������
        Quaternion q = transform.rotation;
        float z = q.eulerAngles.z;

        // lerp ����
        float lerpValue = 0;

        // lerpValue�� 1���� Ŭ ������ �ݺ� ����
        while (lerpValue < 1)
        {
            // �� �����Ӹ��� �÷��̾�� anchor ������ x �� �Ÿ� ����
            float distance = transform.position.x - player.position.x;

            // ���� ����
            lerpValue = -(distance / offsetX); // -1 ~ 1;
            lerpValue = ((lerpValue + 1) / 2); // 0 ~ 1

            z = Mathf.LerpAngle(60f, -60f, lerpValue);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, z));

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(trigger.position, trigger.GetComponent<BoxCollider2D>().size);
    }
}
