using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField] private AudioMixer audioMixer;

    public static AudioManager Instance {
        get {
            if (instance == null) {
                GameObject prefab = Resources.Load<GameObject>("AudioManager");
                GameObject init = Instantiate(prefab);
                instance = init.GetComponent<AudioManager>();
                DontDestroyOnLoad(instance);
                instance.LoadAudioSettings();
            }

            return instance;
        }
    }

    public AudioMixer AudioMixer {
        get {
            return audioMixer;
        }
    }

    public void LoadAudioSettings() {
        SaveSettings saveSettings = SaveSettings.LoadFile();
        instance.AudioMixer.SetFloat("Music", saveSettings.MusicVolume);
        instance.AudioMixer.SetFloat("SFX", saveSettings.SfxVolume);
    }
}
