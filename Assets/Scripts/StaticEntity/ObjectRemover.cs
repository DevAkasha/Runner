using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectRemover : MonoBehaviour
{
    //Ʈ���� �浹 ���� (isTrigger üũ�� ���)
    private void OnTriggerEnter2D(Collider2D other)
    {
        RemoveObject(other.gameObject);
    }

    //�Ϲ� �浹 ���� (���� �浹)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RemoveObject(collision.gameObject);
    }

    private void RemoveObject(GameObject obj)
    {
        if (obj.CompareTag("Player")) return; // �÷��̾�� �������� ����
        Destroy(obj);
    }
}

