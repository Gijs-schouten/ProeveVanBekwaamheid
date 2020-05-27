using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour {
	[SerializeField] private GameObject ActiveObject;
	[SerializeField] private GameObject InactiveObject;

	public void SwitchActiveObject() {
		GameObject temp = ActiveObject;
		ActiveObject = InactiveObject;
		InactiveObject = temp;

		ActiveObject.SetActive(true);
		InactiveObject.SetActive(false);
	}
}
