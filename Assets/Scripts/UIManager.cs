using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public Button resumeButton;
    public Button pauseButton;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static UIManager Instance;
    private float gameOverFadeDuration = 0.5f;


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
        Time.timeScale = 1f;       
    }

    public IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(gameOverFadeDuration);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}
