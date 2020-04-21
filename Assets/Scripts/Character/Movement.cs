using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rB;
    private bool _facingRight;
    private Jump _jump;

    public float movementSpeed = 15;

    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
        _jump = GetComponent<Jump>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Moving(horizontal);
        if (_jump.IsGrounded())
        {
            Flip(horizontal);
        }
    }

    private void Moving(float horizontal)
    {
        _rB.velocity = new Vector2(horizontal * movementSpeed, _rB.velocity.y);
    }

    private void Flip (float horizontal)
    {
        if (horizontal > 0 && !_facingRight || horizontal < 0 && _facingRight)
        {
            _facingRight = !_facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
