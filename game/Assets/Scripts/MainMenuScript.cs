using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string gameScene;
    public GameObject mainMenu;
    public GameObject settings;

    public void Start()
    {
        settings.gameObject.SetActive(false);
    }

    public void Startgame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Settings()
    {
        mainMenu.gameObject.SetActive(false);
        settings.SetActive(true);
    }
    public void CloseSettings()
    {
        settings.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
