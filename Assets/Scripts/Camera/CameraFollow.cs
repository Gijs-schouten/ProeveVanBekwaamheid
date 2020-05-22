using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothSpeed = 0.125f;
	[SerializeField] private Vector3 _offset = new Vector3(0,5,-9);
	[SerializeField] private float _yMax = -24;

	void FixedUpdate() {
		if(transform.position.y > -24){
			MoveCamera();
		}
	}

	private void MoveCamera() {
		Vector3 desiredPosition = _target.position + _offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
		transform.position = smoothedPosition;
	}
}
