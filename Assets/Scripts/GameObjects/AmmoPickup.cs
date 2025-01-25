using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private float ammoToReplenish = 25;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.TryGetComponent(out PlayerAmmoManager collisionObject)){
            collisionObject.AddAmmo(ammoToReplenish);
        }  
        Destroy(gameObject);
    }
}
