using UnityEngine;
using System;

/// <summary>
/// Class that keeps track of enabled character objects and which should be enabled
/// </summary>

public class Character : MonoBehaviour 
{
	public GameObject[] characterObjects;
	public ActivationManager[] characterManagers;
	private bool isLoaded;

	private void Start() 
	{
		Subscribe(characterManagers, AddObject);
	}

	private void Update() 
	{
		//Loads active objects into characterObjects[]
		if (characterObjects[0] == null) 
		{
			for (int i = 0; i < characterObjects.Length; i++) 
			{
				characterObjects[i] = characterManagers[i]._activeGameObject;
			}
		}
	}

	//Adds object to characterObjects array
	private void AddObject(GameObject obj, int index) 
	{
		characterObjects[index] = obj;

		for (int i = 0; i < characterObjects.Length; i++) 
		{
			//Syncs the player animations in cuztomization menu
			characterObjects[i].GetComponent<Animator>().Play(0);
		}
	}

	//Subscribes AddObject() to certain UI buttons
	public void Subscribe(ActivationManager[] managers, Action<GameObject, int> method) 
	{
		for (int i = 0; i < managers.Length; i++) 
		{
			managers[i].ChangeObject += method;
		}
	}
}
