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

    //�ش� �� �����
    public void RetryBtnOn()
    {
        // Ŭ�� ȿ����
        SoundManager.Instance.PlaySFX(2);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    }
}
