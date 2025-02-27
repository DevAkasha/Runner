using System;
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
    private ClipInfo[] bgms;

    private ClipInfo[] sfxs;

    [SerializeField] ClipInfos clipInfos;

    private AudioSource bgmAudioSource;
    private AudioSource sfxAudioSource;

    protected override void Awake()
    {
        base.Awake();

        CreateAudioSourceObject("BgmAudioSource", out bgmAudioSource);

        CreateAudioSourceObject("SfxAudioSource", out sfxAudioSource);

        // clipInfos라는 ScriptableObject를 받아와 clip들 초기화
        if (clipInfos == null)
        {
            clipInfos = Resources.Load<ClipInfos>("ScriptableObject/Clip Data");
            bgms = clipInfos.bgms;
            sfxs = clipInfos.sfxs;
        }
    }

    private void CreateAudioSourceObject(string name, out AudioSource audioSource)
    {
        GameObject go = new GameObject(name);
        audioSource = go.AddComponent<AudioSource>();
        go.transform.parent = transform;
    }

    public void PlaySFX(int index)
    {
        if (sfxAudioSource == null)
            return;

        sfxAudioSource.volume = sfxs[index].volume;
        sfxAudioSource.PlayOneShot(sfxs[index].audioClip);
    }

    public void PlayBgm(int index)
    {
        if (bgmAudioSource == null)
            return;

        bgmAudioSource.volume = bgms[index].volume;
        bgmAudioSource.clip = bgms[index].audioClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }
}
