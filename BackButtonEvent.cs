using UnityEngine.SceneManagement;
using UnityEngine;

public class BackButtonEvent : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
