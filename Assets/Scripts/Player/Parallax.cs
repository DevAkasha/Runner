using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera mainCamera;

    private float overallSize;
    private float startpos;

    public float parallaxEffect;


    void Start()
    {
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        if (spriteRenderers.Length == 0)
            return;

        Bounds totalBounds = spriteRenderers[0].bounds;
        for (int i = 1; i < spriteRenderers.Length; i++)
        {
            totalBounds.Encapsulate(spriteRenderers[i].bounds);
        }

        overallSize = totalBounds.size.x;


        startpos = transform.position.x;

        if (mainCamera == null)
            mainCamera = Camera.main;
    }


    void LateUpdate()
    {

        float dist = mainCamera.transform.position.x * parallaxEffect;

        float offset = (dist % overallSize + overallSize) % overallSize;

        transform.position = new Vector3(startpos + offset, transform.position.y, transform.position.z);

        float camHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float camLeftEdge = mainCamera.transform.position.x - camHalfWidth;
        float camRightEdge = mainCamera.transform.position.x + camHalfWidth;

        float spriteRightEdge = transform.position.x + overallSize / 2;
        float spriteLeftEdge = transform.position.x - overallSize / 2;

        if (spriteRightEdge < camLeftEdge)
        {
            startpos += overallSize; 
        }
       
        else if (spriteLeftEdge > camRightEdge)
        {
            startpos -= overallSize;
        }
    }
}
