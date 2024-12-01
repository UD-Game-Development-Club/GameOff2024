using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour, IInteractable
{
    public void OnInteraction()
    {
        SceneManager.LoadScene("abandonedhouse", LoadSceneMode.Single);
    }
}