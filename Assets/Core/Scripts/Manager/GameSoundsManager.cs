using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSoundsManager : MonoBehaviour
{

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer MixerController;
    [SerializeField] private AudioSource RhythmAudioSource;

    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SoundsSlider;

    [Header("Menu Sounds")]
    [SerializeField] private AudioClip ButtonHoveredAudio;
    [SerializeField] private AudioClip ButtonPressedAudio;

    [Header("Game Sounds")]
    [SerializeField] private AudioClip TriggeredAudio;
    [SerializeField] private AudioClip MissedAudio;


    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            if(MasterSlider)
            {
                UpdateMasterVolumeSettings();
            }
            if(MusicSlider)
            {
                UpdateMusicVolumeSettings();
            }
            if(SoundsSlider)
            {
                UpdateSoundsVolumeSettings();
            }
        }
    }
#region Volume Settings
    public void UpdateMasterVolumeSettings()
    {
        float MasterVolume = MasterSlider.value;
        MixerController.SetFloat("MasterVolume", Mathf.Log10(MasterVolume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
    }

    public void UpdateMusicVolumeSettings()
    {
        float MusicVolume = MusicSlider.value;
        MixerController.SetFloat("MusicVolume", Mathf.Log10(MusicVolume) * 20);
        // Update Player Preference Save File
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
    }

    public void UpdateSoundsVolumeSettings()
    {
        float SoundsVolume = SoundsSlider.value;
        MixerController.SetFloat("SoundsVolume", Mathf.Log10(SoundsVolume) * 20);
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
 #endregion

#region MenuSounds

    public void PlayButtonHoverSound()
    {
        ActivateAudio(ButtonHoveredAudio);
    }


    public void PlayButtonPressedSound()
    {
        ActivateAudio(ButtonPressedAudio);
    }
#endregion

    public void ActivateAudio(AudioClip audioClip)
    {
        RhythmAudioSource.clip = audioClip;
        RhythmAudioSource.Play();
    }

    public void ActivateTriggeredAudio()
    {
        RhythmAudioSource.clip = TriggeredAudio;
        RhythmAudioSource.Play();
    }


    public void ActivateMissedAudio()
    {


    }
}
