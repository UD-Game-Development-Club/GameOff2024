using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject settings;

    private void Start()
    {
        settings.gameObject.SetActive(false);
    }

    private void Startgame()
    {
        SceneManager.LoadScene("IntroCutscene");
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void Settings()
    {
        mainMenu.gameObject.SetActive(false);
        settings.SetActive(true);
    }
    private void CloseSettings()
    {
        settings.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
