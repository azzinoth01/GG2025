using UnityEngine;

public class PlayerAmmoManager : MonoBehaviour
{
    [SerializeField] private float maxAmmo;
    [SerializeField] private float depleteAmount;

    private float currentAmmo;
    
    void Start(){
        currentAmmo = maxAmmo;
    }

    public bool CanShoot(){
        return currentAmmo >= 0;
    }
    public void DepleteAmmo(){
        currentAmmo -= depleteAmount;
        Debug.Log("Ammo left: " + currentAmmo);
    }
    public void AddAmmo(float toAdd){
        currentAmmo += toAdd;
    }

}
