using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(true);
        restartButton.onClick.AddListener(RestartGame);
    }
    void RestartGame(){
        GameManager.Instance.RestartGame();
    }
    void HideScreen(){
        gameObject.SetActive(false);
    }
    void ShowScreen(){
        gameObject.SetActive(true);
    }
}
