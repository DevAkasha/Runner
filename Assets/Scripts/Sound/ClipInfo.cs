using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clip Data", menuName = "Scriptable Object/Clip Data", order = int.MaxValue)]
[System.Serializable]
public class ClipInfos : ScriptableObject
{
    public ClipInfo[] bgms;

    public ClipInfo[] sfxs;
}
