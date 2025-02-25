using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Build;


public class GameUIManager : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;

    public GameObject ScoreBoard;
    private TextMeshProUGUI ScoreBoardTxt;

    public HPBarImage HPBarI;
    public GameObject HPBar;
    public float HPRatio;
    public Image HPBarImage;

    private PlayerStat stat;
    void Start()
    {
        //혹시 모를 이전 오브젝트 지우기
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);

        //보이기
        HPBar.SetActive(true);
        StopBtn.SetActive(true);
        ScoreBoard.SetActive(true);

        //HP바 이미지 컴포넌트 가져오기
        HPBarI = GetComponentInChildren<HPBarImage>();
        HPBarImage = HPBarI.gameObject.GetComponent<Image>();

        //스코어보드 텍스트 가져오기
        ScoreBoardTxt = GetComponentInChildren<TextMeshProUGUI>();

        //플레이어스탯 스크립트 정보 가져오기
        stat = FindObjectOfType<PlayerStat>();
    }

    void Update()
    {
        //HP바 업데이트
        if(HPBarI != null) 
        {
            Debug.Log("체력확인중");
            HPBarImage.fillAmount = HPRatioSet();
        }

        //스코어보드 점수 업데이트
        if (ScoreBoardTxt != null) 
        {
            ScoreBoardTxt.text = GameManager.Instance.Score.ToString();
        }
    }

    //일시정지 버튼 눌렀을 때 보드 켜지기
    public void StopButtonOn() 
    {
        StopBoard.SetActive(true);
    }

    //일시정지 보드 끄기
    public void StopBoardCloseBtn() 
    {
        StopBoard.SetActive(false);
    }

    //체력바 비율 설정
    public float HPRatioSet()
    {
        return stat.HP / stat.MaxHP;

    }
}
