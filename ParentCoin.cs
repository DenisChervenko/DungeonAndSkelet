using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCoin : MonoBehaviour
{
    private float _elapsedTime;
    private float _timeBetvenCheckActiveChild = 2;

    [SerializeField] private GameObject[] _coin;


    private void FixedUpdate()
    {
        _elapsedTime += Time.fixedDeltaTime;

        if(_elapsedTime >= _timeBetvenCheckActiveChild)
        {
           
            if(!_coin[_coin.Length - 1].activeSelf)
            {
                gameObject.SetActive(false);
            }
           
        }
    }
}
