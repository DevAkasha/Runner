using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D atkcollider;
    [SerializeField] private float duration = 0.5f;
    public bool isCoolTime = false; 
    private float cooltime = 0.0f;

    private void Update()
    {
        if (isCoolTime)
        {
            cooltime += Time.deltaTime;
            if (cooltime > duration)
            {
                atkcollider.enabled = false;
                isCoolTime = false;
                cooltime = 0.0f;
            }
        }
    }

    private void Awake()
    {
        atkcollider = GetComponent<BoxCollider2D>();
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
