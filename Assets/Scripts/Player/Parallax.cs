using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 prallaxEffectMultiplier;

    private Transform mainCamera;
    private Vector3 lastCameraPosition;

    void Start()
    {
        mainCamera = Camera.main.transform;
        lastCameraPosition = mainCamera.position;
    }


    void LateUpdate()
    {
        Vector3 deltamovement = mainCamera.position - lastCameraPosition;
        transform.position += new Vector3(deltamovement.x * prallaxEffectMultiplier.x, deltamovement.y * prallaxEffectMultiplier.y);

        lastCameraPosition = mainCamera.position;
    }
}
