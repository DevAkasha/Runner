using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObstacle : MonoBehaviour
{
    [SerializeField] protected Transform trigger;     // trigger 역할을 하는 오브젝트

    // Trigger null check
    protected void CheckTrigger()
    {
        if (trigger == null)
        {
            Debug.Log("Trigger is Null");
            return;
        }
    }

    protected void CheckPlayerInTrigger()
    {
        // trigger의 위치와 사이즈에 맞게 overlapBox를 생성하고 안에 collider가 있는지 판단
        Vector2 size = trigger.GetComponent<BoxCollider2D>().size;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(trigger.position, size, 0);

        for (int i = 0; i < colliders.Length; i++)
        {
            // 박스 범위 안에 player collider가 있다면 swingAnchor 실행
            if (colliders[i].CompareTag("Player"))
            {
                // 자식 오브젝트 함수 필요
                Action(colliders[i]);
            }
        }
    }

    protected virtual void Action(Collider2D playerCollider)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(trigger.position, trigger.GetComponent<BoxCollider2D>().size);
    }
}
