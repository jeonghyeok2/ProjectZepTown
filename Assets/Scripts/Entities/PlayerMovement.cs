using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 움직임을 감지받으면 값을 전달받아 움직이는 스크립트
/// 이벤트를 실행하기 위한 변수 설정
/// </summary>
public class PlayerMovement : MonoBehaviour
{   
    PlayerController _controller;
    Animator _animator;
    //움직이기 위한 방향변수를 만들고 초기화함
    Vector2 _movementDirection = Vector2.zero;
    //힘을 주기위한 물리
    Rigidbody2D _rigid;
    //직렬화
    [SerializeField] private int _speed; //속도

    private void Awake()
    {   //값을 넣어줌
        _controller = GetComponent<PlayerController>();
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {   // _controller의 OnMoveEvent에 Move함수를 구독함
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {   //방향 값이 0에서 정해지면 Player가 움직이는 함수가 작동됨
        ApplyMovement(_movementDirection);
    }
    private void LateUpdate()
    {
        _animator.SetFloat("Walk", _movementDirection.magnitude);
    }

    private void Move(Vector2 _direction)
    {   //값을 입력받아 OnMove가 실행되면 CallMoveEvent함수가 실행됨 그럼 
        //함수안에 있는 Event가 실행되고 구독한 Move가 방향을 알려줌 
        _movementDirection = _direction;
    }
    private void ApplyMovement(Vector2 _direction) //움직임 방향 * 속도
    {
        _direction = _direction * _speed;
        _rigid.velocity = _direction;
    }
}
