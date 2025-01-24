using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _aimPiviot;
    [SerializeField] private GameObject _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;
    private Vector2 _aimDirection;

    public void ShootProjectile() {
        Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, Quaternion.identity);
        projectile.MoveDirection = _aimDirection;
    }

    public void SetAim(Vector2 direction) {
        _aimDirection = direction;

        float aimAngle = Vector2.SignedAngle(Vector2.right, _aimDirection);
        _aimPiviot.transform.transform.localEulerAngles = new Vector3(0, 0, aimAngle);
    }

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
