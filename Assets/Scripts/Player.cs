using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    
    [Range(1, 20)]
    public float moveSpeed = 5f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start Player");
    }

    // Update is called once per frame
    void Update()
    {
     float horizontal = Input.GetAxisRaw("Horizontal");
     float vertical = Input.GetAxisRaw("Vertical");
     
     _movement = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _movement * moveSpeed;
    }
}
