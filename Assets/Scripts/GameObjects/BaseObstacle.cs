using System;
using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        Destroy(collision.gameObject);
    }
}
