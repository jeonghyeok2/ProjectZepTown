using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   //�÷��̾��� �������� ���������� ���� ���޹޾� �����̴� ��ũ��Ʈ
    // �̺�Ʈ�� �����ϱ� ���� ���� ����
    PlayerController _controller;
    //�����̱� ���� ���⺯���� ����� �ʱ�ȭ��
    Vector2 _movementDirection = Vector2.zero;
    //���� �ֱ����� ����
    Rigidbody2D _rigid;
    //����ȭ
    [SerializeField] private int _speed; //�ӵ�

    private void Awake()
    {   //���� �־���
        _controller = GetComponent<PlayerController>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {   // _controller�� OnMoveEvent�� Move�Լ��� ������
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {   //���� ���� 0���� �������� Player�� �����̴� �Լ��� �۵���
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 _direction)
    {   //���� �Է¹޾� OnMove�� ����Ǹ� CallMoveEvent�Լ��� ����� �׷� 
        //�Լ��ȿ� �ִ� Event�� ����ǰ� ������ Move�� ������ �˷��� 
        _movementDirection = _direction;
    }

    private void ApplyMovement(Vector2 _direction) //������ ���� * �ӵ�
    {
        _direction = _direction * _speed;
        _rigid.velocity = _direction;
    }
}
