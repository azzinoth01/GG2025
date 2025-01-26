using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _musicSlider;

    private float _sfxValue;
    private float _musicValue;

    public void SFXValueChanged(float value) {
        _sfxValue = value;

        //float decibel = 0;

        //if (value <= 0f) {
        //    decibel = -80;
        //}
        //else if (value < 0) {
        //    decibel = 0;
        //}
        //else {
        //    decibel = 20f * Mathf.Log10(value);
        //}


        //AudioManager.Instance.AudioMixer.SetFloat("SFX", decibel);
    }

    public void MusicValueChanged(float value) {
        _musicValue = value;
        //float decibel = 0;

        //if (value <= 0f) {
        //    decibel = -80;
        //}
        //else if (value < 0) {
        //    decibel = 0;
        //}
        //else {
        //    decibel = 20f * Mathf.Log10(value);
        //}
        //AudioManager.Instance.AudioMixer.SetFloat("Music", decibel);
    }

    public void SaveChanged() {

        SaveSettings saveSettings = new SaveSettings();
        //AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfx);
        //AudioManager.Instance.AudioMixer.GetFloat("Music", out float music);
        saveSettings.SfxVolume = _sfxValue;
        saveSettings.MusicVolume = _musicValue;
        saveSettings.SaveFile();
    }
    public void LoadAudioSave() {

        SaveSettings saveSettings = SaveSettings.LoadFile();

        //AudioManager.Instance.AudioMixer.GetFloat("SFX", out float decibel);
        //float scale = Mathf.Pow(10, decibel / 20f);

        _sfxSlider.value = saveSettings.SfxVolume;

        //AudioManager.Instance.AudioMixer.GetFloat("Music", out decibel);
        //scale = Mathf.Pow(10, decibel / 20f);

        _musicSlider.value = saveSettings.MusicVolume;

    }
}
