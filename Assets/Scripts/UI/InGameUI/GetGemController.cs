using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GetGemController : MonoBehaviour
{
    public GameObject Gem;
    public GameObject NoneDiamond;
    public GameObject Diamond;
    public GameObject NoneEmerald;
    public GameObject Emerald;
    public GameObject NoneRuby;
    public GameObject Ruby;

    public void Awake()
    {
        Gem.SetActive(false);
        Gem.SetActive(true);

        Diamond.SetActive(false);
        Emerald.SetActive(false);
        Ruby.SetActive(false);

        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);
    }

    //���� ȹ��, �ǹ�Ÿ�� ���� üũ
    private void Update()
    {
        OnGem(GameManager.Instance.hasGemStone);

        if(Array.TrueForAll(GameManager.Instance.hasGemStone, x=>x)) 
        {
            OffGem();
        }
    }

    public void OnGem(bool[] gemList)
    {
        if (gemList[0]) 
        {
            NoneDiamond.SetActive(false);
            Diamond.SetActive(true);
        }
        if (gemList[1]) 
        {
            NoneEmerald.SetActive(false);
            Emerald.SetActive(true);
        }
        if (gemList[2]) 
        {
            NoneRuby.SetActive(false);
            Ruby.SetActive(true);
        }
    }

    //���� ����(�ǹ�Ÿ�� �����)
    public void OffGem()
    {
        //���� ���� ���ֱ�
        Diamond.SetActive(false);
        Emerald.SetActive(false);
        Ruby.SetActive(false);

        //��ĭ ���� �ѱ�
        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);
    }
}
