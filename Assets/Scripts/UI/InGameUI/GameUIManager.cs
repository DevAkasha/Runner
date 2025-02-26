using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    //���̵� ����
    public int levelSet;

    public GameObject ScoreBoard;
    private TextMeshProUGUI ScoreBoardTxt;

    private PlayerStat stat;
    void Start()
    {
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
}
