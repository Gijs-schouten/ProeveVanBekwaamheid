using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    private float _fallMultiplier = 8f;
    private float _lowJumpMulitplier = 12f;

    private Rigidbody2D _rB;

    void Start()
    {
        _rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(_rB.velocity.y < 0){
            _rB.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }else if (_rB.velocity.y > 0 && !Input.GetButton("Jump")) {
            _rB.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMulitplier - 1) * Time.deltaTime;
        }
    }
}
