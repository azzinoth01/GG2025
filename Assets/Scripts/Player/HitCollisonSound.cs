using UnityEngine;

public class HitCollisonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private LayerMask _collisionMask;
    [SerializeField] private float _hitVolume;

    [SerializeField] private string _soundEventName;
    [SerializeField] private float _soundLength;

    private void OnCollisionEnter2D(Collision2D collision) {

        LayerMask mask = 1 << collision.gameObject.layer;

        if ((mask & _collisionMask) != 0) {
            if (_soundEventName != "") {

                //AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);
                //float linearVolume = Mathf.Pow(10, sfxVolume / 20);
                //AudioSource.PlayClipAtPoint(_hitSound, transform.position, linearVolume * _hitVolume);


                GameObject playSoundAtPosition = new GameObject();
                playSoundAtPosition.transform.position = transform.position;
                DestroyAfterTime destroyAfterTime = playSoundAtPosition.AddComponent<DestroyAfterTime>();
                destroyAfterTime.DestroyTime = _soundLength;
                AkSoundEngine.PostEvent(_soundEventName, playSoundAtPosition);
            }

        }

    }
}
