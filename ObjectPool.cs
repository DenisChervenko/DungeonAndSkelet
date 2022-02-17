using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Transform[] _spawnPointArray;
    private int _spawnPointTurn;
    private int _randomPrefabForSpawn;

    private Vector3 _positionForNextSpawn;

    [Header("Pool")]
    [SerializeField] private List<GameObject> _alreadySpawned;
    [SerializeField] private GameObject[] _objectForSpawn;
    [SerializeField] private Transform _temp;
    [SerializeField] private int _countPrefab;
    [SerializeField] private int _countCoinsPrefab;
    [SerializeField] private int _countPrefabAtSceneAfterTimeBetwenSpawn;
    

    [Header("Time")]
    [SerializeField] private float _timeBetwenSpawn;
    [SerializeField] private int _countIterationBeforeAcceleration;
    private float _elapsedTime;
    private int _iterationElapsedTime;
    

    [Header("SpeedForAcceleration")]
    [SerializeField] private float _speedForAccelerationObject;
    [SerializeField] private float _speedForAnimation;
    [SerializeField] private float _maxSpeedForAccelerationObject = -10;
    private bool _activeAcceleration = true;

    private void Start()
    {
        EnemyLogic._speedMove = -2;
        CoinLogic._speedMove = -2;
        RoadMov._speedMove = -2;

        for(int i = 0; i <= _countPrefab; i++)
        {
            _alreadySpawned.Add(Instantiate(_objectForSpawn[0]));
            _alreadySpawned.Add(Instantiate(_objectForSpawn[1]));
            _alreadySpawned.Add(Instantiate(_objectForSpawn[2]));
        }

        for(int i = 0; i <= _countCoinsPrefab; i++)
        {
            _alreadySpawned.Add(Instantiate(_objectForSpawn[3]));
            _alreadySpawned.Add(Instantiate(_objectForSpawn[4]));
            _alreadySpawned.Add(Instantiate(_objectForSpawn[5]));
        }
        for(int d = 0; d <= 41; d++)
        {
            _alreadySpawned[d].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _timeBetwenSpawn)
        {
            if(_activeAcceleration)
            {
                //acceleration object in pool
                _iterationElapsedTime += 1;
                if(_iterationElapsedTime >= _countIterationBeforeAcceleration)
                {
                    _iterationElapsedTime = 0;
                    EnemyLogic._speedMove += _speedForAccelerationObject;
                    CoinLogic._speedMove += _speedForAccelerationObject;
                    RoadMov._speedMove += _speedForAccelerationObject;

                    if(EnemyLogic._speedMove <= _maxSpeedForAccelerationObject)
                    {
                        EnemyLogic._speedMove = -10;
                        CoinLogic._speedMove = -10;
                        RoadMov._speedMove = -10;
                    }

                    Debug.Log(RoadMov._speedMove);
                    PlayerMoveLogic._animator.speed += _speedForAnimation; 
                    if(EnemyLogic._speedMove == _maxSpeedForAccelerationObject)
                    {
                        _activeAcceleration = false;
                        Debug.Log(1);
                    }
                }
            }
            

            _spawnPointTurn = Random.Range(0, 4);
            _randomPrefabForSpawn = Random.Range(0, _alreadySpawned.Count);

            if(_alreadySpawned[_randomPrefabForSpawn].activeSelf == true)
            {
                do
                {
                    _randomPrefabForSpawn = Random.Range(0, _alreadySpawned.Count);

                }while(_alreadySpawned[_randomPrefabForSpawn].activeSelf == false);
            
            }   
            
            _positionForNextSpawn = _spawnPointArray[_spawnPointTurn].transform.position;

            for(int i = 0; i < _countPrefabAtSceneAfterTimeBetwenSpawn; i++)
            {
                if(_alreadySpawned[_randomPrefabForSpawn].activeInHierarchy == false)
                {
                    _alreadySpawned[_randomPrefabForSpawn].transform.position = _positionForNextSpawn;
                    _alreadySpawned[_randomPrefabForSpawn].gameObject.SetActive(true);
                }
            }
            _elapsedTime = 0;
        }
    }
}
