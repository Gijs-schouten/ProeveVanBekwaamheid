using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for small random cloud movement.
/// </summary>

public class Cloud : MonoBehaviour 
{

	private float _xMovement;
	private float _yMovement;
	private float _zMovement;

	void Start() 
	{
		RandomizeValues();
	}

	private void FixedUpdate() 
	{
		MoveCloud(_xMovement, _yMovement, _zMovement, Time.deltaTime);
	}

	//Randomizes movement values. Clouds will always move left with slight x and y movement
	private void RandomizeValues() 
	{
		_xMovement = Random.Range(-0.5f, -1f);
		_yMovement = Random.Range(-0.1f, 0.2f);
		_zMovement = Random.Range(-0.1f, 0.2f);
	}

	//Moves cloud. Use deltatime for time parameter
	private void MoveCloud(float x, float y, float z, float time) {
		gameObject.transform.Translate(x * time, y * time, z * time);
	}
}
