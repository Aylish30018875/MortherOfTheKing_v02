using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsSaveAndLoad : MonoBehaviour
{
    //Accessing other scripts
    [SerializeField] SettingsSaveData _saveData;
    [SerializeField] SettingsSliderHandler _sliderHandler;
    [SerializeField] AudioMixer _audioMixer;
    //Where the settings data will be saved to and loaded from
    [SerializeField] string _filePath;// = $"{Application.persistentDataPath}/Settings.json";

    public static bool loadActive = false;

    #region Save
    void GetDataToSave()
    {
        //Get the volume level data and store it in the _saveData object
        _saveData.masterVolume = (int)_sliderHandler.masterVolumeSlider.value;
        _saveData.menuVolume = (int)_sliderHandler.menuMusicSlider.value;
        _saveData.ambientVolume = (int)_sliderHandler.ambientMusicSlider.value;
        _saveData.soundEffects = (int)_sliderHandler.soundEffectsSlider.value;
        _saveData.towerSoundEffects = (int)_sliderHandler.towerSoundEffectsSlider.value;
        _saveData.enemySoundEffects = (int)_sliderHandler.enemySoundEffectsSlider.value;
        _saveData.dialogueVolume = (int)_sliderHandler.dialogueVolumeSlider.value;
        _saveData.cutsceneVolume = (int)_sliderHandler.cutsceneVolumeSlider.value;
        //Get the text size and colour data and store it in the _saveData object
        _saveData.textSize = 1;
        _saveData.textColour = 1;
        _saveData.buttonColour = 1;


       
    }
    //Actually save the data to the file
    void SaveJson(SettingsSaveData dataToSave, string pathToSaveTo)
    {
        string contentToSave = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(pathToSaveTo, contentToSave);
    }
    //Create a function to call the other two functions to save the settings data
    public void SaveSettings()
    {
        Debug.Log("SaveSettings called");

        GetDataToSave();
        SaveJson(_saveData, _filePath);
    }
    #endregion

    #region Load
    SettingsSaveData LoadData()
    {
        string loadedDataAsJson = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<SettingsSaveData>(loadedDataAsJson);
    }

    void SendDataToGame()
    {
        _sliderHandler.masterVolumeSlider.value = _saveData.masterVolume;
        _sliderHandler.menuMusicSlider.value = _saveData.menuVolume;
        _sliderHandler.ambientMusicSlider.value = _saveData.ambientVolume;
        _sliderHandler.soundEffectsSlider.value = _saveData.soundEffects;
        _sliderHandler.towerSoundEffectsSlider.value = _saveData.towerSoundEffects;
        _sliderHandler.enemySoundEffectsSlider.value = _saveData.enemySoundEffects;
        _sliderHandler.dialogueVolumeSlider.value = _saveData.dialogueVolume;
        _sliderHandler.cutsceneVolumeSlider.value = _saveData.cutsceneVolume;
    }
    public void LoadSettings()
    {
        Debug.Log("LoadSettings called");

        //if (loadActive == true)
        //{
        if (File.Exists(_filePath))
        {
            Debug.Log("LoadSettings active");

            _saveData = LoadData();
            SendDataToGame();
        }
        //    loadActive = false;
        //}
    }
    #endregion
    private void Start()
    {
        _filePath = $"{Application.streamingAssetsPath}/Settings.json";
        LoadSettings();
    }
}
