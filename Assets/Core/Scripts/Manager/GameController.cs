using Dypsloom.RhythmTimeline.Core.Managers;
using Dypsloom.RhythmTimeline.Scoring;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // probaly can make parent inheritance for better structure but...
    [SerializeField] private RhythmDirector TutorialRhythmDirector;
    [Space]
    [SerializeField] private GameObject TimerCanvas;
    [SerializeField] private TextMeshProUGUI TimerText;
    [Space]
    [SerializeField] private GameObject SongDisplayCanvas;
    [Space]
    [SerializeField] private GameObject GameUICanvas;

    [Space]
    [SerializeField] private Animator FadeAnimator;

    [Space]
    [SerializeField] private AudioSource GameAudioSource;
    [SerializeField] private AudioClip AudioThree;
    [SerializeField] private AudioClip AudioTwo;
    [SerializeField] private AudioClip AudioOne;
    [SerializeField] private AudioClip AudioGo;

    [Space]
    [SerializeField] private int CompletedSceneIndex = 1;

    private void Start()
    {
        StartCoroutine("StartCountdown");
        TutorialRhythmDirector.OnSongEnd += OnSongEnd;
    }

    private void OnSongEnd()
    {
        GameUICanvas.SetActive(false);
        FadeAnimator.SetTrigger("FadeOut");
        StartCoroutine("CompleteLevel");
    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(2.0f);
        // Set Start Text and Voice Countdown
        TimerCanvas.SetActive(true);
        SongDisplayCanvas.SetActive(true);
        GameAudioSource.clip = AudioThree;
        GameAudioSource.Play();
        TimerText.text = "3";
        yield return new WaitForSeconds(1.0f);
        GameAudioSource.clip = AudioTwo;
        GameAudioSource.Play();
        TimerText.text = "2";
        yield return new WaitForSeconds(1.0f);
        GameAudioSource.clip = AudioOne;
        GameAudioSource.Play();
        TimerText.text = "1";
        yield return new WaitForSeconds(1.0f);
        GameAudioSource.clip = AudioGo;
        GameAudioSource.Play();
        TimerText.text = "GO";
        yield return new WaitForSeconds(1.0f);
        TimerCanvas.SetActive(false);

        // Start Rhythm Game
        TutorialRhythmDirector.PlayAttachedAudio();

        yield return new WaitForSeconds(5.0f);
        SongDisplayCanvas.SetActive(false);
    }

    private IEnumerator CompleteLevel()
    {
        GameManager.Instance.CompletedScore = ScoreManager.Instance.GetScore();
        GameManager.Instance.CompletedRank = ScoreManager.Instance.GetRank().name;
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.LoadLevel(CompletedSceneIndex);
    }
}
