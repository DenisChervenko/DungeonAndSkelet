using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterShoose : MonoBehaviour
{   
    [Header("Indexer")]
    [SerializeField] private List<int> _isBuy;
    [SerializeField] private int _chooseCharacter;

    [Header("Button")]
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _selectButton;
    [SerializeField] private GameObject _buyButtonInUI;
    [SerializeField] private GameObject _selectButtonInUI;

    [Header("List")]
    [SerializeField] private List<GameObject> _playerList;
    [SerializeField] private List<GameObject> _price;
    [SerializeField] private List<int> _priceInCode;

    [SerializeField] private TextMesh _balance;

    private int _balancePlayerAfterGame;

    private int _mainBalance;

    private int _currentTurn;


    [Header("Animation")]
    [SerializeField] private GameObject[] _arrow;
    [SerializeField] private GameObject[] _buyAndSelect;

    private Animator _buyAnimator;
    private Animator _selectAnimator;

    private Animator _animatorLeftArrow;
    private Animator _animatorRightArrow;

    [SerializeField] private GameObject _soundObject;
    private AudioSource _audio;
    

    private void Start()
    {
        
        _audio = _soundObject.GetComponent<AudioSource>();

        _buyAnimator = _buyButton.GetComponent<Animator>();
        _selectAnimator = _selectButton.GetComponent<Animator>();

        _animatorLeftArrow = _arrow[0].GetComponent<Animator>();
        _animatorRightArrow = _arrow[1].GetComponent<Animator>();

        if(PlayerPrefs.HasKey("ChosenPlayer"))
        {
            _chooseCharacter = PlayerPrefs.GetInt("ChosenPlayer");

            if (_currentTurn == _chooseCharacter)
            {
                _selectButton.SetActive(false);
                _selectButtonInUI.SetActive(false);
            }
            else
            {
                _selectButton.SetActive(true);
                _selectButtonInUI.SetActive(true);
            }
        }

        if(PlayerPrefs.HasKey("CharacterOne") || PlayerPrefs.HasKey("CharacterTwo"))
        {
            _isBuy[1] = PlayerPrefs.GetInt("CharacterOne");
            _isBuy[2] = PlayerPrefs.GetInt("CharacterTwo");
        }

        _balancePlayerAfterGame = PlayerPrefs.GetInt("CoinLevel");

        if (PlayerPrefs.HasKey("GlobalBalance"))
        {
            _mainBalance = PlayerPrefs.GetInt("GlobalBalance");
        }

        _mainBalance += _balancePlayerAfterGame;

        _balancePlayerAfterGame = 0;
        PlayerPrefs.SetInt("CoinLevel", _balancePlayerAfterGame);

        PlayerPrefs.SetInt("GlobalBalance", _mainBalance);

        _balance.text = Convert.ToString(_mainBalance);

        

        PlayerPrefs.SetInt("GlobalBalance", _mainBalance);
    }

    public void LeftButton()
    {
        _audio.Play();

        _animatorLeftArrow.SetTrigger("Left");

        _playerList[_currentTurn].gameObject.SetActive(false);
        _price[_currentTurn].gameObject.SetActive(false);

        _currentTurn--;

        if(_currentTurn < 0)
        {
            _currentTurn = 2;
        }


        //check if player will buy
        if(_isBuy[_currentTurn] == 0)
        {
            _buyButton.SetActive(true);
            _buyButtonInUI.SetActive(true);

            _selectButton.SetActive(false);
            _selectButtonInUI.SetActive(false);
        }
        else
        {
            _selectButton.SetActive(true);
            _selectButtonInUI.SetActive(true);

            _buyButton.SetActive(false);
            _buyButtonInUI.SetActive(false);
        }

        if(_currentTurn == _chooseCharacter)
        {
            _selectButton.SetActive(false);
            _selectButtonInUI.SetActive(false);
        }

        _price[_currentTurn].gameObject.SetActive(true);

        if(_currentTurn == _chooseCharacter || _isBuy[_currentTurn] == _currentTurn)
        {
            _price[_currentTurn].SetActive(false);
        }

        _playerList[_currentTurn].gameObject.SetActive(true);
    }

    public void RightButton()
    {
        _audio.Play();

        _animatorRightArrow.SetTrigger("Right");

        _playerList[_currentTurn].gameObject.SetActive(false);
        _price[_currentTurn].gameObject.SetActive(false);

        _currentTurn++;

        if(_currentTurn > 2)
        {
            _currentTurn = 0;
        }

        //check if player will buy
        if(_isBuy[_currentTurn] == 0)
        {
            _buyButton.SetActive(true);
            _buyButtonInUI.SetActive(true);

            _selectButton.SetActive(false);
            _selectButtonInUI.SetActive(false);
        }
        else
        {
            _selectButton.SetActive(true);
            _selectButtonInUI.SetActive(true);

            _buyButton.SetActive(false);
            _buyButtonInUI.SetActive(false);
        }

        if(_currentTurn == _chooseCharacter)
        {
            _price[_currentTurn].SetActive(false);
            _selectButton.SetActive(false);
            _selectButtonInUI.SetActive(false);
        }

        _price[_currentTurn].gameObject.SetActive(true);

        if(_currentTurn == _chooseCharacter || _isBuy[_currentTurn] == _currentTurn)
        {
            _price[_currentTurn].SetActive(false);
        }

        _playerList[_currentTurn].gameObject.SetActive(true);
    }

    public void ChooseCharacter()
    {
        _audio.Play();

        _chooseCharacter = _currentTurn;
        PlayerPrefs.SetInt("ChosenPlayer", _chooseCharacter);
        _selectAnimator.SetTrigger("Apply");
        _selectButton.SetActive(false);
    }

    public void BuyCharacter()
    {
        _audio.Play();

        if(_mainBalance >= _priceInCode[_currentTurn])
        {
            _buyButton.SetActive(false);
            _selectButton.SetActive(true);
            _mainBalance -= _priceInCode[_currentTurn];
            PlayerPrefs.SetInt("GlobalBalance", _mainBalance);
            _balance.text = Convert.ToString(_mainBalance);
            _isBuy.Insert(_currentTurn, 1);
            _buyAnimator.SetTrigger("Buy");



            PlayerPrefs.SetInt("CharacterOne", _isBuy[1]);
            PlayerPrefs.SetInt("CharacterTwo", _isBuy[2]);
        }
    }
}   
