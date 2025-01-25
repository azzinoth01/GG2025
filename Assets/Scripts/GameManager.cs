using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] private Player player;
    [SerializeField] private GameObject deathScreen;
    private PlayerHealthManager playerHealthManager;

    private void Awake(){
    if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }
    void Start(){
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
        playerHealthManager.OnPlayerDied += OnPlayerDied;
    }

    public void OnPlayerDied()
    {
        Destroy(player.gameObject);
        deathScreen.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
