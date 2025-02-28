using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : Manager<GameUIManager>
{
    protected override bool isPersistent => false;

    //난이도 세팅
    public int levelSet;

    public GameObject ScoreBoard;
    public GameObject StopBoard;
    private TextMeshProUGUI ScoreBoardTxt;
    
    protected override void Awake()
    {
        base.Awake();

        ScoreBoard.SetActive(false);
        ScoreBoard.SetActive(true);

        //스코어보드 텍스트 가져오기
        ScoreBoardTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        //스코어보드 점수 업데이트
        if (ScoreBoardTxt != null) 
        {
            ScoreBoardTxt.text = GameManager.Instance.Score.ToString();
        }
    }

    public void OpenGameOverBoard()
    {
        StopBoard.SetActive(true);
    }
}
