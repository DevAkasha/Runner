using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImage : PlayerAction
{
    public float ghostDelay;
    private float ghostDelaySeconds;

    public GameObject ghost;

    void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }


    void Update()
    {
        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }

            else
            {
                GameObject currentGhost = Instantiate(ghost, transform.position + new Vector3(-0.3f, 0.45f, 0f), transform.rotation);
                Sprite currentSprite = GetComponentInChildren<SpriteRenderer>().sprite;
                currentGhost.GetComponentInChildren<SpriteRenderer>().sprite = currentSprite;
                ghostDelaySeconds = ghostDelay;
                Destroy(currentGhost, 0.2f);
            }
        }
    }
}
