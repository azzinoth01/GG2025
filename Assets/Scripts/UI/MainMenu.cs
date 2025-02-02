using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button LevelsButton;
    [SerializeField] private Button AboutButton;
    [SerializeField] private Button AboutBackButton;
    [SerializeField] private Button LevelsBackButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button Level1Button;
    [SerializeField] private GameObject AboutScreen;
    [SerializeField] private GameObject LevelsScreen;

    private string GAME_SCENE = "Levels";
    private string LEVEL1_SCENE = "Level1";

    void Start(){
        Time.timeScale = 1.0f;
        PlayButton.onClick.AddListener(StartGame);
        Level1Button.onClick.AddListener(Level1);
        LevelsButton.onClick.AddListener(ShowLevels);
        AboutButton.onClick.AddListener(ShowAbout);
        AboutBackButton.onClick.AddListener(ReturnToMenu);
        LevelsBackButton.onClick.AddListener(ReturnToMenu2);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void ReturnToMenu()
    {
        AboutScreen.gameObject.SetActive(false);
    }

        private void ReturnToMenu2()
    {
        LevelsScreen.gameObject.SetActive(false);
    }

    private void ShowAbout()
    {
        AboutScreen.gameObject.SetActive(true);
    }

    private void ShowLevels()
    {
        LevelsScreen.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
    
    private void Level1()
    {
        SceneManager.LoadScene(LEVEL1_SCENE);
    }

    private void ExitGame(){
        Application.Quit();
    }
}
