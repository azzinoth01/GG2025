using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedIncreasePerSeconds;
    [SerializeField] private Vector2 _moveDirection;

    private Rigidbody2D _body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _body.linearVelocity = _moveDirection.normalized * _startSpeed;
    }

    // Update is called once per frame
    void Update() {
        _body.linearVelocity = _body.linearVelocity + _moveDirection.normalized * _speedIncreasePerSeconds * Time.deltaTime;
        _body.linearVelocity = _body.linearVelocity.normalized * Mathf.Clamp(_body.linearVelocity.magnitude, 0, _maxSpeed);
    }
}
