using System;
using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    [SerializeField] private float baseDamage;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.TryGetComponent(out IHealthInterface collisionObject)){
            collisionObject.UpdateHealth(baseDamage);
        }
        Destroy(gameObject);
    }
}
