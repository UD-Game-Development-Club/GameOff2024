using UnityEngine;

public class SugarDoor : MonoBehaviour, IInteractable
{
    public bool unlocked = false;
    [SerializeField] private TextAsset lockedJSON;
    public void OnInteraction()
    {
        if(unlocked)
        {
            Destroy(gameObject);
        }
        else
        {
            DialogueManager.Instance.StartDialogue(lockedJSON);
        }
    }
}