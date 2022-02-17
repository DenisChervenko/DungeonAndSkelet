using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CharacterChosen : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerAtScene;

    private int _playerWillChosen;

    private void Start()
    {
        
        _playerWillChosen = PlayerPrefs.GetInt("ChosenPlayer");

        _playerAtScene[_playerWillChosen].gameObject.SetActive(true);
    }
}
