using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : Manager<SceneChangeManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    //1=Easy 2=Normal 3=Hard
    public int level;

    //1=Victor 2=Nathon 3=Elena
    public int charactor;

    public void MoveScene() 
    { 
        
    }

}
