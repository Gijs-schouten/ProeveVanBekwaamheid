using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float JumpForce;
    [SerializeField] private LayerMask _groundLayer;
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
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))        {
            _rB.velocity = Vector2.up * JumpForce;
        }
        if (!IsGrounded()){
            Debug.Log("fart");
            _movement.movementSpeed = 10f;
        }
    }
    public  bool IsGrounded()
    {
       RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.size, 0f, Vector2.down, .1f, _groundLayer);
        _movement.movementSpeed = 15f;
       return raycastHit2D.collider != null;
    }
 
}
