using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	[SerializeField] private float _walkingSpeed;
	[SerializeField] private float _walkDistance;
	private float xDistanceRight;
	private float xDistanceLeft;
	private bool _moveRight;
	private SpriteRenderer _renderer;
	
	void Start() {
		xDistanceRight = transform.position.x + _walkDistance;
		xDistanceLeft = transform.position.x - _walkDistance;
		_renderer = GetComponent<SpriteRenderer>();
		_renderer.flipX = true;
	}

	
	void Update() {
		MoveEnemy();
	}

	private void MoveEnemy() {
		switch (_moveRight) {
			case true:
				Move(_walkingSpeed);
				//transform.Translate(new Vector3(_walkingSpeed * Time.deltaTime, 0, 0));

				if(transform.position.x >= xDistanceRight) {
					FlipEnemy();
				}

				break;

			case false:
				Move(-_walkingSpeed);
				//transform.Translate(new Vector3(-_walkingSpeed * Time.deltaTime, 0, 0));

				if (transform.position.x <= xDistanceLeft) {
					FlipEnemy();
				}

				break;
		}
	}

	private void Move(float speed) {
		transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
	}

	private void FlipEnemy() {
		_moveRight = !_moveRight;
		_renderer.flipX = !_renderer.flipX;
	}
}
