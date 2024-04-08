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

    // Define delegates and events for UI actions
    public delegate void OnPauseGame();
    public static event OnPauseGame onPauseGame;

    public delegate void OnResumeGame();
    public static event OnResumeGame onResumeGame;

    
    public delegate void OnGameOver();
    public static event OnGameOver onGameOver;

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
        scoreText.text = Score.ToString();
    }

    public void UpdateLives(int points)
    {
        Lives += points;
        livesText.text = Lives.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void HandleGameOver()
    {
        Time.timeScale = 0;
        onGameOver?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Lives <= 0)
        {
            HandleGameOver();
        }
        if (Score < 0)
        {
            Score = 0;
        }
    }
}
