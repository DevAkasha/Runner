using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;

    public GameObject ScoreBoard;
    private TextMeshProUGUI ScoreBoardTxt;

    public HPBarImage HPBarI;
    public GameObject HPBar;
    public float HPRatio;
    public Image HPBarImage;

    public GameObject Jewel;
    public GameObject NoneDiamond;
    public GameObject Diamond;
    public GameObject NoneEmerald;
    public GameObject Emerald;
    public GameObject NoneRuby;
    public GameObject Ruby;


    private PlayerStat stat;
    void Start()
    {
        //혹시 모를 이전 오브젝트 지우기
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);
        Jewel.SetActive(false);

        //보이기
        HPBar.SetActive(true);
        StopBtn.SetActive(true);
        ScoreBoard.SetActive(true);
        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);

        //HP바 이미지 컴포넌트 가져오기
        HPBarI = GetComponentInChildren<HPBarImage>();
        HPBarImage = HPBarI.gameObject.GetComponent<Image>();

        //스코어보드 텍스트 가져오기
        ScoreBoardTxt = GetComponentInChildren<TextMeshProUGUI>();

        //플레이어스탯 스크립트 정보 가져오기
        stat = FindObjectOfType<PlayerStat>();
    }

    void Update()
    {
        //HP바 업데이트
        if(HPBarI != null) 
        {
            Debug.Log("체력확인중");
            HPBarImage.fillAmount = HPRatioSet();
        }

        //스코어보드 점수 업데이트
        if (ScoreBoardTxt != null) 
        {
            ScoreBoardTxt.text = GameManager.Instance.Score.ToString();
        }
    }

    //일시정지 버튼 눌렀을 때 보드 켜지기
    public void StopButtonOn() 
    {
        StopBoard.SetActive(true);
    }

    //일시정지 보드 끄기
    public void StopBoardCloseBtn() 
    {
        StopBoard.SetActive(false);
    }

    //체력바 비율 설정
    public float HPRatioSet()
    {
        return stat.HP / stat.MaxHP;

    }

    //보석 켜기
    public void OnJewel(string jewelType) 
    {
        switch (jewelType) 
        {
            case "Diamond":
                NoneDiamond.SetActive(false);
                Diamond.SetActive(true);
                break;
            case "Emerald":
                NoneEmerald.SetActive(false);
                Emerald.SetActive(true);
                break;
            case "Ruby":
                NoneRuby.SetActive(false);
                Ruby.SetActive(true);
                break;
            default:
                Debug.Log("보석 아이콘 켜기 오류");
                break;
        }
    }

    //보석 끄기(피버타임 실행시)
    public void OffJewel() 
    { 
        //켜진 보석 없애기
        Diamond.SetActive(false);
        Emerald.SetActive(false);
        Ruby.SetActive(false);

        //빈칸 보석 켜기
        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);
    }
}
