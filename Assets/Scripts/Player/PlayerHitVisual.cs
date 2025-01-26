using System;
using System.Collections;
using UnityEngine;

public class PlayerHitVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private Player player;
    private PlayerHealthManager playerHealthManager;

    private float flashDelay = 0f;
    private float flashAmount = 1.5f;
    private float flashCounter;

    void Start(){
        sprites = GetComponentsInChildren<SpriteRenderer>();
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
        playerHealthManager.OnHealthChanged += OnHealthChanged; 
        SetHitBool(0);
    }

    private void OnHealthChanged(object sender, PlayerHealthManager.OnHealthChangedEventArgs e)
    {
        if(e.isDamage){
            if(flashCounter != 0f){
                StopCoroutine(TakeDamageFlash());
                flashCounter = 0f;
            }
            StartCoroutine(TakeDamageFlash());
        }
    }
    void SetHitBool(int state){
        for(int i = 0; i < sprites.Length; i++){
            sprites[i].material.SetInt("_Hit", state);
        }
    }
    private IEnumerator TakeDamageFlash(){
        while(flashCounter <= flashAmount){
            SetHitBool(1);
            yield return new WaitForSeconds(0.125f);
            SetHitBool(0);
            flashCounter++;
            yield return new WaitForSeconds(0.25f);
        }
        flashCounter = 0f;
    }
}
