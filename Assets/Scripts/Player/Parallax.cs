using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 prallaxEffectMultiplier;

    private Transform mainCamera;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    void Start()
    {
        mainCamera = Camera.main.transform;
        lastCameraPosition = mainCamera.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }


    void LateUpdate()
    {
        Vector3 deltamovement = mainCamera.position - lastCameraPosition;
        transform.position += new Vector3(deltamovement.x * prallaxEffectMultiplier.x, deltamovement.y * prallaxEffectMultiplier.y);

        lastCameraPosition = mainCamera.position;

        if (Mathf.Abs(mainCamera.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (mainCamera.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(mainCamera.position.x + offsetPositionX, transform.position.y);
        }
    }
}
