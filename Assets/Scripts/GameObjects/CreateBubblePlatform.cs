using UnityEngine;

public class CreateBubblePlatform : MonoBehaviour
{
    [SerializeField] private LayerMask _createPlatfromOnCollisonWith;
    [SerializeField] private GameObject _bublePlatformPrefab;

    [SerializeField] private AudioClip _createBubblePlatformSound;
    [SerializeField] private float _createBubblePlatfstring;

    [SerializeField] private string _soundEvent;
    [SerializeField] private float _soundLength;

    private void OnCollisionEnter2D(Collision2D collision) {
        LayerMask mask = 1 << collision.gameObject.layer;

        if ((mask & _createPlatfromOnCollisonWith) != 0) {
            GameObject test = Instantiate(_bublePlatformPrefab, collision.transform.position, Quaternion.identity);
            if (_soundEvent != "") {
                //AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);
                //float linearVolume = Mathf.Pow(10, sfxVolume / 20);
                //AudioSource.PlayClipAtPoint(_createBubblePlatformSound, transform.position, linearVolume * _createBubblePlatformVolume);


                GameObject playSoundAtPosition = new GameObject();
                playSoundAtPosition.transform.position = transform.position;
                DestroyAfterTime destroyAfterTime = playSoundAtPosition.AddComponent<DestroyAfterTime>();
                destroyAfterTime.DestroyTime = _soundLength;
                AkSoundEngine.PostEvent(_soundEvent, playSoundAtPosition);
            }

        }
    }
}
