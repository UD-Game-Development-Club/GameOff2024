using UnityEngine;

public class InteractableCube : MonoBehaviour, IInteractable
{
    // This is an example cube 

    public void OnInteraction()
    {
        // Press F to interact
        Debug.Log("This is clicking !!!!!");
    }
}
