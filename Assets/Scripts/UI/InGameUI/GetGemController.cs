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

    //보석 획득, 피버타임 여부 체크
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

    //보석 끄기(피버타임 실행시)
    public void OffGem()
    {
        //켜진 보석 없애기
        Diamond.SetActive(false);
        Emerald.SetActive(false);
        Ruby.SetActive(false);

        //빈칸 보석 켜기
        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);
    }
}
