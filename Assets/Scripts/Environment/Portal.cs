using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Portal : MonoBehaviour 
{

	[SerializeField] private GameObject _player;
	[SerializeField] private float _phaseOneDelay;
	[SerializeField] private float _phaseTwoDelay;

	public event Action PlayerTeleported;

	private void OnTriggerEnter2D(Collider2D collision) 
	{
		if(collision.tag == "Player") 
		{
			StartCoroutine("StartTeleport");
		}
	}

	private IEnumerator StartTeleport() 
	{
		GetComponent<ActivateObject>().SwitchActiveObject();
		_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(_phaseOneDelay);
		StartCoroutine("TeleportPlayer");
	}

	private IEnumerator TeleportPlayer() 
	{
		Destroy(_player);
		GetComponent<ActivateObject>().SwitchActiveObject();
		yield return new WaitForSeconds(_phaseTwoDelay);
		PlayerTeleported?.Invoke();
	}

}
