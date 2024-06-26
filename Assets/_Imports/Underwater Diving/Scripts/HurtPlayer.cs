﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    private Player _player;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        if (_player == null)
        {
            Debug.Log("Player script does not exist in the scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player.Hurt();
        }
    }
}
