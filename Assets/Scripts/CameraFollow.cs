using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _followObject;
    [SerializeField] private float _followSpeed;
    [SerializeField] private float _maxXPosition;
    [SerializeField] private float _minXPosition;




    // Update is called once per frame
    void Update() {
        if(_followObject){
            Vector2 direction = _followObject.transform.position - transform.position;
            Vector3 move = direction.normalized * _followSpeed * Time.deltaTime;

            if (Mathf.Abs(move.y) > Mathf.Abs(direction.y)) {
                move.y = direction.y;
            }
            if (Mathf.Abs(move.x) > Mathf.Abs(direction.x)) {
                move.x = direction.x;
            }


            transform.position = transform.position + move;

            if (transform.position.x > _maxXPosition) {
                Vector3 pos = transform.position;
                pos.x = _maxXPosition;
                transform.position = pos;
            }
            else if (transform.position.x < _minXPosition) {
                Vector3 pos = transform.position;
                pos.x = _minXPosition;
                transform.position = pos;
            }
        }
    }
}
