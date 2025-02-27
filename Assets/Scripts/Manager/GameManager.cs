using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum Character { Victor , Nathan , Elena }

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
    public int characterIndex = 1;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode slideKey = KeyCode.LeftShift;
    public KeyCode attackKey = KeyCode.C;

    [SerializeField] private GameObject[] chracterPrefabArray;

    protected override void Awake()
    {
        base.Awake();
        gemTypeCount = System.Enum.GetValues(typeof(GemType)).Length;
        hasGemStone = new bool[gemTypeCount];
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Easy":
            case "Normal":
            case "Hard":
                SoundManager.Instance.PlayBgm(1);
                break;
            case "Tutorial":
                SoundManager.Instance.PlayBgm(2);
                break;
            case "Hidden":
                break;
            default:
                SoundManager.Instance.PlayBgm(0);
                break;
        }
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
            Invoke(nameof(InitGemStone), feverTime);
        }
    }
    public void InitGemStone()
    {
        for (int i=0; i < gemTypeCount; i++)
        {
            hasGemStone[i] = false;
        }
    }

    public void createCharacter()
    {
        Instantiate<GameObject>(chracterPrefabArray[characterIndex],new Vector3(-5.1f,-1.5f,0f), Quaternion.identity);
    }

    public void GameOver()
    {
       GameUIManager.Instance.OpenGameOverBoard();
    }
}
