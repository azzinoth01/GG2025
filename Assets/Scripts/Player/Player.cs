using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _moveDirection;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _maxMoveSpeed;

    [SerializeField] private float _shootForce;

    [SerializeField] private Weapon _weapon;

    private Vector2 _aimDirection;

    private Rigidbody2D _body;


    private PlayerAmmoManager _ammoControl;

    [SerializeField] private Animator _animator;

    public void Aim(Vector2 aim) {
        _aimDirection = aim.normalized;
        _weapon.SetAim(_aimDirection);
    }
    public void Moving(Vector2 move) {
        _moveDirection = move;
    }
    public void Pause() {
        GameManager.Instance.ToggleGamePaused();
    }
    public void Shoot() {
        if(!GameManager.Instance.IsGamePaused()) {
            if(_ammoControl.CanShoot()) {
                Debug.Log(_ammoControl.GetAmmoAmount());
                _body.AddForce(-1 * _shootForce * _aimDirection);
                _ammoControl.DepleteAmmo();
                _weapon.ShootProjectile();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _ammoControl = GetComponent<PlayerAmmoManager>();
    }

    // Update is called once per frame
    void Update() {
        if(!GameManager.Instance.IsGamePaused()) {
            _body.AddForce(_moveForce * _moveDirection * Time.deltaTime);
            _body.linearVelocity = _body.linearVelocity.normalized * Mathf.Clamp(_body.linearVelocity.magnitude,0,_maxMoveSpeed);
        }
    }


}
