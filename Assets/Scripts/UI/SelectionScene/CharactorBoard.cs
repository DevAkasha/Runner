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

    //캐릭터 버튼 누를 때
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

    //참조
    //핵심기능
    public void CheckCharactor(string checkCharactor)
    {
        //전부 닫기
        CloseCharactorInfo();
        //캐릭터 인포 배경 켜기
        CharactorInfo.SetActive(true);
        OBJCloseCharactorBtn.SetActive(true);
        //맞는 캐릭터 정보 켜기
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
                Debug.Log("캐릭터 선택 오류");
                break;
        }
    }
    //전부 닫기
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
