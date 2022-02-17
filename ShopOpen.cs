using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] private GameObject _shopButton;

    private Animator _animator;


    [SerializeField] private GameObject _soundObject;
    private AudioSource _audio;
    private void Start()
    {
        _audio = _soundObject.GetComponent<AudioSource>();
        _animator = _shopButton.GetComponent<Animator>();
    }

    public void OnClick()
    {
        _audio.Play();
        _animator.SetTrigger("Scale");
    }
}
