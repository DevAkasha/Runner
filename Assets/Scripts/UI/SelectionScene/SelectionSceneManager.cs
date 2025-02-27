using UnityEngine;
using TMPro;

public class SelectionSceneManager : MonoBehaviour
{
    //클래스 분화하기
    //알파인포, 스타트버튼 유지
    public GameObject AlphaInfo;
    public GameObject AlphaBtn;
    public GameObject StartBtn;
    public GameObject AlphaInfoExitBtn;
    public GameObject SettingWindow;

    public TextMeshProUGUI BestScore;
    public TextMeshProUGUI LastScore;

    
    void Start()
    {
        //남기기
        StartBtn.SetActive(true);
        AlphaBtn.SetActive(true);

        //해상도 고정 (전체화면, 창모드는 false)
        Screen.SetResolution(1920, 1080, true);

        //점수 적용
        BestScore.text = GameManager.Instance.BestScore.ToString();
        LastScore.text = GameManager.Instance.Score.ToString();
    }

    //...버튼 켜고 끄기
    public void AlphaBtnOn()
    {
        AlphaInfo.SetActive(true);
        SoundManager.Instance.PlaySFX(2);
    }

    public void AlphaInfoCloseBtnOn()
    {
        AlphaInfo.SetActive(false);
        SoundManager.Instance.PlaySFX(7);
    }

    public void AlphaInfoExitBtnOn() 
    {
        GameManager.Instance.GameOver();
        Debug.Log("게임 종료");
        SoundManager.Instance.PlaySFX(2);
    }

    public void SettingBtnOn()
    {
        SettingWindow.SetActive(true);
    }

    //스타트 버튼
    public void StartBtnOn()
    {
        SoundManager.Instance.PlaySFX(2);
        //이전에 난이도 버튼을 눌렀을 경우 해당 난이도로 이동
        if (SceneChangeManager.Instance.startLevel > 0 && SceneChangeManager.Instance.startLevel < 4)
        {
            SceneChangeManager.Instance.FirstSceneChange(SceneChangeManager.Instance.startLevel);
        }
        //바로 시작할 경우 EASY 난이도로 이동
        else 
        {
            SceneChangeManager.Instance.SceneChanger(1); 
        }
    }
}



