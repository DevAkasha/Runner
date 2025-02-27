using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HardBackGround : MonoBehaviour
{

    [SerializeField] Transform[] bgTrs;
    [SerializeField] Animator[] windows;
    [SerializeField] Animator[] candles;

    private float bgSizeX;

    private Transform currentBgTr;

    private Vector3 lastBgPos;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        bgTrs = new Transform[2];
        bgTrs[0] = transform.GetChild(0);
        bgTrs[1] = transform.GetChild(1);

        Sprite sprite = bgTrs[index].GetComponent<SpriteRenderer>().sprite;
        Texture texture = sprite.texture;

        bgSizeX = texture.width / sprite.pixelsPerUnit;

        lastBgPos = bgTrs[1].position;

        currentBgTr = bgTrs[index];

        StartCoroutine(WindowAnimCo());
        StartCoroutine(CandleAnimCo());
    }

    private IEnumerator WindowAnimCo()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].Play("Window_Idle");
            yield return new WaitForSeconds(Random.Range(0f, 1.5f));
        }
    }
    private IEnumerator CandleAnimCo()
    {
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].Play("Candle_Idle");
            yield return new WaitForSeconds(Random.Range(0f, 1.5f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((Camera.main.transform.position.x - currentBgTr.position.x) >= bgSizeX)
        {
            currentBgTr.position = new Vector3(lastBgPos.x + bgSizeX, currentBgTr.position.y);
            lastBgPos = currentBgTr.position;
            currentBgTr = bgTrs[++index % bgTrs.Length];
        }
    }
}
