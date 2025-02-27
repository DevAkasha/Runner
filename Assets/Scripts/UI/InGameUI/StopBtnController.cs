using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtnController : MonoBehaviour
{
    public GameObject StopBtn;
    public GameObject StopBoard;
    private GameUIManager level;

    //�⺻ ����
    void Awake()
    {
        StopBoard.SetActive(false);
        StopBtn.SetActive(true);
        level = FindObjectOfType<GameUIManager>();
    }
    //��ư ������ �Ͻ����� ���� �ѱ�
    public void StopBtnOn()
    {
        Time.timeScale = 0f;
        StopBoard.SetActive(true);
    }

    //�Ͻ����� ���� ����
    public void StopBoardCloseBtn()
    {
        Time.timeScale = 1f;
        StopBoard.SetActive(false);
    }
    
    //�ش� �� �����
    public void RetryBtnOn() 
    {
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(level.levelSet);
    }

    //ĳ���� ����â���� �̵�
    public void GiveUpBtn()
    {
        Time.timeScale = 1f;
        SceneChangeManager.Instance.SceneChanger(0);
    }
}
