using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager<LevelManager>
{
    protected override bool isPersistent =>false;
        
    
    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.createCharacter();
    }
}