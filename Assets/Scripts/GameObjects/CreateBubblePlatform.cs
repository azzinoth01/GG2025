using UnityEngine;

public class CreateBubblePlatform : MonoBehaviour
{
    [SerializeField] private LayerMask _createPlatfromOnCollisonWith;
    [SerializeField] private GameObject _bublePlatformPrefab;

    private float scale = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision) {
        LayerMask mask = 1 << collision.gameObject.layer;

        if ((mask & _createPlatfromOnCollisonWith) != 0) {
            GameObject test = Instantiate(_bublePlatformPrefab, collision.transform.position, Quaternion.identity);
        }
    }
    void Update(){
        scale -= Time.deltaTime * 10f;
        if(scale <= 0.0f){
            Destroy(gameObject);
        } else {
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
