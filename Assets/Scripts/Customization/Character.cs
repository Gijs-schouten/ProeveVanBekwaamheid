using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour {
	public GameObject[] characterObjects;
	public ActivationManager[] characterManagers;

	private void start() {
		Subscribe(characterManagers, AddObject);

		for (int i = 0; i < characterObjects.Length; i++) {
			characterObjects[i] = characterManagers[i]._activeGameObject;
		}
	}

	private void AddObject(GameObject obj, int index) {
		characterObjects[index] = obj;

		for (int i = 0; i < characterObjects.Length; i++) {
			characterObjects[i].GetComponent<Animator>().Play(0);
		}
	}

	public void Subscribe(ActivationManager[] managers, Action<GameObject, int> method) {
		for (int i = 0; i < managers.Length; i++) {
			managers[i].ChangeObject += method;
		}
	}
}
