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

    public int difficulty;
    [SerializeField] private SceneChangeManager sceneChanger;

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
        //SceneChangeManager불러오기
        sceneChanger = new SceneChangeManager();

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
        CheckDifficulty(3);
    }
    public void NormalBtnOn()
    {
        CheckDifficulty(2);
    }
    public void EasyBtnOn()
    {
        CheckDifficulty(1);
    }

    //스타트 버튼
    public void StartBtnOn() 
    {
        CheckDifficulty(0);
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
                sceneChanger.charactor = 1;
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                sceneChanger.charactor = 2;
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
                ElenaMarker.SetActive(true);
                sceneChanger.charactor = 3;
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
    public void CheckDifficulty(int difficultInput)
    {
        //전부 닫기
        CloseCheckDifficulty();
        //맞는 캐릭터 정보 켜기
        switch (difficultInput)
        {
            case 3:
                HardDifficultyCheck.SetActive(true);
                sceneChanger.level = difficultInput;
                Debug.Log("하드 난이도");
                //씬 이동
                break;
            case 2:
                NormalDifficultyCheck.SetActive(true);
                sceneChanger.level = difficultInput;
                Debug.Log("노멀 난이도");
                //씬 이동
                break;
            case 1:
                EasyDifficultyCheck.SetActive(true);
                sceneChanger.level = difficultInput;
                Debug.Log("이지 난이도");
                //씬 이동
                break;
            case 0:
                EasyDifficultyCheck.SetActive(true);
                sceneChanger.level = 1;
                //씬 이동
                Debug.Log("이지 난이도 시작");
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


