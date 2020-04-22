using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    private NewMovement _newMovement;
    private float _horizontalMove;

    void Update()
    {
       // _horizontalMove = Input.GetAxisRaw("Horizontal") * _newMovement.movementSpeed;
        _anim.SetFloat("Speed", Mathf.Abs(_horizontalMove));
    }
}
