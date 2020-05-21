using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	private float _xMovement;
	private float _yMovement;
	private float _zMovement;

	void Start() {
		RandomizeValues();
	}

	void Update() {
		gameObject.transform.Translate(_xMovement * Time.deltaTime,_yMovement * Time.deltaTime, _zMovement * Time.deltaTime);
	}

	private void RandomizeValues() {
		_xMovement = Random.Range(-0.5f, -1f);
		_yMovement = Random.Range(-0.1f, 0.2f);
		_zMovement = Random.Range(-0.1f, 0.2f);
	}
}
