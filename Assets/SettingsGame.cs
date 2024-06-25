using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public static class SettingsGame
{
    static SettingsGame()
    {
		PathToSave = Application.persistentDataPath + "/Save";
    }

    private static SaveFile save;
	private static readonly string PathToSave;

	public static SaveFile Save
	{
		get 
		{ 
			if (File.Exists(PathToSave))
				save = JsonConvert.DeserializeObject<SaveFile>(File.ReadAllText(PathToSave));
			else 
				save = new SaveFile();
			return save; 
		}
	}

}

public class SaveFile
{

}
