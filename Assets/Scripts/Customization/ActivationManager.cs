using System;
using UnityEngine;

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

	private void Clicked(GameObject obj) 
	{
		if(_activeGameObject != null)
		_activeGameObject.SetActive(false);
		_activeGameObject = obj;
		_activeGameObject.SetActive(true);

		if (_sendObject) 
		{
			ChangeObject(_activeGameObject, _bodyPart);
		}
	}

	public void Subscribe(GameObject[] buttons, Action<GameObject> method) 
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			buttons[i].GetComponent<Button>().Clicked += method;
		}
	}
}
