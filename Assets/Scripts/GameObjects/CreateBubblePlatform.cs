using UnityEngine;

public class CreateBubblePlatform : MonoBehaviour
{
    [SerializeField] private LayerMask _createPlatfromOnCollisonWith;
    [SerializeField] private GameObject _bublePlatformPrefab;

    [SerializeField] private AudioClip _createBubblePlatformSound;
    [SerializeField] private float _createBubblePlatformVolume;

    private void OnCollisionEnter2D(Collision2D collision) {
        LayerMask mask = 1 << collision.gameObject.layer;

        if ((mask & _createPlatfromOnCollisonWith) != 0) {
            GameObject test = Instantiate(_bublePlatformPrefab, collision.transform.position, Quaternion.identity);
            if (_createBubblePlatformSound != null) {
                GameManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);
                float linearVolume = Mathf.Pow(10, sfxVolume / 20);
                AudioSource.PlayClipAtPoint(_createBubblePlatformSound, transform.position, linearVolume * _createBubblePlatformVolume);
            }

        }
    }
}
