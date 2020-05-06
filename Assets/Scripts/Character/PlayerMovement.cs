using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;


    public float movementSpeed;
    private float movementInputDirection;
    private float _horizontal;
    private float _horizontalMove;
    private Jump _jump;
    private Rigidbody2D _rB;
    private bool _facingRight;
    

    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
        _jump = GetComponent<Jump>();
    }

    void Update()
    {
        CheckInput();
        _horizontal = Input.GetAxisRaw("Horizontal");
        _horizontalMove = _horizontal * movementSpeed;
        _anim.SetFloat("Speed", Mathf.Abs(_horizontalMove));
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        if (_jump.IsGrounded())
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
}
