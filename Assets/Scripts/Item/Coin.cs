using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int ScoreValue = 500;

    protected override void ApplyEffect()
    {
        GameManager.Instance.AddScore(ScoreValue);
    }
}
