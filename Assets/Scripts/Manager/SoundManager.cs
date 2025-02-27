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

    private float bgmVolumeRatio;
    private float sfxVolumeRatio;

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

        bgmVolumeRatio = 1f;
        sfxVolumeRatio = 1f;
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

        sfxAudioSource.volume = sfxs[index].volume * sfxVolumeRatio;
        sfxAudioSource.PlayOneShot(sfxs[index].audioClip);
    }

    public void PlayBgm(int index)
    {
        if (bgmAudioSource == null)
            return;

        bgmAudioSource.volume = bgms[index].volume * bgmVolumeRatio;
        bgmAudioSource.clip = bgms[index].audioClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void SetBgmVolume(float ratio)
    {
        bgmVolumeRatio = ratio;

        float volume = bgmAudioSource.volume;
        bgmAudioSource.volume = volume * bgmVolumeRatio;
    }

    public void SetSfxVolume(float ratio)
    {
        sfxVolumeRatio = ratio;
    }
}
