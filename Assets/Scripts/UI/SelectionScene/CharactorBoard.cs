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

        switch (character)
        {
            case Character.Victor:
                animator.SetTrigger("IsVictor");
                VictorInfo.SetActive(true);
                VictorMarker.SetActive(true);
                GameManager.Instance.characterIndex = (int)Character.Victor;
                break;


            case Character.Nathan:
animator.SetTrigger("IsNathan");
                NathanInfo.SetActive(true);
                NathanMarker.SetActive(true);
                GameManager.Instance.characterIndex = (int)Character.Nathan;
                break;

            case Character.Elena:
                animator.SetTrigger("IsElena");
                ElenaInfo.SetActive(true);
                ElenaMarker.SetActive(true);
                GameManager.Instance.characterIndex = (int)Character.Elena;
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
