using UnityEngine;

public class ForceLoadSoundSettings : MonoBehaviour
{

    private void Start() {
        //  AudioManager.Instance.LoadAudioSettings();

        SaveSettings saveSettings = SaveSettings.LoadFile();

        AkSoundEngine.SetRTPCValue("SFXVolume", saveSettings.SfxVolume);
        AkSoundEngine.SetRTPCValue("MusicVolume", saveSettings.MusicVolume);

    }
}
