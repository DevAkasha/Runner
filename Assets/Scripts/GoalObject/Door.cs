using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerObstacle
{
    [SerializeField] Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        trigger = transform.GetChild(1);
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckTrigger();

        CheckPlayerInTrigger();
    }

    protected override void Action(Collider2D playerCollider)
    {
        base.Action(playerCollider);

        if (isOpen) return;

        isOpen = true;
        animator.SetTrigger("IsOpen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // 종료 UI 나타나야함
            Debug.Log("RunEnd");
        }
    }
}
