using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : Manager<SceneChangeManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    //SelectScene에서 입력받은 레벨
    //1=Easy 2=Normal 3=Hard
    public int startLevel;
    public int level;

    //이전 선택한 값과 입력받은 값 동일할 경우 해당 씬에 이동
    public void FirstSceneChange(int selectlevel) 
    {
        //미리 입력받은 레벨과 지금 진행할 레벨이 일치하는지 확인
        if (startLevel == selectlevel)
        {
            SceneChanger(selectlevel);
            return;
        }
        //바로 스타트 버튼 눌렀을 경우 EASY로 이동
        else if (selectlevel == 0) 
        {
            SceneChanger(1);
            return;
        }
        else 
        { 
            Debug.Log("처음 입력받은 레벨과 이동하고자 하는 레벨이 다릅니다.");
            return;
        }
        
    }

    //입력받은 씬에 이동
    //1=Easy 2=Normal 3=Hard 0=Selection -1=Tutorial
    public void SceneChanger(int level) 
    {
        // 씬 변경 시 마다 GemStone 초기화
        GameManager.Instance.InitGemStone();
        GameManager.Instance.InitScore();
        this.level = level;

        switch (level)
        {
            case 4:
                Debug.Log("아직 보스전이 없습니다.");
                break;
            case 3:
                SceneManager.LoadScene("Hard");
                SoundManager.Instance.PlayBgm(1);
                break;
            case 2:
                SceneManager.LoadScene("Normal");
                SoundManager.Instance.PlayBgm(1);
                break;
            case 1:
                SceneManager.LoadScene("Easy");
                SoundManager.Instance.PlayBgm(1);
                break;
            case -1:
                SceneManager.LoadScene("TutorialScene");
                break;
            case 0:
                SceneManager.LoadScene("SelectionScene");
                SoundManager.Instance.PlayBgm(0);
                break;
            default:
                Debug.Log("씬 이동 오류");
                break;
        }
    }

}
