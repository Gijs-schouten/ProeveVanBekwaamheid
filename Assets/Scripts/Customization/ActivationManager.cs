using System;
using UnityEngine;

/// <summary>
/// Keeps track of wich UI object are and should be activated at what point
/// </summary>

public class ActivationManager : MonoBehaviour 
{
	[SerializeField] private GameObject[] _menuButtons;
	[SerializeField] private int _bodyPart;
	[SerializeField] private bool _sendObject;
	public GameObject _activeGameObject;
	public event Action<GameObject, int> ChangeObject;
	

	private void Start() 
	{
		Subscribe(_menuButtons, Clicked);
	}
	
	//Enables given GameObject and disables previous one
	private void Clicked(GameObject obj) 
	{
		if(_activeGameObject != null)
		_activeGameObject.SetActive(false);
		_activeGameObject = obj;
		_activeGameObject.SetActive(true);

		if (_sendObject) 
		{
			
			ChangeObject?.Invoke(_activeGameObject, _bodyPart);
		}
	}

	//Subscribes Clicked() to button events.
	public void Subscribe(GameObject[] buttons, Action<GameObject> method) 
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			buttons[i].GetComponent<Button>().Clicked += method;
		}
	}
}
