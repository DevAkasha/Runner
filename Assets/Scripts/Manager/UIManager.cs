using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager<UIManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => false;

    [SerializeField] View scoreView;




}
