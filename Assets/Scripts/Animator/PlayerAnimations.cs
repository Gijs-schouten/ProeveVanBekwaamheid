using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]private Jump _jump;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] Animator _anim;

    void Start()
    {
        _jump.JumpAction += JumpAnimationTrigger;
        _playerMovement.WalkAction += WalkAnimationTrigger;
    }


    private void JumpAnimationTrigger(bool isJumping)
    {
        _anim.SetBool("isJumping", isJumping);
    }

    private void WalkAnimationTrigger(bool isWalking)
    {
        _anim.SetBool("Open", isWalking);
    }

}

