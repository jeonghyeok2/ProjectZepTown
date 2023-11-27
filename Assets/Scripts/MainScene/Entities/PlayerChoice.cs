using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
    public RuntimeAnimatorController[] _animators;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _animator.runtimeAnimatorController = _animators[PlayerPrefs.GetInt("playerChoice")];
    }
}
