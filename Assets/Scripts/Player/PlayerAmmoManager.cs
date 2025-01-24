using System;
using NUnit.Framework;
using UnityEngine;

public class PlayerAmmoManager : MonoBehaviour
{
    [SerializeField] private float maxAmmo;
    [SerializeField] private float depleteAmount;
    [SerializeField] private float rechargeAmount;
    [SerializeField] private float rechargeDelay;

    private float currentAmmo;
    private float currentTime;
    
    void Start(){
        currentAmmo = maxAmmo;
    }

    public bool CanShoot(){
        return currentAmmo >= 0;
    }
    public void DepleteAmmo(){
        currentAmmo -= depleteAmount;
        Debug.Log("Ammo left: " + currentAmmo);
        currentTime = 0.0f;
    }
    public void AddAmmo(float toAdd){
        currentAmmo += toAdd;
        Debug.Log("Ammo left: " + currentAmmo);
        currentTime = 0.0f;
    }
    private void Update(){
        if(currentAmmo != maxAmmo){
            currentTime += Time.deltaTime;
            if(currentTime >= rechargeDelay){
                AddAmmo(rechargeAmount);
            }
        }
    }
}
