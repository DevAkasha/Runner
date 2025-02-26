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
        //Ȥ�� �� ���� ������Ʈ �����
        StopBoard.SetActive(false);
        HPBar.SetActive(false);
        ScoreBoard.SetActive(false);
        Jewel.SetActive(false);

        //���̱�
        HPBar.SetActive(true);
        StopBtn.SetActive(true);
        ScoreBoard.SetActive(true);
        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);

        //HP�� �̹��� ������Ʈ ��������
        HPBarI = GetComponentInChildren<HPBarImage>();
        HPBarImage = HPBarI.gameObject.GetComponent<Image>();

        //���ھ�� �ؽ�Ʈ ��������
        ScoreBoardTxt = GetComponentInChildren<TextMeshProUGUI>();

        //�÷��̾�� ��ũ��Ʈ ���� ��������
        stat = FindObjectOfType<PlayerStat>();
    }

    void Update()
    {
        //HP�� ������Ʈ
        if(HPBarI != null) 
        {
            Debug.Log("ü��Ȯ����");
            HPBarImage.fillAmount = HPRatioSet();
        }

        //���ھ�� ���� ������Ʈ
        if (ScoreBoardTxt != null) 
        {
            ScoreBoardTxt.text = GameManager.Instance.Score.ToString();
        }
    }

    //�Ͻ����� ��ư ������ �� ���� ������
    public void StopButtonOn() 
    {
        StopBoard.SetActive(true);
    }

    //�Ͻ����� ���� ����
    public void StopBoardCloseBtn() 
    {
        StopBoard.SetActive(false);
    }

    //ü�¹� ���� ����
    public float HPRatioSet()
    {
        return stat.HP / stat.MaxHP;

    }

    //���� �ѱ�
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
                Debug.Log("���� ������ �ѱ� ����");
                break;
        }
    }

    //���� ����(�ǹ�Ÿ�� �����)
    public void OffJewel() 
    { 
        //���� ���� ���ֱ�
        Diamond.SetActive(false);
        Emerald.SetActive(false);
        Ruby.SetActive(false);

        //��ĭ ���� �ѱ�
        NoneDiamond.SetActive(true);
        NoneEmerald.SetActive(true);
        NoneRuby.SetActive(true);
    }
}
