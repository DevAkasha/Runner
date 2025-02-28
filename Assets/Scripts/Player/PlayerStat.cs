using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private float hp;              // 체력
    public float HP { get { return hp; } set { hp = value; if (hp <= 0) { hp = 0; Die(); } if (hp >= maxHP) hp = maxHP; } }
    public float MaxHP { get { return maxHP; } set { } }
    [SerializeField] private float maxHP;           // 최대 체력
    [SerializeField] private float decreaseAmount;   // 체력 감소량
    [SerializeField] private float speed;           // 스피드
    public float Speed { get; set; }
    [SerializeField] private int extraJumpCount;      // 추가 점프 가능 수
    public int ExtraJumpCount { get => extraJumpCount; }

    GameOverUI gameOverUI;

    private void Start()
    {
        HP = maxHP;
        //Speed = speed;

        gameOverUI = FindObjectOfType<GameOverUI>(true);
    }

    private void Die()
    {
        PlayerAction player = GetComponent<PlayerAction>();

        if(gameOverUI != null)
            gameOverUI.SetActive(true);
        if (player != null) player.Die();
        GameManager.Instance.GameOver();
    }
}

