using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static SelectionSceneManager;

public class SelectionSceneManager : MonoBehaviour
{
    public GameObject AlphaInfo;

    public GameObject CharactorInfo;
    public GameObject VictorInfo;
    public GameObject NathanInfo;
    public GameObject ElenaInfo;
    public GameObject VictorMarker;
    public GameObject NathanMarker;
    public GameObject ElenaMarker;
    public GameObject OBJCloseCharactorBtn;

    public GameObject HardDifficultyCheck;
    public GameObject NormalDifficultyCheck;
    public GameObject EasyDifficultyCheck;

    public GameObject Victor;
    public GameObject Nathan;
    public GameObject Elena;
    public GameObject AlphaBtn;
    public GameObject HardBtn;
    public GameObject NormalBtn;
    public GameObject EasyBtn;
    public GameObject StartBtn;

    public int difficulty;
    [SerializeField] private SceneChangeManager sceneChanger;

    void Start()
    {
        //������ �ȵǴ� �͵� �����
        CloseCharactorInfo();
        CloseCheckDifficulty();
        //�־�� �ϴ� �͵� ����
        Victor.SetActive(true);
        Nathan.SetActive(true);
        Elena.SetActive(true);
        AlphaBtn.SetActive(true);
        HardBtn.SetActive(true);
        NormalBtn.SetActive(true);
        EasyBtn.SetActive(true);
        StartBtn.SetActive(true);
        //�ػ� ���� (��üȭ��, â���� false)
        Screen.SetResolution(1920, 1080, true);
        //SceneChangeManager�ҷ�����
        sceneChanger = new SceneChangeManager();

    }

    //ĳ���� ��ư Ŭ��
    public void VictorOn() 
    {
        CheckCharactor("Victor");
    }

    public void NathanOn()
    {
        CheckCharactor("Nathan");
    }

    public void ElenaOn()
    {
        CheckCharactor("Elena");
    }
    public void CloseCharactorBtnOn()//ĳ���� ���� �ݱ�
    {
        CloseCharactorInfo();
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

    //���̵� ��ư
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

    //��ŸƮ ��ư
    public void StartBtnOn() 
    {
        CheckDifficulty(0);
    }

    //���� �޼���
    //ĳ���� ���� ����
    public void CheckCharactor(string checkCharactor)
    {
        //���� �ݱ�
        CloseCharactorInfo();
        //ĳ���� ���� ��� �ѱ�
        CharactorInfo.SetActive(true);
        OBJCloseCharactorBtn.SetActive(true);
        //�´� ĳ���� ���� �ѱ�
        switch (checkCharactor)
        {
            case "Victor":
                VictorInfo.SetActive(true);
                VictorMarker.SetActive(true);
                sceneChanger.charactor = 1;
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                sceneChanger.charactor = 2;
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
                ElenaMarker.SetActive(true);
                sceneChanger.charactor = 3;
                break;
            default:
                Debug.Log("ĳ���� ���� ����");
                break;
        }
    }
    public void CloseCharactorInfo()
    {
        VictorInfo.SetActive(false);
        NathanInfo.SetActive(false);
        ElenaInfo.SetActive(false);
        VictorMarker.SetActive(false);
        NathanMarker.SetActive(false);
        ElenaMarker.SetActive(false);
        CharactorInfo.SetActive(false);
        OBJCloseCharactorBtn.SetActive(false);
    }

    //���̵� üũ ����
    public void CheckDifficulty(int difficultInput)
    {
        //���� �ݱ�
        CloseCheckDifficulty();
        //�´� ĳ���� ���� �ѱ�
        switch (difficultInput)
        {
            case 3:
                HardDifficultyCheck.SetActive(true);
                sceneChanger.level = difficultInput;
                Debug.Log("�ϵ� ���̵�");
                //�� �̵�
                break;
            case 2:
                NormalDifficultyCheck.SetActive(true);
                sceneChanger.level = difficultInput;
                Debug.Log("��� ���̵�");
                //�� �̵�
                break;
            case 1:
                EasyDifficultyCheck.SetActive(true);
                sceneChanger.level = difficultInput;
                Debug.Log("���� ���̵�");
                //�� �̵�
                break;
            case 0:
                EasyDifficultyCheck.SetActive(true);
                sceneChanger.level = 1;
                //�� �̵�
                Debug.Log("���� ���̵� ����");
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


