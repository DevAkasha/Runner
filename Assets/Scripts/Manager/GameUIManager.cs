using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;

    public GameObject ScoreBoard;
    private TextMeshProUGUI ScoreBoardTxt;

    public Image HPBarImage;
    public GameObject HPBar;
    public PlayerStat PlayerInfo;
    public float HPRatio;

    private void Awake()
    {
        //혹시 모를 이전 오브젝트 지우기
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);

        //HP바 이미지 컴포넌트 가져오기
        HPBarImage = GetComponent<Image>();
    }
    void Start()
    {
        //보이기
        StopBoard.SetActive(true);
        HPBar.SetActive(true);
        ScoreBoard.SetActive(true);

        //스코어보드 텍스트 가져오기
        ScoreBoardTxt = GetComponent<TextMeshProUGUI>();

        //플레이어스탯 스크립트 정보 가져오기
        FindObjectOfType<PlayerStat>();
    }

    void Update()
    {
        //HP바 업데이트
        if(HPBarImage.fillAmount != null) 
        {
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
        return PlayerInfo.HP / PlayerInfo.MaxHP;
    }
}
