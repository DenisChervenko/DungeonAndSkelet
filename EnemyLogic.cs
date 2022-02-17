using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public static float _speedMove = -2f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        _rb.velocity = new Vector3(0, 0, _speedMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ColliderForDestroy") || collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

    }
}
