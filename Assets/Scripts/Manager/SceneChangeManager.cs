using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : Manager<SceneChangeManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    //SelectScene���� �Է¹��� ����
    //1=Easy 2=Normal 3=Hard
    public int startLevel;

    //1=Victor 2=Nathon 3=Elena
    public int charactor;

    //Selection Scene ��ŸƮ��ư ���
    //���� ������ ���� �Է¹��� �� ������ ��� �ش� ���� �̵�
    public void FirstSceneChange(int selectlevel) 
    {
        //�̸� �Է¹��� ������ ���� ������ ������ ��ġ�ϴ��� Ȯ��
        if (startLevel == selectlevel)
        {
            SceneChanger(selectlevel);
            return;
        }
        //�ٷ� ��ŸƮ ��ư ������ ��� EASY�� �̵�
        else if (selectlevel == 0) 
        {
            SceneChanger(1);
            return;
        }
        else 
        { 
            Debug.Log("ó�� �Է¹��� ������ �̵��ϰ��� �ϴ� ������ �ٸ��ϴ�.");
            return;
        }
        
    }

    //�Է¹��� ���� �̵�
    //1=Easy 2=Normal 3=Hard 0=Selection -1=Tutorial
    private void SceneChanger(int level) 
    {
        switch (level)
        {
            case 3:
                Debug.Log("���� �ϵ� ���̵��� �����ϴ�.");
                //�� �̵�
                break;
            case 2:
                Debug.Log("���� ��� ���̵��� �����ϴ�.");
                //�� �̵�
                break;
            case 1:
                SceneManager.LoadScene("Easy");
                break;
            case 0:
                SceneManager.LoadScene("SelectionScene");
                break;
            case -1:
                SceneManager.LoadScene("TutorialScene");
                break;
            default:
                Debug.Log("�� �̵� ����");
                break;
        }
    }

}
