using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour {
	[SerializeField] private GameObject ActiveObject;
	[SerializeField] private GameObject UnactiveObject;

	public void SwitchActiveObject() {
		UnactiveObject.SetActive(true);
		ActiveObject.SetActive(false);
	}
}
