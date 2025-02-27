using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectRemover : MonoBehaviour
{
    //트리거 충돌 감지 (isTrigger 체크된 경우)
    private void OnTriggerEnter2D(Collider2D other)
    {
        RemoveObject(other.gameObject);
    }

    //일반 충돌 감지 (물리 충돌)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RemoveObject(collision.gameObject);
    }

    private void RemoveObject(GameObject obj)
    {
        if (obj.CompareTag("Player")) return; // 플레이어는 삭제하지 않음
        Destroy(obj);
    }
}

