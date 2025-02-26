using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelBoard : MonoBehaviour
{
    public GameObject HardDifficultyCheck;
    public GameObject NormalDifficultyCheck;
    public GameObject EasyDifficultyCheck;

    public GameObject HardBtn;
    public GameObject NormalBtn;
    public GameObject EasyBtn;

    void Awake()
    {
        CloseCheckDifficulty();
        HardBtn.SetActive(true);
        NormalBtn.SetActive(true);
        EasyBtn.SetActive(true);
    }

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

    public void CheckDifficulty(int levelInput)
    {
        //전부 닫기
        CloseCheckDifficulty();
        //맞는 캐릭터 정보 켜기
        switch (levelInput)
        {
            case 3:
                HardDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                Debug.Log("하드 난이도");
                //씬 이동
                break;
            case 2:
                NormalDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                Debug.Log("노멀 난이도");
                //씬 이동
                break;
            case 1:
                EasyDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                Debug.Log("이지 난이도");
                //씬 이동
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
