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



    public enum Difficulty
    {
        Hard = 3,
        Normal = 2,
        Easy = 1
    } 

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
        CheckDifficulty("Hard");
    }
    public void NormalBtnOn()
    {
        CheckDifficulty("Normal");
    }
    public void EasyBtnOn()
    {
        CheckDifficulty("Easy");
    }

    //��ŸƮ ��ư
    public void StartBtnOn() 
    {
        CheckDifficulty("None");
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
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
                ElenaMarker.SetActive(true);
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
    public void CheckDifficulty(string difficulty)
    {
        //���� �ݱ�
        CloseCheckDifficulty();
        //�´� ĳ���� ���� �ѱ�
        switch (difficulty)
        {
            case "Hard":
                HardDifficultyCheck.SetActive(true);
                //�� �̵�
                Debug.Log("�ϵ峭�̵�");
                break;
            case "Normal":
                NormalDifficultyCheck.SetActive(true);
                //�� �̵�
                Debug.Log("�븻���̵�");
                break;
            case "Easy":
                EasyDifficultyCheck.SetActive(true);
                //�� �̵�
                Debug.Log("�������̵�");
                break;
            case "None":
                //�� �̵�
                Debug.Log("�⺻�������̵�");
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


