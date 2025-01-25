using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {
        get; private set;
    }


    [SerializeField] private Player player;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject pauseScreen;
    private PlayerHealthManager playerHealthManager;
    private bool isGamePaused;
    [SerializeField] private AudioMixer _audioMixer;


    public AudioMixer AudioMixer {
        get {
            return _audioMixer;
        }
    }



    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
    void Start() {
        playerHealthManager = player.GetComponent<PlayerHealthManager>();
        playerHealthManager.OnPlayerDied += OnPlayerDied;
        isGamePaused = false;
        Time.timeScale = 1.0f;
    }
    public void OnPlayerDied() {
        Destroy(player.gameObject);
        deathScreen.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToggleGamePaused() {
        isGamePaused = !isGamePaused;
        pauseScreen.gameObject.SetActive(isGamePaused);
        if (isGamePaused) {
            Time.timeScale = 0.0f;
        }
        else {
            Time.timeScale = 1.0f;
        }
    }

    public bool IsGamePaused() {
        return isGamePaused;
    }
}
