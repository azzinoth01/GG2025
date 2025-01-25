using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;


    private Vector2 _moveDirection;
    private Rigidbody2D _body;

    public Vector2 MoveDirection {
        get {
            return _moveDirection;
        }

        set {
            _moveDirection = value;
        }
    }

    void Start() {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        _body.linearVelocity = _moveDirection * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        Destroy(gameObject);
    }



}
