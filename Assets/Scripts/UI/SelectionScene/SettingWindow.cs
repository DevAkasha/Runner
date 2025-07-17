using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingWindow : MonoBehaviour
{
    [Header("Key Binding")]
    public Button jumpKeyButton;
    public Button slideKeyButton;
    public Button attackKeyButton;
    

    public TextMeshProUGUI jumpKeyText;
    public TextMeshProUGUI slideKeyText;
    public TextMeshProUGUI attackKeyText;

    private KeyCode waitingForKey = KeyCode.None; // 입력 대기 상태
    private string currentKeySetting = ""; // 현재 설정 중인 키

    [Header("Volume Sliders")]
    public Slider bgmVolumeSlider;
    public Slider effectVolumeSlider;
    public Button effectVolumeTestButton;

    public Button closeButton;

    private void Start()
    {
        LoadSettings();

        jumpKeyButton.onClick.AddListener(() => StartKeyRebinding("JumpKey"));
        slideKeyButton.onClick.AddListener(() => StartKeyRebinding("SlideKey"));
        attackKeyButton.onClick.AddListener(() => StartKeyRebinding("AttackKey"));

        bgmVolumeSlider.onValueChanged.AddListener(ChangeBGMVolume);
        effectVolumeSlider.onValueChanged.AddListener(ChangeEffectVolume);

        closeButton.onClick.AddListener(CloseSettings);
    }

    private void Update()
    {
        if (waitingForKey != KeyCode.None && Input.anyKeyDown) // 키 입력을 기다리는 상태일 때
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) // 모든 키 검사
            {
                if (Input.GetKeyDown(key))
                {
                    SetKey(currentKeySetting, key);
                    break;
                }
            }
        }
    }

    private void StartKeyRebinding(string keySetting)
    {
        currentKeySetting = keySetting;
        waitingForKey = KeyCode.Escape; // 입력 대기 상태 활성화

        switch (keySetting)
        {
            case "JumpKey":
                jumpKeyText.text = "Press Key...";
                break;
            case "SlideKey":
                slideKeyText.text = "Press Key...";
                break;
            case "AttackKey":
                attackKeyText.text = "Press Key...";
                break;
        }
    }

    private void SetKey(string keySetting, KeyCode newKey)
    {
        PlayerPrefs.SetString(keySetting, newKey.ToString());
        waitingForKey = KeyCode.None; // 입력 대기 해제

        switch (keySetting)
        {
            case "JumpKey":
                jumpKeyText.text = newKey.ToString();
                GameManager.Instance.jumpKey = newKey;
                break;
            case "SlideKey":
                slideKeyText.text = newKey.ToString();
                GameManager.Instance.slideKey = newKey;
                break;
            case "AttackKey":
                attackKeyText.text = newKey.ToString();
                GameManager.Instance.attackKey = newKey;
                break;
        }

        Debug.Log($"{keySetting} 변경됨: {newKey}");
    }

    private void LoadSettings()
    {
        jumpKeyText.text = PlayerPrefs.GetString("JumpKey", "Space");
        slideKeyText.text = PlayerPrefs.GetString("SlideKey", "LeftShift");
        attackKeyText.text = PlayerPrefs.GetString("AttackKey", "C");

        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);
    }

    private void ChangeBGMVolume(float value)
    {
        PlayerPrefs.SetFloat("BGMVolume", value);
        Debug.Log("BGM 볼륨: " + value);
        SoundManager.Instance.SetBGMVolume(value);
    }

    private void ChangeEffectVolume(float value)
    {
        PlayerPrefs.SetFloat("EffectVolume", value);
        Debug.Log("Effect 볼륨: " + value);
        SoundManager.Instance.SetSFXVolume(value);
    }

    public void OnTestBtnClick()
    {
        SoundManager.Instance.PlaySFX(2);
    }

    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
