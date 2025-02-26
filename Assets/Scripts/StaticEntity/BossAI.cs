using System.Collections;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Boss boss;

    private bool skillAReady = true;
    private bool skillBReady = true;
    public bool ActionEnd =true;

    void Start()
    {
        boss = GetComponent<Boss>();
        StartCoroutine(BossBehavior());
    }

    IEnumerator BossBehavior()
    {
        while (ActionEnd)
        {
            float ActionDelay = 2f;
            if (boss.currentHealth <= boss.maxHealth * 0.5f) ActionDelay = 1.5f;
            if (boss.currentHealth <= boss.maxHealth * 0.2f) ActionDelay = 1f;
            yield return new WaitForSeconds(ActionDelay); // �ൿ ����

            // �ൿ Ȯ�� ����
            float action = Random.Range(0f, 100f);

            if (skillBReady && action < 30f)
            {
                StartCoroutine(UseSkillB(ActionDelay * 4));
            }

            else if (skillAReady && action > 75f && ActionDelay < 1.9f)
            {
                StartCoroutine(UseSkillA(ActionDelay*6));
            }

            else if (action > 30f && action < 60f&&ActionDelay < 1.4f)
            {
                boss.MeleeAttack();
            }

            else
            {
                boss.RangedAttack();
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

    // ��ų ��ٿ� �ڷ�ƾ
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