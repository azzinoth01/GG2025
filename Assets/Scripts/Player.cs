using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, PlayerAction.IPlayerInputActions
{
    private Vector2 _moveDirection;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _maxMoveSpeed;

    [SerializeField] private float _shootForce;

    [SerializeField] private GameObject _aimPiviot;

    private Vector2 _aimDirection;

    private Rigidbody2D _body;

    private PlayerAction _inputControl;

    public void OnMove(InputAction.CallbackContext context) {
        _moveDirection = context.ReadValue<Vector2>();
    }
    public void OnAim(InputAction.CallbackContext context) {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Debug.Log(mousePosition);
        Vector2 playerPosition = transform.position;
        _aimDirection = (mousePosition - playerPosition).normalized;

        float aimAngle = Vector2.SignedAngle(Vector2.right, _aimDirection);
        _aimPiviot.transform.transform.localEulerAngles = new Vector3(0, 0, aimAngle);
    }

    public void OnShoot(InputAction.CallbackContext context) {
        _body.AddForce(-1 * _shootForce * _aimDirection);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (_inputControl == null) {
            _inputControl = new PlayerAction();
            _inputControl.PlayerInput.Enable();
            _inputControl.PlayerInput.SetCallbacks(this);
        }
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        _body.AddForce(_moveForce * _moveDirection * Time.deltaTime);

        _body.linearVelocity = _body.linearVelocity.normalized * Mathf.Clamp(_body.linearVelocity.magnitude, 0, _maxMoveSpeed);

    }

    private void OnDestroy() {
        if (_inputControl != null) {
            _inputControl.Dispose();
            _inputControl = null;
        }
    }


}
