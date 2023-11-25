using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �÷��̾��� �������� �Է¹޾� �̺�Ʈ ȣ��
/// </summary>
public class PlayerInputController : PlayerController
{   
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main; //Mainī�޶� �������ڴ�.
    }

    public void OnMove(InputValue _value)
    {
        Vector2 _moveInput = _value.Get<Vector2>();
        CallMoveEvent(_moveInput); //�̺�Ʈ ȣ�� 
    }
    public void OnLook(InputValue _value)
    {   //InputSystem�� �ִ� Look�� ���� �������ͼ� Vector2������ ����
        Vector2 _lookAim = _value.Get<Vector2>();
        //ī�޶��� ���� ��ǥ�� �ٲ���
        Vector2 _worldPos = _camera.ScreenToWorldPoint(_lookAim);
        //���콺 �����ǰ� ���� ���� �������� �ٲٰ� ���� 1�� ������� == ������ ����
        _lookAim = (_worldPos - (Vector2)transform.position).normalized;
        //
        if (_lookAim.magnitude >= .9f)
        {
            CallLookEvent(_lookAim); //�̺�Ʈ ȣ��
        }
    }
}