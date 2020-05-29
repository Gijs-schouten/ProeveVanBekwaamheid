using System;
using UnityEngine;

public class Button : MonoBehaviour 
{
	[SerializeField] private GameObject _obj;
	public event Action<GameObject> Clicked;

	public void Click() 
	{
		Clicked?.Invoke(_obj);
	}
}
