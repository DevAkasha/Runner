using UnityEngine;
using TMPro;

public class SelectionSceneManager : MonoBehaviour
{
    //Ŭ���� ��ȭ�ϱ�
    //��������, ��ŸƮ��ư ����
    public GameObject AlphaInfo;
    public GameObject AlphaBtn;
    public GameObject StartBtn;
    public GameObject AlphaInfoExitBtn;

    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI LastScore;

    void Start()
    {
        //�����
        StartBtn.SetActive(true);
        AlphaBtn.SetActive(true);

        //�ػ� ���� (��üȭ��, â���� false)
        Screen.SetResolution(1920, 1080, true);

        //���� ����
        BestScore.text = GameManager.Instance.BestScore.ToString();
        LastScore.text = GameManager.Instance.Score.ToString();
    }

    //...��ư �Ѱ� ����
    public void AlphaBtnOn()
    {
        AlphaInfo.SetActive(true);
    }

    public void AlphaInfoCloseBtnOn()
    {
        AlphaInfo.SetActive(false);
    }

    public void AlphaInfoExitBtnOn() 
    {
        GameManager.Instance.GameOver();
        Debug.Log("���� ����");
    }

    //��ŸƮ ��ư
    public void StartBtnOn()
    {
        //������ ���̵� ��ư�� ������ ��� �ش� ���̵��� �̵�
        if (SceneChangeManager.Instance.startLevel > 0 && SceneChangeManager.Instance.startLevel < 4)
        {
            SceneChangeManager.Instance.FirstSceneChange(SceneChangeManager.Instance.startLevel);
        }
        //�ٷ� ������ ��� EASY ���̵��� �̵�
        else 
        {
            SceneChangeManager.Instance.SceneChanger(1); 
        }
    }
}



