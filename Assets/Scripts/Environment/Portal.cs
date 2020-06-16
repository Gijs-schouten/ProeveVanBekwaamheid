using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class for teleporter at end of the level
/// </summary>

public class Portal : MonoBehaviour 
{

	[SerializeField] private GameObject _player;
	[SerializeField] private float _phaseOneDelay;
	[SerializeField] private float _phaseTwoDelay;

	public event Action PlayerTeleported;

	//Starts teleporting when player hits certain collider in teleporter
	private void OnTriggerEnter2D(Collider2D collision) 
	{
		if(collision.tag == "Player") 
		{
			StartCoroutine("StartTeleport");
		}
	}

	//Freezes player and enables particle animation
	private IEnumerator StartTeleport() 
	{
		GetComponent<ActivateObject>().SwitchActiveObject();
		_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(_phaseOneDelay);
		StartCoroutine("TeleportPlayer");
	}

	//"Teleports" (destroys) player and changes back particle. Calls event after delay to show end screen.
	private IEnumerator TeleportPlayer() 
	{
		Destroy(_player);
		GetComponent<ActivateObject>().SwitchActiveObject();
		yield return new WaitForSeconds(_phaseTwoDelay);
		PlayerTeleported?.Invoke();
	}

}
