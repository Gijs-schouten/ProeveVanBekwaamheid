using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Camera movement that automaticly follows _target
/// </summary>

public class CameraFollow : MonoBehaviour 
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _smoothSpeed = 0.125f;
	[SerializeField] private Vector3 _offset = new Vector3(0,5,-9);
	[SerializeField] private float _yMax = -24;

	void FixedUpdate() 
	{
		//Stops camera movement if player falls out of map
		if(transform.position.y > _yMax)
		{
			MoveCamera();
		}
	}

	//Moves camera smoothly to _target
	private void MoveCamera() 
	{
		Vector3 desiredPosition = _target.position + _offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
		transform.position = smoothedPosition;
	}
}
