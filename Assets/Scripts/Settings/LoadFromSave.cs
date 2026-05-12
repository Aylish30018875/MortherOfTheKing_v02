using System.IO;
using UnityEngine;
using static AllText;
public static class LoadFromSave
{
    static SettingsSaveData _saveData = new SettingsSaveData();
    static FontInfo _fontInfo = new FontInfo();
    static string _filePath = "";

    public static FontInfo GetDataToSaveFont()
    {
        //set the default information for file path and save data
        _filePath = $"{Application.streamingAssetsPath}/Settings.json";
        //idrk why this is in the middle of these things
        LoadSettings();
        _fontInfo.color = Color.white;
        _fontInfo.scale = 1;

        //switch case to recall the text size :)
        switch (_saveData.textSize)
        {
            //the text size is stored as an int in the save data, so we need to convert it back to a scale value (all floats i think)
            case 0:
                _fontInfo.scale = 1; //the small option
                break;
            case 1:
                _fontInfo.scale = 1.25f; //the medium/default option
                break;
            case 2:
                _fontInfo.scale = 1.5f; //the big option
                break;
            default:
                _fontInfo.scale = 0.5f; //just to make it obvious that something went wrong
                break;
        }
        //same thing for the teext colour
        switch (_saveData.textColour)
        {
            //the text colour is stored as an int in the save data, so we need to convert it back to a color
            case 0:
                _fontInfo.color = Color.black; //the dark option
                break;
            case 1:
                _fontInfo.color = Color.gray5; //the middle default option
                break;
            case 2:
                _fontInfo.color = Color.white; //the bright option
                break;
            default:
                _fontInfo.color = Color.red; //just to make it obvious that something went wrong
                break;
        }

        //so we can return the font info to the text manager to apply it to the text ?
        return _fontInfo;
    }

    static SettingsSaveData LoadData()
    {
        //load the data from the file and convert it back to a settings save data object
        //Read the file as a string!
        string loadedDataAsJson = File.ReadAllText(_filePath);
        //Convert the json string back to a settings save data object and return it
        return JsonUtility.FromJson<SettingsSaveData>(loadedDataAsJson);
    }
    public static void LoadSettings()
    {
        //check if the file exists, if it does then load the data from it and store it in the save data variable
        if (File.Exists(_filePath))
        {
            //save data is now the data we loaded from the file
            _saveData = LoadData();
        }
    }
}
