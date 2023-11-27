using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _characterRenderer;

    [SerializeField] private PlayerController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 vector)
    {
        //각도가 마이너스가 되면 좌우 반전
        float _mousePosition = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
        if (_mousePosition < 0)
            _characterRenderer.flipX = true;
        else
            _characterRenderer.flipX = false;
    }
}
