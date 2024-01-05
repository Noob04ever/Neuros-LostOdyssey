using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameSoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource RhythmAudioSource;


    [SerializeField] private AudioClip TriggeredAudio;
    [SerializeField] private AudioClip MissedAudio;


    public void ActivateTriggeredAudio()
    {
        RhythmAudioSource.clip = TriggeredAudio;
        RhythmAudioSource.Play();
    }


    public void ActivateMissedAudio()
    {


    }
}
