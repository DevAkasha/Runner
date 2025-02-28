using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtnController : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;

    //�⺻ ����
    void Awake()
    {
        StopBoard.SetActive(false);
        StopBtn.SetActive(true);
    }
    //��ư ������ �Ͻ����� ���� �ѱ�
    public void StopBtnOn()
    {
        // Ŭ�� ȿ����
        SoundManager.Instance.PlaySFX(2);
        Time.timeScale = 0f;
        StopBoard.SetActive(true);
    }

    //�Ͻ����� ���� ����
    public void StopBoardCloseBtn()
    {
        // Ŭ���� ȿ����
        SoundManager.Instance.PlaySFX(7);
        Time.timeScale = 1f;
        StopBoard.SetActive(false);
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
}
