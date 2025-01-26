using UnityEngine;
using UnityEngine.Audio;

public class ForceLoadSoundSettings : MonoBehaviour
{

    private void Start() {
        AudioManager.Instance.LoadAudioSettings();

        AudioSource source = gameObject.GetComponent<AudioSource>();
        AudioMixerGroup mixerGroup = AudioManager.Instance.AudioMixer.FindMatchingGroups("Music")[0]; ;
        source.outputAudioMixerGroup = mixerGroup;
    }
}
