using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _aimPiviot;
    [SerializeField] private GameObject _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;

    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private float _shootVolume;
    [SerializeField] private GameObject _projectileVFX;
    private Vector2 _aimDirection;

    [SerializeField] private string _soundEvent;
    [SerializeField] private float _soundLength;

    [SerializeField] private Animator _animator;
    public void ShootProjectile() {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, Quaternion.identity);
        Instantiate(_projectileVFX, _projectileSpawnPoint.transform.position, transform.rotation);
        projectile.MoveDirection = _aimDirection;
        if (_soundEvent != "") {
            //AudioManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);
            //float linearVolume = Mathf.Pow(10, sfxVolume / 20);
            //AudioSource.PlayClipAtPoint(_shootSound, _projectileSpawnPoint.transform.position, linearVolume * _shootVolume);

            GameObject playSoundAtPosition = new GameObject();
            playSoundAtPosition.transform.position = _projectileSpawnPoint.transform.position;
            DestroyAfterTime destroyAfterTime = playSoundAtPosition.AddComponent<DestroyAfterTime>();
            destroyAfterTime.DestroyTime = _soundLength;
            AkSoundEngine.PostEvent(_soundEvent, playSoundAtPosition);


        }
        _animator.SetTrigger("Shoot");
    }

    public void SetAim(Vector2 direction) {
        _aimDirection = direction;

        float aimAngle = Vector2.SignedAngle(Vector2.right, _aimDirection);
        _aimPiviot.transform.transform.localEulerAngles = new Vector3(0, 0, aimAngle);

    }
}
