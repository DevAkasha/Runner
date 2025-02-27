using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GetGemController : MonoBehaviour
{
    public GameObject Gem;
    public GameObject[] NoneJewels; // �����ִ� ���� ������Ʈ
    public GameObject[] Jewels;     // �����ִ� ���� ������Ʈ

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

    //���� ȹ��, �ǹ�Ÿ�� ���� üũ
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
