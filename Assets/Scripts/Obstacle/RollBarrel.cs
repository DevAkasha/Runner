using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class RollBarrel : TriggerObstacle
{
    [SerializeField] private float moveSpeed;   // 이동 속도
    [SerializeField] private float rollSpeed;   // 회전 속도
    private bool isRoll = false;            // 구르기가 가능한지 확인

    private void Start()
    {
        if (moveSpeed <= 0)
            moveSpeed = 3f;

        if (rollSpeed <= 0)
            rollSpeed = 30f;
    }

    private void Update()
    {
        CheckTrigger();

        CheckPlayerInTrigger();

        Roll();
    }

    protected override void Action(Collider2D playerCollider)
    {
        base.Action(playerCollider);

        if (isRoll) return;
        isRoll = true;
    }

    private void Roll()
    {
        if (!isRoll) return;

        transform.parent.parent.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        transform.parent.Rotate(new Vector3(0, 0, rollSpeed * Time.deltaTime));
    }
}
