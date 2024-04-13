using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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

    private void Start() {
        Time.timeScale = 1f;       
    }

    public IEnumerator FadeInGameOverPanel()
    {
        // // Get the initial alpha value of the game over panel
        // CanvasGroup canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
        // float alpha = canvasGroup.alpha;

        // // Gradually increase the alpha value to fade in the panel
        // float elapsedTime = 0f;
        // while (elapsedTime < gameOverFadeDuration)
        // {
        //     elapsedTime += Time.deltaTime;
        //     canvasGroup.alpha = Mathf.Lerp(alpha, 1f, elapsedTime / gameOverFadeDuration);
        //     yield return null;
        // }

        // // Ensure the alpha value is set to 1 after fading
        // canvasGroup.alpha = 1f;
        yield return new WaitForSeconds(gameOverFadeDuration);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

  
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
}
