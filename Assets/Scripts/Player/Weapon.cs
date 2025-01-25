using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _aimPiviot;
    [SerializeField] private GameObject _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;

    [SerializeField] private AudioClip _shootSound;
    private Vector2 _aimDirection;

    public void ShootProjectile() {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, Quaternion.identity);
        projectile.MoveDirection = _aimDirection;

        GameManager.Instance.AudioMixer.GetFloat("SFX", out float sfxVolume);

        float linearVolume = Mathf.Pow(10, sfxVolume / 20);

        AudioSource.PlayClipAtPoint(_shootSound, _projectileSpawnPoint.transform.position, linearVolume);

    }

    public void SetAim(Vector2 direction) {
        _aimDirection = direction;

        float aimAngle = Vector2.SignedAngle(Vector2.right, _aimDirection);
        _aimPiviot.transform.transform.localEulerAngles = new Vector3(0, 0, aimAngle);

    }
}
