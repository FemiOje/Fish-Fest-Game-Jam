using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private PlayerController _player;
    public GameObject death;
    public float speed = 0.3f;

    [SerializeField]
    float turnTimer;

    [SerializeField]
    float timeTrigger;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private int _points;

    public enum TypeOfFish
    {
        Domestic,
        Wild
    }

    public TypeOfFish typeOfFish;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        CalculatePoints(typeOfFish);
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


    public void CalculatePoints(TypeOfFish typeOfFish)
    {
        switch (typeOfFish)
        {
            case TypeOfFish.Domestic:
                _points = 1;
                break;
            case TypeOfFish.Wild:
                _points = -1;
                break;
            default:
                Debug.LogWarning("Set typeOfFish to domestic or wild");
                break;
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
        GameManager.Instance.UpdateScore(_points);
        Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
