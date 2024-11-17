using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void Interact()
    {
        DialogueManager.Instance.StartDialogue(inkJSON);
    }

    public void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            Interact();
        }
    }
}
