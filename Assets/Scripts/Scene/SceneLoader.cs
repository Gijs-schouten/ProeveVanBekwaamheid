using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads scene with given _sceneIndex. Used for UI.
/// </summary>

public class SceneLoader : MonoBehaviour {
	[SerializeField] private int _sceneIndex;

	public void LoadScene() {
		SceneManager.LoadScene(_sceneIndex);
	}
}
