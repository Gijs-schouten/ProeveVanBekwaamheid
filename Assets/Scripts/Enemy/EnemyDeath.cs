using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that kills enemy when EnemyHitbox.HitEnemy() Action gets invoked.
/// </summary>

public class EnemyDeath : MonoBehaviour 
{

	private EnemyHitbox _hitbox;
	[SerializeField] private Animator _animator;

	private void Start() 
	{
		_hitbox = GetComponent<EnemyHitbox>();
		_hitbox.HitEnemy += KillEnemy;
	}

	//Kills enemy by playing animation and disables scripts related to enemy, enemies remain on the ground when dead
	private void KillEnemy() 
	{
		_animator.SetBool("Die", true);
		GetComponent<EnemyMovement>().enabled = false;
		Destroy(GetComponent<EnemyHitbox>());
	}
}
