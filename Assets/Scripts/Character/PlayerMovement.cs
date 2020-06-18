using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Class for the player movement
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]

    public event Action <bool> WalkAction;

    public float movementSpeed;
    private float movementInputDirection;
    private float _horizontal;
    private Jump _jump;
    private Rigidbody2D _rB;
    private bool _facingRight;
    private bool _isMoving;
    

    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
        _jump = GetComponent<Jump>();
    }

    void Update()
    {
        CheckInput();
        _horizontal = Input.GetAxisRaw("Horizontal");
        //checks if the player is grounded while moving.
        if (Input.GetAxisRaw("Horizontal") >= 0.01f || Input.GetAxisRaw("Horizontal") <= - 0.01f && !_isMoving)
        {
            if (_jump.grounded)
            {
                _isMoving = true;
                TriggerWalking(true);
            }
        }
        else
        {
            if (_isMoving && Input.GetAxisRaw("Horizontal") == 0)
            {
                _isMoving = false;
                TriggerWalking(false);
            }
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        if (_jump.grounded)
        {
            Flip(_horizontal);
        }
    }

    void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
    }

    void ApplyMovement()
    {
        _rB.velocity = new Vector2(movementSpeed * movementInputDirection, _rB.velocity.y);
    }
    //rotates the player
    private void Flip(float _horizontal)
    {
        if (_horizontal < 0 && !_facingRight || _horizontal > 0 && _facingRight)
        {
            _facingRight = !_facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
           
        }
    }
    //sends a trigger to PlayerAnimations
    private void TriggerWalking(bool isWalking)
    {
        WalkAction?.Invoke(isWalking); 
    }


}
