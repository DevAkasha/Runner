using System;
using UnityEngine;

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

    [SerializeField]private float bgmVolumeRatio =1f;
    [SerializeField]private float sfxVolumeRatio =1f;
    private float originalBgmVolume = 1f;
    private float originalSfxVolume = 1f;

    protected override void Awake()
    {
        base.Awake();

        CreateAudioSourceObject("BgmAudioSource", out bgmAudioSource);

        CreateAudioSourceObject("SfxAudioSource", out sfxAudioSource);

        // clipInfos��� ScriptableObject�� �޾ƿ� clip�� �ʱ�ȭ
        if (clipInfos == null)
        {
            clipInfos = Resources.Load<ClipInfos>("ScriptableObject/Clip Data");
            bgms = clipInfos.bgms;
            sfxs = clipInfos.sfxs;
        }
    }

    private void Update()
    {
        UpdateBGMVolume();
    }

    private void CreateAudioSourceObject(string name, out AudioSource audioSource)
    {
        GameObject go = new GameObject(name);
        audioSource = go.AddComponent<AudioSource>();
        go.transform.parent = transform;
    }

    public void PlaySFX(int index)
    {
        if (sfxAudioSource == null || sfxs == null || index < 0 || index >= sfxs.Length)
        {
            Debug.LogWarning("SFX �ε����� �߸��Ǿ����ϴ�.");
            return;
        }

        originalSfxVolume = sfxs[index].volume;
        sfxAudioSource.volume = sfxs[index].volume * sfxVolumeRatio;
        sfxAudioSource.PlayOneShot(sfxs[index].audioClip);
    }

    public void PlayBgm(int index)
    {
        if (bgmAudioSource == null || bgms == null || index < 0 || index >= bgms.Length)
        {
            Debug.LogWarning("BGM �ε����� �߸��Ǿ����ϴ�.");
            return;
        }

        bgmAudioSource.clip = bgms[index].audioClip;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();

        originalBgmVolume = bgms[index].volume;
        UpdateBGMVolume();
    }

    public void SetBGMVolume(float Ratio)
    {
        bgmVolumeRatio = Ratio;
        UpdateBGMVolume();
    }

    public void SetSFXVolume(float Ratio)
    {
        sfxVolumeRatio = Ratio;
    }

    private void UpdateBGMVolume()
    {
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.volume = originalBgmVolume * bgmVolumeRatio;
        }
    }
}
