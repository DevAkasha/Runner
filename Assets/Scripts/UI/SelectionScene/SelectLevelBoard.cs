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
    public GameObject TutorialBtn;

    //기본 설정
    void Awake()
    {
        CloseCheckDifficulty();
        TutorialBtn.SetActive(true);
        HardBtn.SetActive(true);
        NormalBtn.SetActive(true);
        EasyBtn.SetActive(true);
    }

    //버튼 클릭 시 동작
    public void HardBtnOn()
    {
        CheckDifficulty(3);
        SoundManager.Instance.PlaySFX(2);
    }
    public void NormalBtnOn()
    {
        CheckDifficulty(2);
        SoundManager.Instance.PlaySFX(2);
    }
    
    public void EasyBtnOn()
    {
        CheckDifficulty(1);
        SoundManager.Instance.PlaySFX(2);
    }

    public void TutorialBtnOn()
    {
        SceneChangeManager.Instance.SceneChanger(-1);
        SoundManager.Instance.PlaySFX(2);
    }

    //참조
    //난이도 설정
    public void CheckDifficulty(int levelInput)
    {
        //전부 닫기
        CloseCheckDifficulty();
        switch (levelInput)
        {
            case 3:
                HardDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                break;
            case 2:
                NormalDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                break;
            case 1:
                EasyDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                break;
            default:
                Debug.Log("난이도 버튼 선택 오류");
                break;
        }
    }
    //겹칠 가능성 있는 오브젝트 삭제
    public void CloseCheckDifficulty()
    {
        HardDifficultyCheck.SetActive(false);
        NormalDifficultyCheck.SetActive(false);
        EasyDifficultyCheck.SetActive(false);
    }

}
