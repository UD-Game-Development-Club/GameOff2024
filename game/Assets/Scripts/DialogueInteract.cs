using UnityEngine;

public class DialogueInteract : MonoBehaviour, IInteractable
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void OnInteraction()
    {
        DialogueManager.Instance.StartDialogue(inkJSON);
    }
}
