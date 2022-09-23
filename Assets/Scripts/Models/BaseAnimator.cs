using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BaseAnimator : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController _animatorController;

    private Animator _animator;

    public void EntryAnimatorController(string nameAnimatorController, GameObject parent)
    {
        _animator = parent.AddComponent<Animator>();
        _animator.runtimeAnimatorController = _animatorController;
    }

    public void SetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void SetEnableAnimator(bool value)
    {
        _animator.enabled = value;
    }
}
