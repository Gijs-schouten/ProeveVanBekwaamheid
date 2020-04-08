using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public GameObject obj;
	public event Action<GameObject> Clicked;

	public void Click() {
		Clicked?.Invoke(obj);
	}
}
