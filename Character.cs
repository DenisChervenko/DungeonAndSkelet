using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private List<GameObject> _player;

    private int _turnPlayer;

    private void Start()
    {
        _turnPlayer = PlayerPrefs.GetInt("ChosenPlayer");

        _player[_turnPlayer].gameObject.SetActive(true);
    }
}
