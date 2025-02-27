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

    private Animator animator;
    
    void Awake()
    {
        CloseCharactorInfo();
        Victor.SetActive(true);
        Nathan.SetActive(true);
        Elena.SetActive(true);
        animator = GetComponent<Animator>();
    }

    //ĳ���� ��ư ���� ��
    public void VictorOn()
    {
        SoundManager.Instance.PlaySFX(2);
        CheckCharactor(Character.Victor);
    }

    public void NathanOn()
    {
        SoundManager.Instance.PlaySFX(2);
        CheckCharactor(Character.Nathan);
    }

    public void ElenaOn()
    {
        SoundManager.Instance.PlaySFX(2);
        CheckCharactor(Character.Elena);
    }

    public void CloseCharactorBtnOn()
    {
        SoundManager.Instance.PlaySFX(7);
        CloseCharactorInfo();
    }

    //����
    //�ٽɱ��
    public void CheckCharactor(Character character)
    {
        //���� �ݱ�
        CloseCharactorInfo();
        //ĳ���� ���� ��� �ѱ�
        CharactorInfo.SetActive(true);
        OBJCloseCharactorBtn.SetActive(true);
        //�´� ĳ���� ���� �ѱ�
        switch ((int)character)
        {
            case 1:
                animator.SetTrigger("IsVictor");
                VictorInfo.SetActive(true);
                VictorMarker.SetActive(true);
                SceneChangeManager.Instance.charactor = 1;
                break;
            case 2:
                animator.SetTrigger("IsNathan");
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                SceneChangeManager.Instance.charactor = 2;
                break;
            case 3:
                animator.SetTrigger("IsElena");
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
