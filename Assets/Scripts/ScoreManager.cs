using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public event Action OnIncreaseScore;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int Score { get; private set; }

    public void UpdateScore(int points)
    {
        Score += points;
        scoreText.text = "Score: " + Score;
    }
}
