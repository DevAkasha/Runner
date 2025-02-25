using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;

    public GameObject ScoreBoard;
    private TextMeshProUGUI ScoreBoardTxt;

    public GameObject HPBar;
    public float HPRatio;

    private void Awake()
    {
        //Ȥ�� �� ���� ������Ʈ �����
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);

        //HP�� �̹��� ������Ʈ ��������
        HPBar = GetComponent<Image>(FillAmount);
    }
    void Start()
    {
        //���̱�
        StopBoard.SetActive(true);
        HPBar.SetActive(true);
        ScoreBoard.SetActive(true);

        //���ھ�� �ؽ�Ʈ ��������
        ScoreBoardTxt = GetComponent<TextMeshProUGUI>();

        //�÷��̾�� ��ũ��Ʈ ���� ��������
        FindObjectOfType<PlayerStat>();
    }

    void Update()
    {
        //HP�� ������Ʈ
        if(/*����Ƽ ���� FillAmount*/ != null) 
        {
            /*����Ƽ ���� FillAmount*/ == HPRatio;
        }

        //���ھ�� ���� ������Ʈ
        if (ScoreBoardTxt != null) 
        {
            ScoreBoardTxt.text = GameManager.Instance.Score.ToString();
        }
    }

    //�Ͻ����� ��ư ������ �� ���� ������
    public void StopButtonOn() 
    {
        StopBoard.SetActive(true);
    }

    //�Ͻ����� ���� ����
    public void StopBoardCloseBtn() 
    {
        StopBoard.SetActive(false);
    }

    //ü�¹� ���� ����
    public void HPRatioSet(float now, float max) 
    {
        now = PlayerStat.HP;
        max = PlayerStat.MaxHP;
        
        HPRatio = now/max;
    }
}
