using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour {
	private BoxCollider2D _collider;
	public event Action HitEnemy;
	public event Action HitPlayer;

	private void Start() {
		_collider = GetComponent<BoxCollider2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			Collide(collision.gameObject.transform.position.y, collision);
		}
	}

	private void Collide(float playerY, Collision2D collision) {
		if(playerY > transform.position.y) {
			HitEnemy?.Invoke();
		} else {
			collision.gameObject.GetComponent<Health>().TakeDamage();
		}
	}
}
