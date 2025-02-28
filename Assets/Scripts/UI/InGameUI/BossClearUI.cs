using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClearUI : MonoBehaviour
{
    [SerializeField] private GameUIManager gameUI;

    private void Start()
    {
        if (gameUI == null)
            gameUI = FindObjectOfType<GameUIManager>(true);
        SetActive(false);
    }

    //캐릭터 선택창으로 이동
    public void SelectionStage()
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
