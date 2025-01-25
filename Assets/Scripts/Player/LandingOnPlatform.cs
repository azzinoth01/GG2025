using UnityEngine;

public class LandingOnPlatform : MonoBehaviour
{
    [SerializeField] private AudioClip _landingSound;
    [SerializeField] private LayerMask _landingCollisionMask;

    private void OnCollisionEnter2D(Collision2D collision) {

        LayerMask mask = 1 << collision.gameObject.layer;

        if ((mask & _landingCollisionMask) != 0) {
            GameManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);

            float linearVolume = Mathf.Pow(10, sfxVolume / 20);

            AudioSource.PlayClipAtPoint(_landingSound, transform.position, linearVolume);
        }

    }
}
