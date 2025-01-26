using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveSettings
{
    [SerializeField] private float _sfxVolume;
    [SerializeField] private float _musicVolume;

    private const string _saveFileName = "/Settings.json";

    public float SfxVolume {
        get {
            return _sfxVolume;
        }

        set {
            _sfxVolume = value;
        }
    }

    public float MusicVolume {
        get {
            return _musicVolume;
        }

        set {
            _musicVolume = value;
        }
    }

    public void SaveFile() {
        string json = JsonUtility.ToJson(this);

        File.WriteAllText(Application.persistentDataPath + _saveFileName, json);
    }

    public static SaveSettings LoadFile() {
        string path = Application.persistentDataPath + _saveFileName;
        SaveSettings saveSettings = new SaveSettings();
        if (File.Exists(path)) {
            string json = File.ReadAllText(Application.persistentDataPath + _saveFileName);

            saveSettings = JsonUtility.FromJson<SaveSettings>(json);
        }
        else {
            saveSettings.SaveFile();
        }


        return saveSettings;
    }
}
