using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movement for the enemy. Enemy walks _walkDistance from where he is placed to both sides of starting position. Keeps walking left and right 
/// </summary>

public class EnemyMovement : MonoBehaviour 
{
	[SerializeField] private float _walkingSpeed;
	[SerializeField] private float _walkDistance;
	private float xDistanceRight;
	private float xDistanceLeft;
	private bool _moveRight;
	private SpriteRenderer _renderer;
	
	private void Start() 
	{
		xDistanceRight = transform.position.x + _walkDistance;
		xDistanceLeft = transform.position.x - _walkDistance;
		_renderer = GetComponent<SpriteRenderer>();
		_renderer.flipX = true;
	}

	
	private void FixedUpdate() 
	{
		MoveEnemy();
	}

	//Moves enemy left and right
	private void MoveEnemy() 
	{
		switch (_moveRight) 
		{
			case true:
				Move(_walkingSpeed);

				if(transform.position.x >= xDistanceRight) 
				{
					FlipEnemy();
				}

				break;

			case false:
				Move(-_walkingSpeed);

				if (transform.position.x <= xDistanceLeft) 
				{
					FlipEnemy();
				}

				break;
		}
	}

	//Movement logic
	private void Move(float speed) 
	{
		transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
	}

	//Flips the sprite and changes movement bool
	private void FlipEnemy() 
	{
		_moveRight = !_moveRight;
		_renderer.flipX = !_renderer.flipX;
	}
}
