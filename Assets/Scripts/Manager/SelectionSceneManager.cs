using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static SelectionSceneManager;

public class SelectionSceneManager : MonoBehaviour
{
    public GameObject AlphaInfo;

    public GameObject CharactorInfo;
    public GameObject VictorInfo;
    public GameObject NathanInfo;
    public GameObject ElenaInfo;
    public GameObject VictorMarker;
    public GameObject NathanMarker;
    public GameObject ElenaMarker;
    public GameObject OBJCloseCharactorBtn;

    public GameObject HardDifficultyCheck;
    public GameObject NormalDifficultyCheck;
    public GameObject EasyDifficultyCheck;

    public GameObject Victor;
    public GameObject Nathan;
    public GameObject Elena;
    public GameObject AlphaBtn;
    public GameObject HardBtn;
    public GameObject NormalBtn;
    public GameObject EasyBtn;
    public GameObject StartBtn;



    public enum Difficulty
    {
        Hard = 3,
        Normal = 2,
        Easy = 1
    } 

    void Start()
    {
        //있으면 안되는 것들 지우기
        CloseCharactorInfo();
        CloseCheckDifficulty();
        //있어야 하는 것들 띄우기
        Victor.SetActive(true);
        Nathan.SetActive(true);
        Elena.SetActive(true);
        AlphaBtn.SetActive(true);
        HardBtn.SetActive(true);
        NormalBtn.SetActive(true);
        EasyBtn.SetActive(true);
        StartBtn.SetActive(true);
        //해상도 고정 (전체화면, 창모드는 false)
        Screen.SetResolution(1920, 1080, true);
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

    //난이도 버튼
    public void HardBtnOn()
    {
        CheckDifficulty("Hard");
    }
    public void NormalBtnOn()
    {
        CheckDifficulty("Normal");
    }
    public void EasyBtnOn()
    {
        CheckDifficulty("Easy");
    }

    //스타트 버튼
    public void StartBtnOn() 
    {
        CheckDifficulty("None");
    }

    //참조 메서드
    //캐릭터 선택 관련
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
                VictorMarker.SetActive(true);
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
                ElenaMarker.SetActive(true);
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
        VictorMarker.SetActive(false);
        NathanMarker.SetActive(false);
        ElenaMarker.SetActive(false);
        CharactorInfo.SetActive(false);
        OBJCloseCharactorBtn.SetActive(false);
    }

    //난이도 체크 관련
    public void CheckDifficulty(string difficulty)
    {
        //전부 닫기
        CloseCheckDifficulty();
        //맞는 캐릭터 정보 켜기
        switch (difficulty)
        {
            case "Hard":
                HardDifficultyCheck.SetActive(true);
                //씬 이동
                Debug.Log("하드난이도");
                break;
            case "Normal":
                NormalDifficultyCheck.SetActive(true);
                //씬 이동
                Debug.Log("노말난이도");
                break;
            case "Easy":
                EasyDifficultyCheck.SetActive(true);
                //씬 이동
                Debug.Log("이지난이도");
                break;
            case "None":
                //씬 이동
                Debug.Log("기본이지난이도");
                break;
            default:
                Debug.Log("난이도 버튼 선택 오류");
                break;
        }
    }
    public void CloseCheckDifficulty()
    {
        HardDifficultyCheck.SetActive(false);
        NormalDifficultyCheck.SetActive(false);
        EasyDifficultyCheck.SetActive(false);
    }
}


