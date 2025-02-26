using UnityEngine;

public class SelectionSceneManager : MonoBehaviour
{
    //Ŭ���� ��ȭ�ϱ�
    //��������, ��ŸƮ��ư ����
    public GameObject AlphaInfo;
    public GameObject AlphaBtn;
    public GameObject StartBtn;

    void Start()
    {
        //�����
        StartBtn.SetActive(true);
        AlphaBtn.SetActive(true);

        //�ػ� ���� (��üȭ��, â���� false)
        Screen.SetResolution(1920, 1080, true);
    }

    //...��ư �Ѱ� ����
    public void AlphaBtnOn()
    {
        AlphaInfo.SetActive(true);
    }

    public void CloseBtnOn()
    {
        AlphaInfo.SetActive(false);
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
        else { SceneChangeManager.Instance.FirstSceneChange(0); }
    }
}



