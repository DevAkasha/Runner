using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectionSceneManager : MonoBehaviour
{
    public GameObject AlphaInfo;

    public GameObject CharactorInfo;
    public GameObject VictorInfo;
    public GameObject NathanInfo;
    public GameObject ElenaInfo;
    public GameObject OBJCloseCharactorBtn;

    void Start()
    {
        
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

    public void LevelSetBtn()
    {
        //���� ����
    }
    public void StartBtn() 
    {
        //�� �̵�
    }

    //���� �޼���
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
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
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
        CharactorInfo.SetActive(false);
        OBJCloseCharactorBtn.SetActive(false);
    }
}


