using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int Score { get; private set; }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            Score++;
            Destroy(other.gameObject);
        }
    }
}
