using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    [SerializeField] private float baseDamage;
    [SerializeField] private bool _doNotDestroyOnCollision;
    [SerializeField] private AudioClip _dmgSound;
    [SerializeField] private float _dmgVolume;

    [SerializeField] private string _soundEvent;
    [SerializeField] private float _soundLength;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out IHealthInterface collisionObject)) {
            collisionObject.UpdateHealth(baseDamage);

            if (baseDamage > 0 && _dmgSound != null) {
                if (_soundEvent != "") {
                    //AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);
                    //float linearVolume = Mathf.Pow(10, sfxVolume / 20);
                    //AudioSource.PlayClipAtPoint(_dmgSound, transform.position, linearVolume * _dmgVolume);

                    GameObject playSoundAtPosition = new GameObject();
                    playSoundAtPosition.transform.position = transform.position;
                    DestroyAfterTime destroyAfterTime = playSoundAtPosition.AddComponent<DestroyAfterTime>();
                    destroyAfterTime.DestroyTime = _soundLength;
                    AkSoundEngine.PostEvent(_soundEvent, playSoundAtPosition);
                }
            }
        }
        if (_doNotDestroyOnCollision == false) {
            Destroy(gameObject);
        }

    }
}
