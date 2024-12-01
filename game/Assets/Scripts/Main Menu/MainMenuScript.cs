using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject settings;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Startgame()
    {
        audioSource.Play();
        SceneManager.LoadScene("IntroCutscene");
    }
    private void QuitGame()
    {
        audioSource.Play();
        Application.Quit();
    }
}
