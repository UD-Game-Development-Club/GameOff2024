using UnityEngine;

public class BedroomDoorTrigger : MonoBehaviour, IInteractable
{
    public bool isUnlocked = false;

    public void OnInteraction()
    {
        if (isUnlocked)
        {
            // TODO: play unlock sound
            gameObject.SetActive(false);
        }
    }
}
