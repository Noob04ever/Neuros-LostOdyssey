using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public GameSoundsManager SoundManager;



    public float CompletedScore;
    public string CompletedRank;
    public int currentLevelIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void FindSoundManager()
    {
        SoundManager = FindObjectOfType<GameSoundsManager>();
    }

    public void LoadLevel(int LevelIndex)
    {
        currentLevelIndex = LevelIndex;
        SceneManager.LoadScene(LevelIndex);

    }




}
