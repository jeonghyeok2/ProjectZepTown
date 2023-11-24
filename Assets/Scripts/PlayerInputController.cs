using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{   //플레이어의 움직임을 감지하는 스크립트

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main; //Main카메라를 가져오겠다.
    }

    public void OnMove(InputValue _value)
    {
        Vector2 _moveInput = _value.Get<Vector2>();
        CallMoveEvent(_moveInput); //이벤트 호출 
    }
    public void OnLook(InputValue _value)
    {   //InputSystem에 있는 Look의 값을 가지고와서 Vector2값으로 저장
        Vector2 _lookAim = _value.Get<Vector2>();
        //카메라의 월드 좌표로 바꿔줌
        Vector2 _worldPos = _camera.ScreenToWorldPoint(_lookAim);
        //마우스 포지션과 현재 나의 포지션을 바꾸고 값을 1로 만들어줌 == 방향을 구함
        _lookAim = (_worldPos - (Vector2)transform.position).normalized;
        //
        if (_lookAim.magnitude >= .9f)
        {
            CallLookEvent(_lookAim); //이벤트 호출
        }
    }
}
