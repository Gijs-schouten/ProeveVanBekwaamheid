using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hitbox for the enemy. Enemy gets hit when player jumps on enemy else player will get hit.
/// </summary>

public class EnemyHitbox : MonoBehaviour 
{
	public event Action HitEnemy;

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "Player") 
		{
			Collide(collision.gameObject.transform.position.y, collision);
		}
	}

	private void Collide(float playerY, Collision2D collision) 
	{
		if(playerY > transform.position.y) 
		{
			HitEnemy?.Invoke();
		} 
		else 
		{
			collision.gameObject.GetComponent<Health>().TakeDamage();
		}
	}
}
