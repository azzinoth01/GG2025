using System.Collections;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{

    [SerializeField] private GameObject _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _delayBetweenShootsInSeconds;
    private Vector2 _shootDirection;


    private void Start() {


        StartCoroutine(ShootProjectile());
    }

    private IEnumerator ShootProjectile() {

        while (true) {
            yield return new WaitForSeconds(_delayBetweenShootsInSeconds);
            _shootDirection = (_projectileSpawnPoint.transform.position - transform.position).normalized;
            Projectile projectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.transform.position, Quaternion.identity);
            projectile.MoveDirection = _shootDirection;
        }


    }
}
