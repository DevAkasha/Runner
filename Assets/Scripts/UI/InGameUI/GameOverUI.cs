using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        SetActive(false);
    }

    //해당 씬 재시작
    public void RetryBtnOn()
    {
        // 클릭 효과음
        SoundManager.Instance.PlaySFX(2);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //캐릭터 선택창으로 이동
    public void GiveUpBtn()
    {
        // 클릭 효과음
        SoundManager.Instance.PlaySFX(2);
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(0);
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
