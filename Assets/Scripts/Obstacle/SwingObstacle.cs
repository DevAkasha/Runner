using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwingObstacle : TriggerObstacle
{
    [SerializeField] private float swingTime = 3.0f;
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
        CheckTrigger();

        CheckPlayerInTrigger();
    }

    protected override void Action(Collider2D playerCollider)
    {
        base.Action(playerCollider);

        player = playerCollider.transform;

        // swingAnchor가 null이면 실행 (한번만 실행하기 위해)
        if (swingAnchor == null)
            swingAnchor = StartCoroutine(SwingAnchorCo());
    }

    private IEnumerator SwingAnchorCo()
    {
        // trigger와 anchor 사이의 x 축 거리 측정
        float offsetX = transform.position.x - trigger.position.x;

        // z 각도를 euler 각으로 얻어오기
        Quaternion q = transform.rotation;
        float z = q.eulerAngles.z;

        // lerp 비율
        float lerpValue = 0;

        // lerpValue가 1보다 클 때까지 반복 실행
        while (lerpValue < 1)
        {
            // 매 프레임마다 플레이어와 anchor 사이의 x 축 거리 측정
            float distance = transform.position.x - player.position.x;

            // 비율 측정
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
