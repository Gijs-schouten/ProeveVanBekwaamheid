using UnityEngine;

/// <summary>
/// Class to convert Json data into Json string or the other way around
/// </summary>

public class Converter<T> 
{
	private T _type;
	private string _jsonData;

	public Converter(T fileType) 
	{
		_type = fileType;
	}

	//Returns Json data
	public string GetDataToJson() 
	{
		_jsonData = JsonUtility.ToJson(_type);
		return _jsonData;
	}

	//Returns Json string
	public T GetDataFromJson(string jsonString) 
	{
		T data = JsonUtility.FromJson<T>(jsonString);
		return data;
	}
}