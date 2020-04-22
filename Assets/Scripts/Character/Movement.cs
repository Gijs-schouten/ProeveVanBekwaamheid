using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rB;
    private bool _facingRight;
    private Jump _jump;
    private float _horizontalMove;


    [SerializeField]
    private Animator anim;

    public float movementSpeed;

    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
        _jump = GetComponent<Jump>();
    }

    void FixedUpdate()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        anim.SetFloat("Speed", Mathf.Abs(_horizontalMove));
         
        float horizontal = Input.GetAxis("Horizontal");

        print(horizontal);

        if (Input.GetButtonDown("Horizontal"))
        {
            Moving(horizontal);
        }
        if (_jump.IsGrounded())
        {
            Flip(horizontal);
        }
    }

    private void Moving(float horizontal)
    {
              //horizontal = Input.GetAxis("Horizontal");
             Vector3 movement = new Vector3(horizontal, 0f, 0f);
             transform.position += movement * Time.deltaTime * movementSpeed;
            //_rB.velocity = new Vector2(horizontal * movementSpeed, _rB.velocity.y);
    }

    private void Flip (float horizontal)
    {
        if (horizontal < 0 && !_facingRight || horizontal > 0 && _facingRight)
        {
            _facingRight = !_facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
