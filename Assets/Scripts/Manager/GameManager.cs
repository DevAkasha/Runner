using UnityEngine;
using UnityEngine.UIElements;
using System;

public class GameManager : Manager<GameManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    public int score;
    public int feverMultiplier = 1;

    public float feverTime = 5f;
    public int Score { get; private set; }

    public int bestScore;
    public int BestScore { get { return bestScore; } private set { bestScore = value; } }

    int gemTypeCount;
    public bool[] hasGemStone;

    protected override void Awake()
    {
        base.Awake();
        gemTypeCount = System.Enum.GetValues(typeof(GemType)).Length;
        hasGemStone = new bool[gemTypeCount];
    }

    public void AddScore(int score)
    {
        Score += score* feverMultiplier;
    }

    public void UpdateBestScore()
    {
        if (BestScore < Score) 
        { 
            BestScore = Score;
        }
    }

    public void SetHasGemStone(int index,PlayerAction player)
    {
        hasGemStone[index] = true;
        //모든 잼스톤이 true이면 플레이어 피버모드 발동!
        if(Array.TrueForAll(hasGemStone, x => x))
        {
            player.StartCoroutine(player.SetFever(feverTime));
            Invoke("InitGemStone", feverTime);
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
