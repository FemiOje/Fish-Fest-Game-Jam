using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score { get; private set; }
    public int Lives { get; private set; }

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI livesText;

    private int _defaultScore = 0;
    private int _defaultLives = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Lives = _defaultLives;
        Score = _defaultScore;
    }

    public void UpdateScore(int points)
    {
        Score += points;
        scoreText.text = "Score: " + Score;
    }

    public void UpdateLives(int points)
    {
        Lives += points;
        livesText.text = "Lives: " + Lives;
    }

    public void HandleGameOver()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowGameOverPanel();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowPausePanel();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        UIManager.Instance.HidePausePanel();
    }

    private void Update()
    {
        if (Lives <= 0) { 
            HandleGameOver();
        }
        if (Score < 0)
        {
            Score = 0;
        }
    }
}
