using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveLogic : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject[] _player;
    [SerializeField] private Vector3 _playerPosition;

    public static Animator _animator;

    [Header("TargetMove")]
    [SerializeField] private GameObject[] _target;
    [SerializeField] private int _targetTurn = 2;
    [SerializeField] private Vector3[] _targetPosition;

    [Header("ButtonDirection")]
    [SerializeField] private bool _leftButtonPress = false;
    [SerializeField] private bool _rightButtonPress = false;

    private Rigidbody _rb;

    private int _playerTurn;


    private void Start()
    {
        _playerTurn = PlayerPrefs.GetInt("ChosenPlayer");
        _animator = _player[_playerTurn].GetComponent<Animator>();

        
        _rb = _player[_playerTurn].GetComponent<Rigidbody>();

        for(int i = 0; i <= 3; i++)
        {
            _targetPosition[i] = _target[i].transform.position;
        }

        _player[_playerTurn].gameObject.SetActive(true);

    }

    private void FixedUpdate()
    {
        ChangeSide();
    }

    private void ChangeSide()
    {
        if (_leftButtonPress == true)
        {
            _player[_playerTurn].transform.position = new Vector3(_targetPosition[_targetTurn].x, _targetPosition[_targetTurn].y, _targetPosition[_targetTurn].z);

            _leftButtonPress = false;
        }
        else if (_rightButtonPress == true)
        {
            _player[_playerTurn].transform.position = new Vector3(_targetPosition[_targetTurn].x, _targetPosition[_targetTurn].y, _targetPosition[_targetTurn].z);

            _rightButtonPress = false;
        }
    }

    public void LeftButton()
    {
        _targetTurn -= 1;
        if(_targetTurn < 0)
        {
            _targetTurn = 0;
        }
        _leftButtonPress = true;
    }

    public void RightButton()
    {
        _targetTurn += 1;
        if(_targetTurn > 3)
        {
            _targetTurn = 3;
        }
        _rightButtonPress = true;
    }
}
