using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button backToMenu;
    private string MAIN_MENU = "MainMenu";
    void Start(){
        backToMenu.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
}
