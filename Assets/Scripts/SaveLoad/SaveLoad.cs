using UnityEngine;

public class SaveLoad : MonoBehaviour {
	[SerializeField] private GameObject[] _hairItems;
	[SerializeField] private GameObject[] _topItems;
	[SerializeField] private GameObject[] _bottomItems;

	[SerializeField] private bool _inCustomizer;
	private SettingsStorage<PlayerData> st;

	private void Start() {
		st = new SettingsStorage<PlayerData>(Application.persistentDataPath + "/saves/PlayerData.json", new PlayerData());
		
		LoadCustomizationObject(_hairItems, st.Data.hair, "Hair1");
		LoadCustomizationObject(_topItems, st.Data.top, "Top1");
		LoadCustomizationObject(_bottomItems, st.Data.bottom,"Bottom1");
	}

	public void SaveCustomization() {
		st.Data.hair = GetActiveItem(_hairItems);
		st.Data.top = GetActiveItem(_topItems);
		st.Data.bottom = GetActiveItem(_bottomItems);
		st.Save();
	}

	private void LoadCustomizationObject(GameObject[] items, int item, string objectName) {
		for (int i = 0; i < items.Length; i++) {
			if (i == item) {
				items[i].SetActive(true);

				if (_inCustomizer) {
					ActivationManager manager = GameObject.Find(objectName).GetComponent<ActivationManager>();
					manager._activeGameObject = items[i];
				}
				
			} else {
				items[i].SetActive(false);
			}
		}
	}

	private int GetActiveItem(GameObject[] items) {
		for (int i = 0; i < items.Length; i++) {
			if (items[i].activeSelf) {
				return i;
			}
		}

		return 0;
	}
}
