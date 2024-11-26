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
            gameObject.SetActive(false);
            // TODO: make dialgue for opening door
            DialogueManager.Instance.StartDialogue(inkJSON);
        }
        else
        {
            DialogueManager.Instance.StartDialogue(inkJSON);
        }
    }
}
