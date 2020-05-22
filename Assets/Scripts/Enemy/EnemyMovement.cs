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
				transform.Translate(new Vector3(_walkingSpeed * Time.deltaTime, 0, 0));

				if(transform.position.x >= xDistanceRight) {
					_renderer.flipX = true;
					_moveRight = false;
				}
				break;

			case false:
				transform.Translate(new Vector3(-_walkingSpeed * Time.deltaTime, 0, 0));

				if (transform.position.x <= xDistanceLeft) {
					_renderer.flipX = false;
					_moveRight = true;
				}
				break;
		}
	}
}
