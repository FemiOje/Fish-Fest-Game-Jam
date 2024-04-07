using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score { get; private set; }
    public int Lives { get; private set; }

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

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

    private void Start() {
        Lives = 5;
        Score = 0;
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

    private void Update()
    {
        if (Lives <= 0)
        {
            //game over sequence
            Debug.Log("Game over");
            Time.timeScale = 0;
        }
    }
}
