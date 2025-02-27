using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GemType { Diamond, Emerald, ruby }

public class GemStone : Item
{
    [SerializeField] GemType type;
    GameManager gameManager;
    public void Start()
    {
        gameManager = GameManager.Instance;
    }
    protected override void ApplyEffect(PlayerAction player,int hitMultiplier)
    {
        gameManager.SetHasGemStone((int)type,player);
        switch (type)
        {
            case GemType.Diamond:
                gameManager.AddScore(200);
                break;
            case GemType.Emerald:
                gameManager.AddScore(150);
                break;
            case GemType.ruby:
                gameManager.AddScore(100);
                break;
        }
    }
    protected override void ApplyEffect(PlayerAction player) { }
}
