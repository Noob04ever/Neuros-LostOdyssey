using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Audio Mixer")]
    [Space]

    [SerializeField] private AudioMixer MixerController;

    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SoundsSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            UpdateMasterVolumeSettings();
            UpdateMusicVolumeSettings();
            UpdateSoundsVolumeSettings();
        }
    }

    public void UpdateMasterVolumeSettings()
    {
        float MasterVolume = MasterSlider.value;
        MixerController.SetFloat("MasterVolume", Mathf.Log10(MasterVolume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
    }

    public void UpdateMusicVolumeSettings()
    {
        float MusicVolume = MusicSlider.value;
        MixerController.SetFloat("MusicVolume", 10 + Mathf.Log10(MusicVolume) * 20);
        // Update Player Preference Save File
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
    }

    public void UpdateSoundsVolumeSettings()
    {
        float SoundsVolume = SoundsSlider.value;
        MixerController.SetFloat("SoundsVolume", 10 + Mathf.Log10(SoundsVolume) * 20);
        PlayerPrefs.SetFloat("SoundsVolume", SoundsVolume);
    }

    private void LoadVolume()
    {
        // Load all three of the Volume in player prefs if they exists
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        UpdateMasterVolumeSettings();
        
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        UpdateMusicVolumeSettings();
        
        SoundsSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
        UpdateSoundsVolumeSettings();
    }
}
