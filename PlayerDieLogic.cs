using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerDieLogic : MonoBehaviour, IUnityAdsListener
{
    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorPlayer;

    [Header("DieScreen")]
    [SerializeField] private GameObject _dieScreen;

    [Header("Ads")]
    [SerializeField] private bool _testMode = false;

    private BoxCollider _playerBC;
    private int _showAdsOrNot;

#if UNITY_IOS

    private string _gameId = "4606572";

#endif

#if UNITY_ANDROID

    private string _gameId = "4606573";

#endif

    private string _video = "Interstitial_Android";
    private string _rewardVideo = "Rewarded_Android";

    private void Start()
    {
        _playerBC = gameObject.GetComponent<BoxCollider>();

        _animator = _dieScreen.GetComponent<Animator>();
        _animatorPlayer = gameObject.GetComponent<Animator>();

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Handheld.Vibrate();
        _animator.SetTrigger("DieScreen");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartLevelButton()
    {
        _showAdsOrNot = Random.Range(0, 2);
        if (_showAdsOrNot == 1)
        {
            ShowAdsVideo(_video);
            Score._score = 0;
        }
        else
        {
            Debug.Log(_showAdsOrNot);
            Score._score = 0;
            Score._timeBetvenScoreIncrement = 2;
            RoadMov._speedMove = -2;
            EnemyLogic._speedMove = -2;
            CoinLogic._speedMove = -2;
            Time.timeScale = 1;
            _animator.SetTrigger("OffDieScreen");
            SceneManager.LoadScene(1);
        }
        
    }

    public void ContinueLevelAfterAdsButton()
    {
        Advertisement.Show(_rewardVideo);
        _playerBC.enabled = false;
        _animatorPlayer.SetTrigger("Imm");
        StartCoroutine(ActiveCollider(2));
    }

    IEnumerator ActiveCollider(float time)
    {
        yield return new WaitForSeconds(time);
        _playerBC.enabled = true;
        _animatorPlayer.SetTrigger("Move");
    }

    private void ShowAdsVideo(string placementId)
    {
        Advertisement.Show(placementId);
        _animator.SetTrigger("OffDieScreen");
    }

    #region InterfaceForAds

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
    #endregion

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _video)
        {
            Score._score = 0;
            Score._timeBetvenScoreIncrement = 2;
            RoadMov._speedMove = -2;
            EnemyLogic._speedMove = -2;
            CoinLogic._speedMove = -2;
            SceneManager.LoadScene(1);
        }

        if (showResult == ShowResult.Skipped)
        {
            Score._score = 0;
            Score._timeBetvenScoreIncrement = 2;
            RoadMov._speedMove = -2;
            EnemyLogic._speedMove = -2;
            CoinLogic._speedMove = -2;
            SceneManager.LoadScene(1);
            Debug.Log("Skipped");
        }
 
        Time.timeScale = 1;
        if(_animator == null)
        {
            _dieScreen = GameObject.Find("DieScreen");
            _animator = _dieScreen.GetComponent<Animator>();
            
        }

        _animator.SetTrigger("OffDieScreen");
        Debug.Log("Finished");
    }
}
