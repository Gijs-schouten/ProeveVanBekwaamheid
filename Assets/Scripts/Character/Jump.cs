using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Class for player Jump
/// </summary>
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
        //checks if player is grounded
        RaycastHit2D HitInfo;
        HitInfo = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, .01f, _groundLayer);
        if (HitInfo)
        {
            grounded = true;
            _jumped = false;
            Jumping(false);
        }
        else
        {
            if (grounded)
            {
                grounded = false;
            }
        }

        //moves the player up
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jumping(true);
            _rB.velocity = Vector2.up * JumpForce;
            _jumped = true;
        }
        if (!grounded){
            _movement.movementSpeed = 10f;
        }

        //sends trigger to the PlayerAnimation script
    } 
    private void Jumping(bool isJumping)
    {
        JumpAction?.Invoke(isJumping);
    }

}
