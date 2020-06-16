using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Class for saving and loading Json data. Creates the file if given path is null.
/// </summary>

public class SettingsStorage<T> 
{
	private string _saveFolder;
	private string _saveFile;
	private T _data;

	public T Data 
	{
		get { return _data; }
		set { Data = value; }
	}

	//Constructor assings values locally and calls InitializeSave()
	public SettingsStorage(string filePathAndName, T fileType) 
	{
		_saveFile = filePathAndName;
		_saveFolder = Path.GetDirectoryName(_saveFile);
		_data = fileType;
		InitializeSave();
		_data = Load(_data);
	}

	//Loads data into given Type
	public T Load(T data) 
	{
		Converter<T> converter = new Converter<T>(data);
		string json = File.ReadAllText(_saveFile);
		data = converter.GetDataFromJson(json);
		return data;
	}

	//Saves current data into Json file
	public async void Save() 
	{
		Converter<T> converter = new Converter<T>(_data);
		await WaitForFileData();
		File.WriteAllText(_saveFile, converter.GetDataToJson());
	}

	//Waits if the Json file doesnt exist
	async Task<bool> WaitForFileData() 
	{
		bool succeeded = false;

		while (!succeeded) 
		{
			bool outcome;

			if (File.Exists(_saveFile)) 
			{
				outcome = true;
			} 
			else 
			{
				outcome = false;
			}

			succeeded = outcome;
			await Task.Delay(1000);
		}
		return succeeded;
	}

	//Creates Json file and save folder if they dont exist
	private void InitializeSave() 
	{
		if (!Directory.Exists(_saveFolder)) 
		{
			Directory.CreateDirectory(_saveFolder);
		}

		if (!File.Exists(_saveFile)) 
		{
			File.Create(_saveFile).Dispose();
			Save();
		}
	
	}
}
