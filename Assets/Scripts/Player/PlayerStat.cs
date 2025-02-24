using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private float hp;              // 체력
    public float HP { get { return hp; } set { hp = value; if (hp <= 0) hp = 0; if (hp >= maxHP) hp = maxHP; } }
    [SerializeField] private float maxHP;           // 최대 체력
    [SerializeField] private float dereaseAmount;   // 체력 감소량
    [SerializeField] private float speed;           // 스피드
    public float Speed { get; set; }
    [SerializeField] private int addJumpCount;      // 추가 점프 가능 수
    public int AddJumpCount { get => addJumpCount; }

    private void Start()
    {
        HP = maxHP;
        Speed = speed;
    }
}

