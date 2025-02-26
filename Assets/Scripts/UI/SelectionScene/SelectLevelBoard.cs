using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelBoard : MonoBehaviour
{
    public GameObject HardDifficultyCheck;
    public GameObject NormalDifficultyCheck;
    public GameObject EasyDifficultyCheck;

    public GameObject HardBtn;
    public GameObject NormalBtn;
    public GameObject EasyBtn;

    void Awake()
    {
        CloseCheckDifficulty();
        HardBtn.SetActive(true);
        NormalBtn.SetActive(true);
        EasyBtn.SetActive(true);
    }

    public void HardBtnOn()
    {
        CheckDifficulty(3);
    }
    public void NormalBtnOn()
    {
        CheckDifficulty(2);
    }
    public void EasyBtnOn()
    {
        CheckDifficulty(1);
    }

    public void CheckDifficulty(int levelInput)
    {
        //���� �ݱ�
        CloseCheckDifficulty();
        //�´� ĳ���� ���� �ѱ�
        switch (levelInput)
        {
            case 3:
                HardDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                Debug.Log("�ϵ� ���̵�");
                //�� �̵�
                break;
            case 2:
                NormalDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                Debug.Log("��� ���̵�");
                //�� �̵�
                break;
            case 1:
                EasyDifficultyCheck.SetActive(true);
                SceneChangeManager.Instance.startLevel = levelInput;
                Debug.Log("���� ���̵�");
                //�� �̵�
                break;
            default:
                Debug.Log("���̵� ��ư ���� ����");
                break;
        }
    }
    public void CloseCheckDifficulty()
    {
        HardDifficultyCheck.SetActive(false);
        NormalDifficultyCheck.SetActive(false);
        EasyDifficultyCheck.SetActive(false);
    }

}
