using UnityEngine;

public class PopBubble : MonoBehaviour
{
    [SerializeField] private LayerMask _popBubbleCollideWith;
    [SerializeField] private float _forceOnPop;


    private void OnCollisionEnter2D(Collision2D collision) {
        LayerMask mask = 1 << collision.gameObject.layer;

        if ((mask & _popBubbleCollideWith) != 0) {
            Vector2 dir = collision.transform.position - transform.position;
            if (_forceOnPop != 0) {
                if (collision.gameObject.TryGetComponent(out Rigidbody2D body)) {
                    body.AddForce(dir.normalized * _forceOnPop);
                }
            }
            Destroy(gameObject);
        }
    }
}
