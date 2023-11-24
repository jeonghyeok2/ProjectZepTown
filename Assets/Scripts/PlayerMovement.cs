using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerController _controller;
    Vector2 _movementDirection = Vector2.zero;
    Rigidbody2D _rigid;

    [SerializeField] private int _speed; //속도

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 _direction)
    {
        _movementDirection = _direction;
    }

    private void ApplyMovement(Vector2 _direction) //움직임 적용
    {
        _direction = _direction * _speed;
        _rigid.velocity = _direction;
    }
}
