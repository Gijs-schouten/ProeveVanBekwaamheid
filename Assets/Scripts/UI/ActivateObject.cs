using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switches active objects. Used in UI menu's
/// </summary>

public class ActivateObject : MonoBehaviour {
	[SerializeField] private GameObject _activeObject;
	[SerializeField] private GameObject _inactiveObject;

	//Enables inactive object and disables active object
	public void SwitchActiveObject() {
		GameObject temp = _activeObject;
		_activeObject = _inactiveObject;
		_inactiveObject = temp;

		_activeObject.SetActive(true);
		_inactiveObject.SetActive(false);
	}
}
