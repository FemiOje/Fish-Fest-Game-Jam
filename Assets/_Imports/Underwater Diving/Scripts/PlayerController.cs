using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    AudioSource _audioSource;

    [SerializeField] AudioClip _hurtClip1;

    [SerializeField] AudioClip _hurtClip2;

    [SerializeField] AudioClip _collectDomesticFishClip;

    [SerializeField] AudioClip _collectWildFishClip;
    public GameObject bubbles;
    private Vector2 _movementInput;
    SpriteRenderer _spriteRenderer;
    float horizontalInput;
    float verticalInput;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

        horizontalInput = 0;
        verticalInput = 0;
    }

    void Update()
    {
        HandleMovement();
        HandleSpriteDirection();
    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        _movementInput = new Vector2(horizontalInput, verticalInput);

        _rigidBody.AddForce(_movementInput * moveSpeed * Time.deltaTime);

        _animator.SetFloat("Speed", Mathf.Abs(_rigidBody.velocity.x));
    }

    private void HandleSpriteDirection()
    {
        if (horizontalInput > 0f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void Hurt()
    {
        _animator.Play("PlayerHurt");
        _audioSource.PlayOneShot(_hurtClip1);
        _audioSource.PlayOneShot(_hurtClip2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Fish fish = other.gameObject.GetComponent<Fish>();

            if (fish.typeOfFish == Fish.TypeOfFish.Domestic)
            {
                Debug.Log("Collided with domestic fish");
                _audioSource.PlayOneShot(_collectDomesticFishClip);
            }
            
            if (fish.typeOfFish == Fish.TypeOfFish.Wild)
            {
                Debug.Log("Collided with wild fish");
                _audioSource.PlayOneShot(_collectWildFishClip);
            }
        }
    }
}
