using UnityEngine;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    string _filePath;
    [SerializeField] SaveData _saveData;

    public void Start()
    {
        _filePath = $"{Application.streamingAssetsPath}/save.json";
    }
    #region Save
    void GetDataToSave()
    {

    }

    void SaveJson(SaveData dataToSave, string pathToSaveTo)
    {

    }

    public void Save()
    {

    }
    #endregion

    #region Load
    SaveData LoadData()
    {
        string loadedDataAsJson = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<SaveData>(loadedDataAsJson);
    }
    void SendDataToGame()
    {

    }
    public void Load()
    {

    }
    #endregion
}
