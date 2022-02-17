using UnityEngine;

public class BackButtonClick : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void OnClick()
    {
        _animator.SetTrigger("Click");
    }
}
