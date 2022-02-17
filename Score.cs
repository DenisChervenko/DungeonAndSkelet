using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    static public int _score;
    static public float _timeBetvenScoreIncrement = 2;
    [SerializeField] private int _countIterationBeforeDecrementTime;
    private int _countIteration;
    private TextMesh _tm;

    private bool _disableScoreAcceleration = false;

    private float _elapsedTime;

    private void Start()
    {
        _tm = gameObject.GetComponent<TextMesh>();
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime;
        if(_elapsedTime >= _timeBetvenScoreIncrement)
        {
            _countIteration++;
            if(!_disableScoreAcceleration)
            {
                if (_countIteration >= _countIterationBeforeDecrementTime)
                {
                    _timeBetvenScoreIncrement -= 0.2f;
                    _countIteration = 0;
                    if (_timeBetvenScoreIncrement <= 0.5f)
                    {
                        _disableScoreAcceleration = true;
                    }
                }
            }
            _score++;
            _tm.text = Convert.ToString(_score);
            _elapsedTime = 0;
        }
    }
}
