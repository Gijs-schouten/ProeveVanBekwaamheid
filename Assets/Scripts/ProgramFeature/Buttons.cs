using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private List <GameObject> _bugs;
    private Animator _anim;
    private int index;

   
    public void RightAnswer()
    {
        _anim = _bugs[index].GetComponent<Animator>();
        _anim.SetBool("Open", true);
        index++;
    }
}
