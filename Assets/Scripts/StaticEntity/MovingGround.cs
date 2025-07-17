using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingGround : MonoBehaviour
{
    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(-0.1f, 0f, 0f);
    }
}
