using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PauseButton()
    {
        _animator.SetTrigger("PauseScreenActive");
        _pauseButton.SetActive(false);
    }
    public void ResumeGame()
    {
        _animator.SetTrigger("PauseScreenDisable");
        _pauseButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
