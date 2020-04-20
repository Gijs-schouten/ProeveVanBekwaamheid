using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationManager : MonoBehaviour {
	[SerializeField] private GameObject[] _menuButtons;
	public GameObject _activeGameObject;

	private void Start() {
		Subscribe(_menuButtons, Clicked);
	}

	private void Clicked(GameObject obj) {
		_activeGameObject.SetActive(false);
		_activeGameObject = obj;
		_activeGameObject.SetActive(true);
	}

	public void Subscribe(GameObject[] buttons, Action<GameObject> method) {
		for (int i = 0; i < buttons.Length; i++) {
			buttons[i].GetComponent<Button>().Clicked += method;
		}
	}
}
