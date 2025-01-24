using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IHealthInterface
{
    [SerializeField] private float playerHealthMax = 100;
    private float playerHealth;

    public void KillActor(){
        Destroy(gameObject);
    }

    public void UpdateHealth(float amount){
        playerHealth -= amount;
        if(playerHealth <= 0){
            KillActor();
        }
    }

    void Start(){
        playerHealth = playerHealthMax;
    }
}
