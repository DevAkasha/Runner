using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtnController : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;
    private GameUIManager level;

    //기본 세팅
    void Awake()
    {
        StopBoard.SetActive(false);
        StopBtn.SetActive(true);
        level = FindObjectOfType<GameUIManager>();
    }
    //버튼 누르면 일시정지 보드 켜기
    public void StopBtnOn()
    {
        Time.timeScale = 0f;
        StopBoard.SetActive(true);
    }

    //일시정지 보드 끄기
    public void StopBoardCloseBtn()
    {
        Time.timeScale = 1f;
        StopBoard.SetActive(false);
    }
    
    //해당 씬 재시작
    public void RetryBtnOn() 
    {
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(level.levelSet);
    }

    //캐릭터 선택창으로 이동
    public void GiveUpBtn()
    {
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(0);
    }
}
