using UnityEngine;

public class BedroomDoorTrigger : MonoBehaviour, IInteractable
{
    public bool isUnlocked = false;
    [SerializeField] private TextAsset lockedJSON;

    public void OnInteraction()
    {
        if (isUnlocked)
        {
            // TODO: play unlock sound
            gameObject.SetActive(false);
        }
        else
        {
            DialogueManager.Instance.StartDialogue(lockedJSON);
        }
    }
}
