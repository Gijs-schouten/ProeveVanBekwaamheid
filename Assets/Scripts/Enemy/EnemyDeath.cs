using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {
	private EnemyHitbox _hitbox;
	[SerializeField] private Animator _animator;

	void Start() {
		_hitbox = GetComponent<EnemyHitbox>();
		_hitbox.HitEnemy += KillEnemy;
	}

	private void KillEnemy() {
		_animator.SetBool("Die", true);
		GetComponent<EnemyMovement>().enabled = false;
		GetComponent<EnemyHitbox>().enabled = true;
	}
}
