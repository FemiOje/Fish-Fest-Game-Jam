using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    AudioSource _audioSource;
    public int Score { get; private set; }
    public int Lives { get; private set; }
    private int _defaultScore = 0;
    private int _defaultLives = 5;
    
    
    [Header("Text")]
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    
    
    [Header("Audio")]
    [SerializeField] AudioSource gameMusic;
    [SerializeField] AudioClip gameOverAudioClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        InitializeLevel();
    }

    private void Update()
    {
        if (Lives <= 0)
        {
            HandleGameOver();
        }
    }





    private void InitializeLevel()
    {
        Lives = _defaultLives;
        Score = _defaultScore;
        scoreText.text = Score.ToString();
        Time.timeScale = 1f;
    }
  
    public void UpdateLives(int points)
    {
        Lives += points;
        livesText.text = Lives.ToString();
    }

    public void UpdateScore(int points)
    {
        Score += points;

        // Ensure Score doesn't become negative
        Score = Mathf.Max(Score, 0);
        scoreText.text = Score.ToString();
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
        if (gameMusic != null)
        {
            gameMusic.Stop();
        }
        
        if (_audioSource != null)
        {
            _audioSource.PlayOneShot(gameOverAudioClip);
        }

        StartCoroutine(UIManager.Instance.FadeInGameOverPanel());
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnDisable() {
        UIManager.Instance.HideGameOverPanel();
    }
}
