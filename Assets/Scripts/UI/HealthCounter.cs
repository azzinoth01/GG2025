using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private Player player;
    private PlayerHealthManager playerHealthManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthFill.fillAmount = 1.0f;

        playerHealthManager = player.GetComponent<PlayerHealthManager>();

        playerHealthManager.OnHealthChanged += OnHealthChanged;
        playerHealthManager.SetIlvunerable += OnSetIlvunerable;
    }

    private void OnSetIlvunerable(object sender, PlayerHealthManager.OnSetIlvunerableEventArgs e)
    {
        gameObject.SetActive(!e.isInvulnerable);
    }

    private void OnHealthChanged(object sender, PlayerHealthManager.OnHealthChangedEventArgs e)
    {
        healthFill.fillAmount = e.health;
    }

}
