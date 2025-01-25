using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private float ammoToReplenish = 25;
    [SerializeField] private GameObject bubbleVFX;
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.TryGetComponent(out PlayerAmmoManager collisionObject)){
            collisionObject.AddAmmo(ammoToReplenish);
            Instantiate(bubbleVFX, transform.position, Quaternion.identity);
        }  
        Destroy(gameObject);
    }
}
