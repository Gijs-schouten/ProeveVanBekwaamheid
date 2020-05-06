using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject _bridge;
    private Animator _anim;

    void Start()
    {
        _anim = _bridge.GetComponent<Animator>();
    }

    public void RightAnswer()
    {
        _anim.SetBool("Open", true);
    }
}
