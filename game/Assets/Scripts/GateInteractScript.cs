using UnityEngine;

public class GateInteractScript : MonoBehaviour, IInteractable
{
    public void OnInteraction(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Abandonedhouse");
    }
}
