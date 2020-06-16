using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switches active objects. Used in UI menu's
/// </summary>

public class ActivateObject : MonoBehaviour {
	[SerializeField] private GameObject ActiveObject;
	[SerializeField] private GameObject InactiveObject;

	//Enables inactive object and disables active object
	public void SwitchActiveObject() {
		GameObject temp = ActiveObject;
		ActiveObject = InactiveObject;
		InactiveObject = temp;

		ActiveObject.SetActive(true);
		InactiveObject.SetActive(false);
	}
}
