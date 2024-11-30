using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) SceneManager.LoadScene("abandonedhouse", LoadSceneMode.Single);
    }
}