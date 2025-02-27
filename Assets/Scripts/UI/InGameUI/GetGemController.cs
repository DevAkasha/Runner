using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GetGemController : MonoBehaviour
{
    public GameObject Gem;
    public GameObject[] NoneJewels; // 꺼져있는 보석 오브젝트
    public GameObject[] Jewels;     // 켜져있는 보석 오브젝트

    public void Awake()
    {
        for (int i = 0; i < NoneJewels.Length; i++)
        {
            NoneJewels[i].SetActive(true);
        }

        for (int i = 0; i < Jewels.Length; i++)
        {
            Jewels[i].SetActive(false);
        }
    }

    //보석 획득, 피버타임 여부 체크
    private void Update()
    {
        bool[] gemList = GameManager.Instance.hasGemStone;

        for (int i = 0; i < NoneJewels.Length; i++)
        {
            NoneJewels[i].SetActive(!gemList[i]);
        }

        for (int i = 0; i < Jewels.Length; i++)
        {
            Jewels[i].SetActive(gemList[i]);
        }
    }
}
