using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorBoard : MonoBehaviour
{
    public GameObject CharactorInfo;
    public GameObject VictorInfo;
    public GameObject NathanInfo;
    public GameObject ElenaInfo;
    public GameObject VictorMarker;
    public GameObject NathanMarker;
    public GameObject ElenaMarker;
    public GameObject OBJCloseCharactorBtn;

    public GameObject Victor;
    public GameObject Nathan;
    public GameObject Elena;

    void Awake()
    {
        CloseCharactorInfo();
        Victor.SetActive(true);
        Nathan.SetActive(true);
        Elena.SetActive(true);

    }

    //ĳ���� ��ư ���� ��
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

    public void CloseCharactorBtnOn()
    {
        CloseCharactorInfo();
    }

    //����
    //�ٽɱ��
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
                SceneChangeManager.Instance.charactor = 1;
                break;
            case "Nathan":
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                SceneChangeManager.Instance.charactor = 2;
                break;
            case "Elena":
                ElenaInfo.SetActive(true);
                ElenaMarker.SetActive(true);
                SceneChangeManager.Instance.charactor = 3;
                break;
            default:
                Debug.Log("ĳ���� ���� ����");
                break;
        }
    }
    //���� �ݱ�
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
}
