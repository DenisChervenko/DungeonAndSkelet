using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonOnPauseScreen;

    public void PauseScreenActive()
    {
        for(int i = 0; i <= 2; i++)
        {
            _buttonOnPauseScreen[i].SetActive(true);
        }

        Time.timeScale = 0;
    } 

    public void PauseScreenDisable()
    {
        Time.timeScale = 1;
        for(int i = 0; i <= 2; i++)
        {
            _buttonOnPauseScreen[i].SetActive(false);
        }
    }
}
