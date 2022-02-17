using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRecordCoin : MonoBehaviour
{
    [SerializeField] private TextMesh _balanceInScene;
    [SerializeField] private int _rewardFroOneCollectCoin;
    [SerializeField] private int _balancePlayerForSaveData;


    private AudioSource _audio;

    private void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            _balancePlayerForSaveData += _rewardFroOneCollectCoin;
            _balanceInScene.text = Convert.ToString(_balancePlayerForSaveData);
            PlayerPrefs.SetInt("CoinLevel", _balancePlayerForSaveData);
            _audio.Play();
        }
    }
}
