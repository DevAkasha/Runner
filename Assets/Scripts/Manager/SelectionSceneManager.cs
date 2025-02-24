using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectionSceneManager : MonoBehaviour
{
    public GameObject AlphaInfo;

    public GameObject CharactorInfo;
    public GameObject VictorInfo;
    public GameObject NathanInfo;
    public GameObject ElenaInfo;
    public GameObject OBJCloseCharactorBtn;

    void Start()
    {
        
    }


    //캐릭터 버튼 클릭
    public void VictorOn() 
    {
        CheckCharactor("Victor");
    }

    public void NathanOn()
    {
        CheckCharactor("Nathan");
    }

    public void ElenaOn()
    {
        CheckCharactor("Elena");
    }
    public void CloseCharactorBtnOn()//캐릭터 설명 닫기
    {
        CloseCharactorInfo();
    }

    //...버튼 켜고 끄기
    public void AlphaBtnOn() 
    {
        AlphaInfo.SetActive(true);
    }

    public void CloseBtnOn() 
    {
        AlphaInfo.SetActive(false);
    }

    public void LevelSetBtn()
    {
        //레벨 설정
    }
    public void StartBtn() 
    {
        //씬 이동
    }

    //참조 메서드
    public void CheckCharactor(string checkCharactor)
    {
        //전부 닫기
        CloseCharactorInfo();
        //캐릭터 인포 배경 켜기
        CharactorInfo.SetActive(true);
        OBJCloseCharactorBtn.SetActive(true);
        //맞는 캐릭터 정보 켜기
        switch (checkCharactor)
        {
            case "Victor":
                VictorInfo.SetActive(true);
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
                break;
            default:
                Debug.Log("캐릭터 선택 오류");
                break;
        }
    }

    public void CloseCharactorInfo()
    {
        VictorInfo.SetActive(false);
        NathanInfo.SetActive(false);
        ElenaInfo.SetActive(false);
        CharactorInfo.SetActive(false);
        OBJCloseCharactorBtn.SetActive(false);
    }
}


