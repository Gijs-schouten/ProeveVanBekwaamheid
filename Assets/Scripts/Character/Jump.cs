using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jump : MonoBehaviour
{
    public float JumpForce;
    public event Action <bool> JumpAction ;


    [SerializeField]private bool _jumped;
    [SerializeField] private LayerMask _groundLayer;
    public bool grounded;
    private PlayerMovement _movement;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rB;



    void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D HitInfo;
        HitInfo = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, .1f, _groundLayer);
        if (HitInfo)
        {
            grounded = true;
        }
        else
        {
            if (grounded)
            {
                grounded = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _rB.velocity = Vector2.up * JumpForce;
            _jumped = true;
        }
        if (!grounded){
            if (_jumped)
            {
                Jumping(true);
            }
            _movement.movementSpeed = 10f;
        }

    }
    /*public  bool IsGrounded()
    {
       RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, 1f, _groundLayer);
        _movement.movementSpeed = 15f;
        if (raycastHit2D.collider != null)
        {
            _jumped = false;
            Jumping(false);     
        }
        return raycastHit2D.collider != null;

    }*/
 
    private void Jumping(bool isJumping)
    {
        JumpAction?.Invoke(isJumping);
    }

}
