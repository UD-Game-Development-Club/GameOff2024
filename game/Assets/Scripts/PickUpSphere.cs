using UnityEngine;

public class PickUpSphere : MonoBehaviour, IInteractable
{
    private PickUpController pickUpController;

    private void Start()
    {
        // Find the PickUpController in the scene (usually on the player/camera)
        pickUpController = Camera.main.GetComponent<PickUpController>();
        if (pickUpController == null)
        {
            Debug.LogError("PickUpController not found on main camera!");
        }
    }

    public void Interact()
    {
        if (pickUpController != null)
        {
            pickUpController.PickUpObject(gameObject);
        }
    }
}
