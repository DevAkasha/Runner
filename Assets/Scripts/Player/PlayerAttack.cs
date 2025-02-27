using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D atkcollider;
    [SerializeField] private float duration;
    public bool isCoolTime = false;
    public int hitMultiplier;
    private float cooltime = 0.0f;

    private void Update()
    {
        if (isCoolTime)
        {
            cooltime += Time.deltaTime;
            if (cooltime > 0.5&& atkcollider.enabled)
            {
                atkcollider.enabled = false;
            }
            if (cooltime > duration)
            {
                isCoolTime = false;
                cooltime = 0.0f;
            }
        }
    }

    private void Awake()
    {
        atkcollider = GetComponent<BoxCollider2D>();
        atkcollider.enabled = false;
    }

    public void ActiveAttack()
    {
        if (!isCoolTime)
        {
            atkcollider.enabled = true;
            isCoolTime = true;
        }
    }
}
