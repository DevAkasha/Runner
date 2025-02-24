using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Item
{
    [SerializeField] private float speed = 1.0f;

    private void Start()
    {
        Invoke("DestroyCannonBall", 5f);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    private void DestroyCannonBall()
    {
        Destroy(gameObject);
    }

    protected override void ApplyEffect(Player player)
    {

    }
}
