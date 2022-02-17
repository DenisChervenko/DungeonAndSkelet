using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBackOnAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void BackOnAnimator()
    {
        _animator.SetTrigger("Back");
    }
}
