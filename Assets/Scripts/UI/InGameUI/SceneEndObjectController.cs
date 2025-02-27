using TMPro;
using UnityEngine;

public class SceneEndObjectController : MonoBehaviour
{
    public GameObject StageEndBoard;
    public GameObject NextStageBtn;
    public GameObject ChooseStageBtn;
    
    public GameObject GameUI;

    public TextMeshProUGUI ClearBestScorenumTxt;
    public TextMeshProUGUI ClearNowScorenumTxt;

    //기본 세팅
    private void Awake()
    {
        StageEndBoard.SetActive(false);
    }
    //충돌했을 때 일시정지&보드켜기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //최고 점수 갱신하기
        GameManager.Instance.UpdateBestScore();
        ClearBestScorenumTxt.text = GameManager.Instance.BestScore.ToString();
        //현재 점수 불러오기
        ClearNowScorenumTxt.text = GameManager.Instance.Score.ToString();
        //일시정지
        Time.timeScale = 0f;
        //인게임UI끄고 EndBoard 띄우기
        GameUI.SetActive(false);
        StageEndBoard.SetActive(true);
    }
    //다음 스테이지 버튼 눌렀을 때 다음 씬으로 이동
    public void NextStageBtnOn() 
    {
        Time.timeScale = 1f;
        PassScene();
    }
    //캐릭터 선택 화면으로 이동
    public void ChooseStageBtnOn() 
    {
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(0);
    }
    //레벨 하나 높이고 씬 불러오기
    public void PassScene() 
    {
        SceneChangeManager.Instance.startLevel += 1;
        SceneChangeManager.Instance.SceneChanger(SceneChangeManager.Instance.startLevel);
    }
}
