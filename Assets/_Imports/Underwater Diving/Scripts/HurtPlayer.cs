using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private PlayerController _player;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        if (_player == null)
        {
            Debug.Log("PlayerController script does not exist in the scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.Hurt();
        }
        GameManager.Instance.UpdateScore(-1);
    }
}
