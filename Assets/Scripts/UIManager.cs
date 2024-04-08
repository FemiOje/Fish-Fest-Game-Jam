using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public Button resumeButton;
    public Button pauseButton;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static UIManager Instance;


    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        HidePausePanel();
    }


    // Awake method to ensure singleton pattern
     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy(gameObject);
        }
    }

     private void OnEnable()
    {
        // Subscribe to GameManager events
        GameManager.onPauseGame += ShowPausePanel;
        GameManager.onResumeGame += HidePausePanel;
        GameManager.onGameOver += ShowGameOverPanel;
    }

    private void OnDisable()
    {
        // Unsubscribe from GameManager events
        GameManager.onPauseGame -= ShowPausePanel;
        GameManager.onResumeGame -= HidePausePanel;
        GameManager.onGameOver -= ShowGameOverPanel;
    }
}
