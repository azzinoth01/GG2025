using UnityEngine;
using UnityEngine.Audio;

public class ForceLoadSoundSettings : MonoBehaviour
{

    private void Start() {
        AudioManager.Instance.LoadAudioSettings();
    }
}
