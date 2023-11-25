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
        float rotz = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
        _characterRenderer.flipX = rotz ;
    }
}
