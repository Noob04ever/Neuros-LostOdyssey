using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI RankText;

    private float Score = 0;
    private string Rank = "D";

    [Space]

    [SerializeField] private int ReplayIndex = 0;
    [SerializeField] private int ContinueIndex = 0;


    private void Start()
    {

        Score = GameManager.Instance.CompletedScore;
        ScoreText.text = "Final Score: " + Score;
        Rank = GameManager.Instance.CompletedRank;
        RankText.text = Rank;
    }

    public void ReplayButtonPressed()
    {
        GameManager.Instance.LoadLevel(ReplayIndex);
    }


    public void ContinueButtonPressed()
    {

        GameManager.Instance.LoadLevel(ContinueIndex);

    }

    public void ExitButtonPressed()
    {
        GameManager.Instance.LoadLevel(0);
    }
}
