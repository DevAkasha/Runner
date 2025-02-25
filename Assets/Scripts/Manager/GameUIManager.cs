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
        //Ȥ�� �� ���� ������Ʈ �����
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);

        //HP�� �̹��� ������Ʈ ��������
        HPBarImage = GetComponent<Image>();
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
        if(HPBarImage.fillAmount != null) 
        {
            HPBarImage.fillAmount = HPRatioSet();
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
    public float HPRatioSet() 
    {
        return PlayerInfo.HP / PlayerInfo.MaxHP;
    }
}
