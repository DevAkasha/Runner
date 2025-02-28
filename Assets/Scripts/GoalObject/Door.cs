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
}
