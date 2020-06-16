using System;
using UnityEngine;

/// <summary>
/// Calls event on button click with GameObject parameter for use in other classes
/// </summary>

public class Button : MonoBehaviour 
{
	[SerializeField] private GameObject _obj;
	public event Action<GameObject> Clicked;

	//Invokes Action with parameter
	public void Click() 
	{
		Clicked?.Invoke(_obj);
	}
}
