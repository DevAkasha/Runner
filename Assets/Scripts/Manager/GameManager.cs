using UnityEngine;
using UnityEngine.UIElements;
using System;

public class GameManager : Manager<GameManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    public int feverMultiplier = 1;
    int score;
    public int Score { get; private set; }

    int gemTypeCount;
    public bool[] hasGemStone;

    private void Awake()
    {
        gemTypeCount = System.Enum.GetValues(typeof(GemType)).Length;
        hasGemStone = new bool[gemTypeCount];
    }

    public void AddScore(int score)
    {
        Score += score* feverMultiplier;
    }

    public void SetHasGemStone(int index,PlayerAction player)
    {
        hasGemStone[index] = true;
        //모든 잼스톤이 true이면 플레이어 피버모드 발동!
        if(Array.TrueForAll(hasGemStone, x => x))
        {
            player.StartCoroutine(player.SetFever(5f));
            InitGemStone();
        }
    }
    public void InitGemStone()
    {
        for (int i=0; i < gemTypeCount; i++)
        {
            hasGemStone[i] = false;
        }
    }
    public void GameOver()
    {
        //GameOverView SetActive
        //InitFields
    }

}
