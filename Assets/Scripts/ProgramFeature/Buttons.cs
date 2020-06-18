using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays animation of puzzle when right answers is aswered
/// </summary>

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private List <GameObject> _bugs;
    private Animator _anim;
    private int _index;

   
    public void RightAnswer()
    {
        _anim = _bugs[_index].GetComponent<Animator>();
        _anim.SetBool("Open", true);
        _index++;
    }
}
