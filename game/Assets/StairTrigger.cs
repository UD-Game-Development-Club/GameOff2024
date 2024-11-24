using UnityEngine;
using UnityEngine.SceneManagement;

public class StairTrigger : MonoBehaviour
{
    public bool isUnlocked = false;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isUnlocked)
            {
                // TODO: play unlock sound
                SceneManager.LoadScene("outside", LoadSceneMode.Single);
            }
            else
            {
                DialogueManager.Instance.StartDialogue(inkJSON);
            }
        }
    }
}
