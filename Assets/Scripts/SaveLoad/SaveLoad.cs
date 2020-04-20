using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {
	[SerializeField] public GameObject[] hairItems;
	[SerializeField] public GameObject[] topItems;
	[SerializeField] public GameObject[] bottomItems;

	private SettingsStorage<PlayerData> st;

	private void Start() {
		st = new SettingsStorage<PlayerData>(Application.persistentDataPath + "/saves/PlayerData.json", new PlayerData());
		print($"{st.Data.bottom} {st.Data.hair} {st.Data.top} ");
		//st.Data.bottom = 1;
		//st.Data.top = 2;
		//print($"{st.Data.bottom} {st.Data.hair} {st.Data.top} ");
		//st.Save();

		LoadCustomizationObject(hairItems, st.Data.hair, "Hair1");
		LoadCustomizationObject(topItems, st.Data.top, "Top1");
		LoadCustomizationObject(bottomItems, st.Data.bottom,"Bottom1");

	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.S)) {
			SaveCustomization();
		}
	}

	private void SaveCustomization() {
		st.Data.hair = GetActiveItem(hairItems);
		st.Data.top = GetActiveItem(topItems);
		st.Data.bottom = GetActiveItem(bottomItems);
		st.Save();
		print("youved haved saveded yeahe");
	}

	private void LoadCustomizationObject(GameObject[] items, int item, string objectName) {
		for (int i = 0; i < items.Length; i++) {
			if (i == item) {
				print(i);
				items[i].SetActive(true);
				ActivationManager manager = GameObject.Find(objectName).GetComponent<ActivationManager>();
				manager._activeGameObject = items[i];
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
