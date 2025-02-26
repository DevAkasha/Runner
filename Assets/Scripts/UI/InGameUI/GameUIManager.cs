using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    //난이도 세팅
    public int levelSet;

    public GameObject ScoreBoard;
    private TextMeshProUGUI ScoreBoardTxt;

    private PlayerStat stat;
    void Start()
    {
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
}
