using System.Collections;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Boss boss;

    private bool skillAReady = true;
    private bool skillBReady = true;
    public bool actionEnd =true;

    void Start()
    {
        boss = GetComponent<Boss>();
        StartBossBehavior();
    }
    public void StartBossBehavior()
    {
        StartCoroutine(BossBehavior());
    }

    IEnumerator BossBehavior()
    {
        while (true)
        {
            int count = 1;
            float ActionDelay = 2f;
            if (boss.currentHealth <= boss.maxHealth * 0.5f) ActionDelay = 1.5f; 
            if (boss.currentHealth <= boss.maxHealth * 0.2f) ActionDelay = 1f;

            yield return new WaitForSeconds(ActionDelay); // 행동 간격

            // 행동 확률 설정
            float action = Random.Range(0f, 100f);

            if (skillBReady && action < 25f)
            {
                StartCoroutine(UseSkillB(ActionDelay * 4));
            }

            else if (skillAReady && action > 75f && ActionDelay < 1.9f)
            {
                StartCoroutine(UseSkillA(ActionDelay*6));
            }

            else if (action > 40f && action < 60f&&ActionDelay < 1.4f)
            {
                StartCoroutine(boss.MeleeAttack());
                yield break;
            }

            else
            {
                count = (action > 50f) ? 4 : 2;
                boss.RangedAttack(count);
            }
        }
    }


    IEnumerator UseSkillA(float duration)
    {
        skillAReady = false;
        boss.Jump();
        yield return CooldownSkillA(duration);
    }

    IEnumerator UseSkillB(float duration)
    {
        skillBReady = false;
        boss.SkillB();
        yield return CooldownSkillB(duration);
    }

    // 스킬 쿨다운 코루틴
    IEnumerator CooldownSkillA(float duration)
    {
        yield return new WaitForSeconds(duration);
        skillAReady = true;
    }

    IEnumerator CooldownSkillB(float duration)
    {
        yield return new WaitForSeconds(duration);
        skillBReady = true;
    }
}