using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	private SceneLoader _loader;
	[SerializeField] private GameObject _player;

	[SerializeField] private float _phaseOneDelay;
	[SerializeField] private float _phaseTwoDelay;

	private void Start() {
		_loader = GetComponent<SceneLoader>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Player") {
			print("cool");
			StartCoroutine("StartTeleport");
		}
	}

	private IEnumerator StartTeleport() {
		GetComponent<ActivateObject>().SwitchActiveObject();
		_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(_phaseOneDelay);
		StartCoroutine("TeleportPlayer");
	}

	private IEnumerator TeleportPlayer() {
		Destroy(_player);
		GetComponent<ActivateObject>().SwitchActiveObject();
		yield return new WaitForSeconds(_phaseTwoDelay);
		_loader.LoadScene();
	}

}
