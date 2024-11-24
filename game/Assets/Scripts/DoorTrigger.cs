using UnityEngine;


public class DoorTrigger : MonoBehaviour
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
                Debug.Log("Called interaction");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Called interaction");
                DialogueManager.Instance.StartDialogue(inkJSON);
            }
        }
    }
}
