using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : Manager<GameUIManager>
{
    protected override bool isPersistent => false;

    //���̵� ����
    public int levelSet;

    public GameObject ScoreBoard;
    public GameObject StopBoard;
    private TextMeshProUGUI ScoreBoardTxt;
    
    protected override void Awake()
    {
        base.Awake();

        ScoreBoard.SetActive(false);
        ScoreBoard.SetActive(true);

        //���ھ�� �ؽ�Ʈ ��������
        ScoreBoardTxt = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        //���ھ�� ���� ������Ʈ
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
