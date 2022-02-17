using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinLogic : MonoBehaviour
{
    [Header("Move")]
    public static float _speedMove = -2f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (gameObject.activeSelf)
        {
            _rb.velocity = new Vector3(0, 0, _speedMove);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("ColliderForDestroy") || other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
