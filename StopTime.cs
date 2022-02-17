using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class StopTime : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonOnDieScreen;

    public void StopTimeScale()
    {
        Time.timeScale = 0;
        for(int i = 0;i <= 2; i++)
        {
            _buttonOnDieScreen[i].SetActive(true);
        } 
    }

    public void ResumeTime()
    {
        for (int i = 0; i <= 2; i++)
        {
            _buttonOnDieScreen[i].SetActive(false);
        }
    }
}
