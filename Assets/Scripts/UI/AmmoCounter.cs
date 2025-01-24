using System;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private Image ammoFill;
    [SerializeField] private Player player;
    private PlayerAmmoManager playerAmmoManager;

    void Start(){
        ammoFill.fillAmount = 1.0f;
        playerAmmoManager = player.GetComponent<PlayerAmmoManager>();

        playerAmmoManager.OnAmmoChanged += OnAmmoChanged;
    }

    private void OnAmmoChanged(object sender, PlayerAmmoManager.OnAmmoChangedEventArgs e){
        ammoFill.fillAmount = e.ammo;
    }
}
