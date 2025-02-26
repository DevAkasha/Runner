using UnityEngine;
using UnityEngine.UIElements;
using System;

public class GameManager : Manager<GameManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    public int score;
    public int feverMultiplier = 1;
    public int Score { get; private set; }

    public int bestScore;
    public int BestScore { get { return bestScore; } private set { bestScore = value; } }

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
        if(Array.TrueForAll(hasGemStone, x => x))
        {
            player.StartCoroutine(player.SetFever(5f));
        }
    }
    public void InitFields()
    {
        score = 0;
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
