using UnityEngine;
using UnityEngine.SceneManagement;

public class MMIntroBGM : MonoBehaviour
{

    private bool procDestruction = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (procDestruction)
        {
            Destroy(gameObject);
        }

        if (scene.name == "IntroCutscene")
        {
            procDestruction = true;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
