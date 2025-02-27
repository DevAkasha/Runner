using TMPro;
using UnityEngine;

public class SceneEndObjectController : MonoBehaviour
{
    public GameObject StageEndBoard;
    public GameObject NextStageBtn;
    public GameObject ChooseStageBtn;
    
    public GameObject GameUI;

    public TextMeshProUGUI ClearBestScorenumTxt;
    public TextMeshProUGUI ClearNowScorenumTxt;

    //�⺻ ����
    private void Awake()
    {
        StageEndBoard.SetActive(false);
    }
    //�浹���� �� �Ͻ�����&�����ѱ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ְ� ���� �����ϱ�
        GameManager.Instance.UpdateBestScore();
        ClearBestScorenumTxt.text = GameManager.Instance.BestScore.ToString();
        //���� ���� �ҷ�����
        ClearNowScorenumTxt.text = GameManager.Instance.Score.ToString();
        //�Ͻ�����
        Time.timeScale = 0f;
        //�ΰ���UI���� EndBoard ����
        GameUI.SetActive(false);
        StageEndBoard.SetActive(true);
    }
    //���� �������� ��ư ������ �� ���� ������ �̵�
    public void NextStageBtnOn() 
    {
        Time.timeScale = 1f;
        PassScene();
    }
    //ĳ���� ���� ȭ������ �̵�
    public void ChooseStageBtnOn() 
    {
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(0);
    }
    //���� �ϳ� ���̰� �� �ҷ�����
    public void PassScene() 
    {
        SceneChangeManager.Instance.startLevel += 1;
        SceneChangeManager.Instance.SceneChanger(SceneChangeManager.Instance.startLevel);
    }
}
