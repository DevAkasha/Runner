using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 prallaxEffectMultiplier;

    private Transform mainCameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }


    void LateUpdate()
    {
        Vector3 deltamovement = mainCameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltamovement.x * prallaxEffectMultiplier.x, deltamovement.y * prallaxEffectMultiplier.y);

        if (Mathf.Abs(mainCameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (mainCameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(mainCameraTransform.position.x + offsetPositionX, transform.position.y);
            lastCameraPosition = mainCameraTransform.position;
        }
    }
}
