using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _musicSlider;

    public void SFXValueChanged(float value) {
        float decibel = 0;

        if (value <= 0f) {
            decibel = -80;
        }
        else if (value < 0) {
            decibel = 0;
        }
        else {
            decibel = 20f * Mathf.Log10(value);
        }


        AudioManager.Instance.AudioMixer.SetFloat("SFX", decibel);
    }

    public void MusicValueChanged(float value) {
        float decibel = 0;

        if (value <= 0f) {
            decibel = -80;
        }
        else if (value < 0) {
            decibel = 0;
        }
        else {
            decibel = 20f * Mathf.Log10(value);
        }
        AudioManager.Instance.AudioMixer.SetFloat("Music", decibel);
    }

    public void SaveChanged() {

        SaveSettings saveSettings = new SaveSettings();
        AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfx);
        AudioManager.Instance.AudioMixer.GetFloat("Music", out float music);
        saveSettings.SfxVolume = sfx;
        saveSettings.MusicVolume = music;
        saveSettings.SaveFile();
    }
    public void LoadAudioSave() {

        AudioManager.Instance.AudioMixer.GetFloat("SFX", out float decibel);
        float scale = Mathf.Pow(10, decibel / 20f);

        _sfxSlider.value = scale;

        AudioManager.Instance.AudioMixer.GetFloat("Music", out decibel);
        scale = Mathf.Pow(10, decibel / 20f);

        _musicSlider.value = scale;

    }
}
