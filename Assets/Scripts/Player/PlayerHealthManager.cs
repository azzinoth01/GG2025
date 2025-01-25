using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IHealthInterface
{
    [SerializeField] private float playerHealthMax = 100;
    [SerializeField] private float invulnerableDelay = 2;
    private float playerHealth;
    private float invulnerableTime;

    public event Action OnPlayerDied;
    public event EventHandler<OnHealthChangedEventArgs> OnHealthChanged;
    public class OnHealthChangedEventArgs : EventArgs {
        public float health;
    }

    public event EventHandler<OnSetIlvunerableEventArgs> SetIlvunerable;
    public class OnSetIlvunerableEventArgs : EventArgs {
        public bool isInvulnerable;
    }

    private enum HealthState {Alive, Invulnerable, Dead};
    private HealthState currentHealthState;

    public void KillActor(){
        OnPlayerDied?.Invoke();
    }
    public void UpdateHealth(float amount){
        if(amount > 0 && currentHealthState != HealthState.Invulnerable){
            playerHealth -= amount;
            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs{ health = playerHealth / playerHealthMax });
            currentHealthState = HealthState.Invulnerable;

            if(playerHealth <= 0){
                KillActor();
                currentHealthState = HealthState.Dead;
            }
        }
    }
    void Start(){
        playerHealth = playerHealthMax;
        currentHealthState = HealthState.Alive;
    }
    void Update(){
        switch(currentHealthState){
            case HealthState.Alive:
                break;
            case HealthState.Invulnerable:
                invulnerableTime += Time.deltaTime;
                Debug.Log(invulnerableTime);
                SetIlvunerable?.Invoke(this, new OnSetIlvunerableEventArgs{ isInvulnerable = true});
                if(invulnerableTime >= invulnerableDelay){
                    currentHealthState = HealthState.Alive;
                    SetIlvunerable?.Invoke(this, new OnSetIlvunerableEventArgs{ isInvulnerable = false});
                    invulnerableTime = 0f;
                }
                break;
            case HealthState.Dead:
                KillActor();
                break;
        }
    }
}
