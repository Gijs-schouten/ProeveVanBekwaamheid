using System;
using UnityEngine;

public class ActivationManager : MonoBehaviour {
	[SerializeField] private GameObject[] _menuButtons;
	[SerializeField] private int bodyPart;
	[SerializeField] private bool sendObject;
	public GameObject _activeGameObject;
	public event Action<GameObject, int> ChangeObject;
	

	private void Start() {
		Subscribe(_menuButtons, Clicked);
	}

	private void Clicked(GameObject obj) {
		_activeGameObject.SetActive(false);
		_activeGameObject = obj;
		_activeGameObject.SetActive(true);

		if (sendObject) {
			ChangeObject(_activeGameObject, bodyPart);
		}
	}

	public void Subscribe(GameObject[] buttons, Action<GameObject> method) {
		for (int i = 0; i < buttons.Length; i++) {
			buttons[i].GetComponent<Button>().Clicked += method;
		}
	}
}
