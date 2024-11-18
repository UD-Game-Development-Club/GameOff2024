using UnityEngine;

public class InteractableCube : MonoBehaviour, IInteractable
{
    // This is an example cube 

    public void Interact()
    {
        // Press F to interact
        Debug.Log("This is clicking !!!!!");
    }
}
