using UnityEngine;


public class DoorTrigger : MonoBehaviour, IInteractable
{
    public bool isUnlocked;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void Start() {
        isUnlocked = false;
    }

    public void OnInteraction()
    {
        if (isUnlocked)
        {
            // TODO: play unlock sound
            gameObject.SetActive(false);
            // TODO: make dialgue for opening door
        }
        else
        {
            DialogueManager.Instance.StartDialogue(inkJSON);
        }
    }
}