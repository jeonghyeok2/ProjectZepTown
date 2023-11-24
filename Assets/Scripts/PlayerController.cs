using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction) //옵저버가 실행
    {
        OnMoveEvent?.Invoke(direction);
        //OnMoveEvent에 구독한 모든 아이템이 호출됨
    }
    public void CallLookEvent(Vector2 direction) //옵저버
    {
        OnLookEvent?.Invoke(direction);
    }
}
