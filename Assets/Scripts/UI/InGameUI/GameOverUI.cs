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

    //�ش� �� �����
    public void RetryBtnOn()
    {
        // Ŭ�� ȿ����
        SoundManager.Instance.PlaySFX(2);
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(SceneChangeManager.Instance.level);
    }

    //ĳ���� ����â���� �̵�
    public void GiveUpBtn()
    {
        // Ŭ�� ȿ����
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
