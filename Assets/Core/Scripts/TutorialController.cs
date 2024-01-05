using Dypsloom.RhythmTimeline.Core.Managers;
using Dypsloom.RhythmTimeline.Scoring;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    // probalay can make parnt inheritaance for beter structure but...
    [SerializeField] private RhythmDirector TutorialRhythmDirector;
    [Space]
    [SerializeField] private GameObject TimerCanvas;
    [SerializeField] private TextMeshProUGUI TimerText;
    [Space]
    [SerializeField] private GameObject TutorialPromptCanvas;
    [SerializeField] private TextMeshProUGUI TutorialPromptText;
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


    private void Start()
    {
        StartCoroutine("StartCountdown");
        TutorialRhythmDirector.OnSongEnd += OnSongEnd;
        GameManager.Instance.MainMenuCanvasCheck();
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
        StartCoroutine("StartTutorialPrompt");
    }

    private IEnumerator StartTutorialPrompt()
    {

        yield return new WaitForSeconds(5.0f);
        SongDisplayCanvas.SetActive(false);
        TutorialPromptCanvas.SetActive(true);
        TutorialPromptText.text = "Collect Heart Pieces to return Neuro's memories";
        yield return new WaitForSeconds(5.0f);
        TutorialPromptText.text = "Press <sprite=1> to collect hearts on the Ground";
        yield return new WaitForSeconds(13.3f);
        TutorialPromptText.text = "Press <sprite=0> to collect hearts on the Air";
        yield return new WaitForSeconds(15.7f);
        TutorialPromptText.text = "Press both <sprite=1> and <sprite=0> for both Ground and Air";
        yield return new WaitForSeconds(12.0f);
        TutorialPromptText.text = "Hold <sprite=1> to collect hearts on the Ground";
        yield return new WaitForSeconds(8.0f);
        TutorialPromptText.text = "Hold <sprite=0> to collect hearts on the Air";
        yield return new WaitForSeconds(6.5f);
        TutorialPromptText.text = "Press both <sprite=1> and <sprite=0> quickly to collect persistence hearts";
        yield return new WaitForSeconds(11.0f);
        TutorialPromptText.text = "Now put everything in practice to collect all the hearts";
    }

    private IEnumerator CompleteLevel()
    {
        GameManager.Instance.CompletedScore = ScoreManager.Instance.GetScore();
        GameManager.Instance.CompletedRank = ScoreManager.Instance.GetRank().name;
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.LoadLevel(2);
    }
}
