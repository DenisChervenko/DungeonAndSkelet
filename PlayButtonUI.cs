using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;

    private Animator _animatorPlayButton;

    [SerializeField] private GameObject _soundObject;
    private AudioSource _audio;
    private void Start()
    {
        _audio = _soundObject.GetComponent<AudioSource>();

        _animatorPlayButton = _playButton.GetComponent<Animator>();
    }

    public void OnClick()
    {
        _audio.Play();
        _animatorPlayButton.SetTrigger("Play");
    }
}
