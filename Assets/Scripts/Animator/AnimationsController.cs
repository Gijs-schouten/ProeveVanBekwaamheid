using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayAnim();
        }
    }

    public void PlayAnim()
    {
        bool isOpen = _anim.GetBool("Open");
        _anim.SetBool("Open", !isOpen);
    }
}
