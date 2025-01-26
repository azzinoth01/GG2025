using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button backToMenu;
    [SerializeField] private Button restart;
    private string MAIN_MENU = "MainMenu";
    void Start(){
        backToMenu.onClick.AddListener(BackToMenu);
        restart.onClick.AddListener(Restart);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
