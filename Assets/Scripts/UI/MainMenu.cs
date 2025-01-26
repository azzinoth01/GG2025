using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button AboutButton;
    [SerializeField] private Button AboutBackButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private GameObject AboutScreen;

    private string GAME_SCENE = "Levels";

    void Start(){
        Time.timeScale = 1.0f;
        PlayButton.onClick.AddListener(StartGame);
        AboutButton.onClick.AddListener(ShowAbout);
        AboutBackButton.onClick.AddListener(ReturnToMenu);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void ReturnToMenu()
    {
        AboutScreen.gameObject.SetActive(false);
    }

    private void ShowAbout()
    {
        AboutScreen.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
    private void ExitGame(){
        Application.Quit();
    }
}
