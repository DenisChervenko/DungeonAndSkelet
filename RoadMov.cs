using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMov : MonoBehaviour
{
    [SerializeField] private Transform _startPointPlace;
    static public float _speedMove = -2f;

    private int _collisionWillOccurred;
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
        _rb.velocity = new Vector3(0, 0, _speedMove);
    }

 //  void OnCollisionExit(Collision other)
 //  {
 //      do
 //      {
 //          _rb.velocity = new Vector3(0, 0, 50);
 //      }while(_collisionWillOccurred == 1);
 //      if(_collisionWillOccurred >= 1)
 //      {
 //          _collisionWillOccurred = 0;
 //      }
 //  }

 //  void OnCollisionEnter(Collision collision)
 //  {
 //      _collisionWillOccurred++;
 //  }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("ColliderForDestroy"))
        {
            gameObject.SetActive(false);
            
            if(!gameObject.activeSelf)
            {
                gameObject.transform.position = _startPointPlace.transform.position;
                gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("ColliderForDestroy;"))
        {
            if(gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }

            if (!gameObject.activeSelf)
            {
                gameObject.transform.position = _startPointPlace.transform.position;
                gameObject.SetActive(true);
            }
        }
    }
}
