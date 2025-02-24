using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject cannonBall;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
        }
    }

    public void CreateCannonBall()
    {
        if(cannonBall == null)
        {
            Debug.Log("CannonBall is Null");
            return;
        }
        GameObject newCannonBall = Instantiate(cannonBall, transform.parent.position, Quaternion.identity);
    }
}
