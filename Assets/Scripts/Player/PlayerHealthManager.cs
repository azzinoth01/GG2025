using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private float playerHealthMax = 100;
    private float playerHealth;
    void Start()
    {
        playerHealth = playerHealthMax;
    }
    public void UpdatePlayerHealth(float healthToAdd)
    {
        playerHealth += healthToAdd;
    }
}
