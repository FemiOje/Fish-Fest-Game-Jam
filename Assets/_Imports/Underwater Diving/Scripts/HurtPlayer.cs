using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private PlayerController _player;

    // Use this for initialization
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.Hurt();
        }
		ScoreManager.Instance.UpdateScore(-1);
    }
}
