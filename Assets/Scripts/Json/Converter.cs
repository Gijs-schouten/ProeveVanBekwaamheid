using UnityEngine;

public class Converter<T> {
	private T _type;
	private string _jsonData;

	public Converter(T fileType) {
		_type = fileType;
	}

	public string GetDataToJson() {
		_jsonData = JsonUtility.ToJson(_type);
		return _jsonData;
	}

	public T GetDataFromJson(string jsonString) {
		T data = JsonUtility.FromJson<T>(jsonString); ;
		return data;
	}
}