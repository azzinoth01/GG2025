using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    private float _destroyTime;

    public float DestroyTime {
        get {
            return _destroyTime;
        }

        set {
            _destroyTime = value;
        }
    }

    private void Start() {
        StartCoroutine(DestoryObject());
    }

    IEnumerator DestoryObject() {

        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
