using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays animation of the player
/// </summary>

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
        //play animation Jump
        _anim.SetBool("isJumping", isJumping);
    }

    private void WalkAnimationTrigger(bool isWalking)
    {
        //play animation Walking
        _anim.SetBool("isWalking", isWalking);
    }

}

