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

    //ĳ���� ����â���� �̵�
    public void SelectionStage()
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
