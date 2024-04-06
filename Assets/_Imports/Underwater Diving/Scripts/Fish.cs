using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private PlayerController _player;
    public GameObject death;

    public float speed = 0.3f;

    [SerializeField]
    private float turnTimer;
    public float timeTrigger;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();

        turnTimer = 0;
        timeTrigger = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(
            _rigidbody.transform.localScale.x * speed,
            _rigidbody.velocity.y,
            0f
        );

        turnTimer += Time.deltaTime;
        if (turnTimer >= timeTrigger)
        {
            TurnAround();
            turnTimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CollectFish();
        }
    }

    void TurnAround()
    {
        if (transform.localScale.x == 1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void CollectFish()
    {
        ScoreManager.Instance.UpdateScore(1);
        Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
