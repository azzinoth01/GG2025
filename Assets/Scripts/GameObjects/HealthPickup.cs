using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthToReplenish = 25;
    [SerializeField] private GameObject bubbleVFX;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent(out PlayerHealthManager collisionObject)){
            collisionObject.AddHealth(healthToReplenish);
        }  
        Destroy(gameObject);
    }
}
