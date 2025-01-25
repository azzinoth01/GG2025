using UnityEngine;

public class RotateBasedOnMoveDirection : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _body;

    // Update is called once per frame
    void Update() {

        if (_body.linearVelocityX > 0) {
            Vector3 dir = new Vector3(0, 180, 0);
            transform.localEulerAngles = dir;
        }
        else if (_body.linearVelocityX < 0) {
            Vector3 dir = new Vector3(0, 0, 0);
            transform.localEulerAngles = dir;
        }
    }
}
