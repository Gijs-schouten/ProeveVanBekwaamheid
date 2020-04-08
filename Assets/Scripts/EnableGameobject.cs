using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameobject : MonoBehaviour {
	
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void Enable(GameObject obj) {
		obj.SetActive(true);
	}
}
