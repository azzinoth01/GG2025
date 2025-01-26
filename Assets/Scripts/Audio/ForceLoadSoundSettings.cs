using UnityEngine;

public class ForceLoadSoundSettings : MonoBehaviour
{

    private void Start() {
        AudioManager.Instance.LoadAudioSettings();

        AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfxDecibel);
        AudioManager.Instance.AudioMixer.GetFloat("Music", out float musicDecibel);

        float sfxVolume = Mathf.Clamp(Mathf.Pow(10, sfxDecibel / 20), 0, 1);
        float musicVolume = Mathf.Clamp(Mathf.Pow(10, musicDecibel / 20), 0, 1);

        AkSoundEngine.SetRTPCValue("SFXVolume", sfxVolume);
        AkSoundEngine.SetRTPCValue("MusicVolume", musicVolume);

    }
}
