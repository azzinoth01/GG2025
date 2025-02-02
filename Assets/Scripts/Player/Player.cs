using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, PlayerAction.IPlayerInputActions
{
    private Vector2 _moveDirection;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _maxMoveSpeed;

    [SerializeField] private float _shootForce;

    [SerializeField] private Weapon _weapon;

    private Vector2 _aimDirection;

    private Rigidbody2D _body;

    private PlayerAction _inputControl;
    private PlayerAmmoManager _ammoControl;

    [SerializeField] private Animator _animator;

    public void OnMove(InputAction.CallbackContext context) {
        _moveDirection = context.ReadValue<Vector2>();

        if (_moveDirection != Vector2.zero) {
            _animator.SetBool("isWalking", true);
        }
        else {
            _animator.SetBool("isWalking", false);
        }

    }
    public void OnAim(InputAction.CallbackContext context) {
        if (!GameManager.Instance.IsGamePaused()) {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 playerPosition = transform.position;
            _aimDirection = (mousePosition - playerPosition).normalized;

            _weapon.SetAim(_aimDirection);
        }
    }

    public void OnShoot(InputAction.CallbackContext context) {
        if (context.started && !GameManager.Instance.IsGamePaused()) {
            if (_ammoControl.CanShoot()) {
                Debug.Log(_ammoControl.GetAmmoAmount());
                _body.AddForce(-1 * _shootForce * _aimDirection);
                _ammoControl.DepleteAmmo();
                _weapon.ShootProjectile();
            }
        }
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.started) {
            GameManager.Instance.ToggleGamePaused();
        }
    }

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
        if (!GameManager.Instance.IsGamePaused()) {
            if (_ammoControl.CanShoot()) {
                Debug.Log(_ammoControl.GetAmmoAmount());
                _body.AddForce(-1 * _shootForce * _aimDirection);
                _ammoControl.DepleteAmmo();
                _weapon.ShootProjectile();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (_inputControl == null) {
            _inputControl = new PlayerAction();
            _inputControl.PlayerInput.Enable();
            _inputControl.PlayerInput.SetCallbacks(this);
        }
        _body = GetComponent<Rigidbody2D>();
        _ammoControl = GetComponent<PlayerAmmoManager>();
    }

    // Update is called once per frame
    void Update() {
        if (!GameManager.Instance.IsGamePaused()) {
            _body.AddForce(_moveForce * _moveDirection * Time.deltaTime);
            _body.linearVelocity = _body.linearVelocity.normalized * Mathf.Clamp(_body.linearVelocity.magnitude, 0, _maxMoveSpeed);


        }
    }

    private void OnDisable() {
        _inputControl.Disable();
        _inputControl.Dispose();
        _inputControl = null;
    }

}
