using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct ClipInfo
{
    public AudioClip audioClip;
    public float volume;
}

public class SoundManager : Manager<SoundManager>
{
    private AudioSource audioSource;

    private ClipInfo[] bgms;

    private ClipInfo[] sfxs;

    [SerializeField] ClipInfos clipInfos;

    protected override void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();

        // audioSource가 없다면 새로 만들어서 넣어줌
        if (audioSource == null)
            audioSource = transform.AddComponent<AudioSource>();

        // clipInfos라는 ScriptableObject를 받아와 clip들 초기화
        if (clipInfos == null)
        {
            clipInfos = Resources.Load<ClipInfos>("ScriptableObject/Clip Data");
            bgms = clipInfos.bgms;
            sfxs = clipInfos.sfxs;
        }
    }

    public void PlaySFX(int index)
    {
        if (audioSource == null)
            return;

        audioSource.volume = sfxs[index].volume;
        audioSource.PlayOneShot(sfxs[index].audioClip);
    }

    public void PlayBgm(int index)
    {
        if (audioSource == null)
            return;

        audioSource.volume = bgms[index].volume;
        audioSource.clip = bgms[index].audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
