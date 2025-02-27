using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private GameUIManager gameUI;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUIManager>();
        SetActive(false);
    }

    //해당 씬 재시작
    public void RetryBtnOn()
    {
        // 클릭 효과음
        SoundManager.Instance.PlaySFX(2);
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(SceneChangeManager.Instance.level);
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
        gameUI.gameObject.SetActive(!isActive);
    }
}
