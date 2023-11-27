using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Event는 델리게이트와 같이 사용가능한데 Action도 자세히 보면 Delegate임
/// </summary>
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
