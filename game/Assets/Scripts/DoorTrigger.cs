using UnityEngine;


public class DoorTrigger : MonoBehaviour, IInteractable
{
    public bool isUnlocked = false;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void OnInteraction()
    {
        if (isUnlocked)
        {
            // TODO: play unlock sound
            Debug.Log("Called interaction");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Called interaction");
            DialogueManager.Instance.StartDialogue(inkJSON);
        }
    }
}
