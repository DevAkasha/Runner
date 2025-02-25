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
        //Ȥ�� �� ���� ������Ʈ �����
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);

        //���̱�
        HPBar.SetActive(true);
        StopBtn.SetActive(true);
        ScoreBoard.SetActive(true);

        //HP�� �̹��� ������Ʈ ��������
        HPBarI = GetComponentInChildren<HPBarImage>();
        HPBarImage = HPBarI.gameObject.GetComponent<Image>();

        //���ھ�� �ؽ�Ʈ ��������
        ScoreBoardTxt = GetComponentInChildren<TextMeshProUGUI>();

        //�÷��̾�� ��ũ��Ʈ ���� ��������
        stat = FindObjectOfType<PlayerStat>();
    }

    void Update()
    {
        //HP�� ������Ʈ
        if(HPBarI != null) 
        {
            Debug.Log("ü��Ȯ����");
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
        return stat.HP / stat.MaxHP;

    }
}
