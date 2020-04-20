using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Class for creating, saving and loading Json files. Files and folder get automatically created if they don't exist. 
/// </summary>

public class SettingsStorage<T> {
	private string _saveFolder;
	private string _saveFile;
	private T _data;

	public T Data {
		get { return _data; }
		set { Data = value; }
	}

	public SettingsStorage(string filePathAndName, T fileType) {
		_saveFile = filePathAndName;
		_saveFolder = Path.GetDirectoryName(_saveFile);
		_data = fileType;
		InitializeSave();
		_data = Load(_data);
	}

	public T Load(T data) {
		Converter<T> converter = new Converter<T>(data);
		string json = File.ReadAllText(_saveFile);
		data = converter.GetDataFromJson(json);
		return data;
	}

	public async void Save() {
		Converter<T> converter = new Converter<T>(_data);
		await WaitForFileData();
		File.WriteAllText(_saveFile, converter.GetDataToJson());

		/*if (new FileInfo(_saveFile).Length == 0) {
			File.WriteAllText(_saveFile, converter.GetDataToJson());
		}*/

	}

	async Task<bool> WaitForFileData() {
		bool succeeded = false;

		while (!succeeded) {
			bool outcome;

			if (File.Exists(_saveFile)) {
				outcome = true;
			} else {
				outcome = false;
			}

			succeeded = outcome;
			await Task.Delay(1000);
		}
		return succeeded;
	}

	private void InitializeSave() {
		if (!Directory.Exists(_saveFolder)) {
			Directory.CreateDirectory(_saveFolder);
		}

		if (!File.Exists(_saveFile)) {
			File.Create(_saveFile).Dispose();
			Save();
		}
	
	}
}
